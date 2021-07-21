using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrowserAllImages
{
    public class WaitingWorkerThreadProcess
    {
        public delegate void SearchFormInvokeDelegate();

        private SearchFormInvokeDelegate searchFormInvokeDelegate = null;
        private SearchForm searchForm = null;
        private WorkerThreadProcess workerThreadProcess = null;
        private Thread thisThread = null;

        public WaitingWorkerThreadProcess(SearchForm searchForm, WorkerThreadProcess workerThreadProcess)
        {
            this.searchForm = searchForm;
            this.workerThreadProcess = workerThreadProcess;

            Thread thisThread = new Thread(this.Run);
            this.thisThread = thisThread;
            thisThread.Start();
        }

        public Thread ThisThread
        {
            get
            {
                return thisThread;
            }
        }

        private void Run()
        {
            if (workerThreadProcess.ThisThread.IsAlive)
            {
                workerThreadProcess.ThisThread.Join();
            }

            if (!searchForm.IsDisposed && !searchForm.IsClosing)
            {
                if (workerThreadProcess.IsAborted)
                {
                    searchFormInvokeDelegate = delegate
                    {
                        MessageBox.Show(searchForm, "Поиск изображений прерван", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        searchForm.RestoreStatusFormComponents();
                    };
                    searchForm.Invoke(searchFormInvokeDelegate);
                }
                else if (workerThreadProcess.IsNoResult)
                {
                    searchFormInvokeDelegate = delegate
                    {
                        MessageBox.Show(searchForm, "Поиск изображений не дал результата", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        searchForm.RestoreStatusFormComponents();
                    };
                    searchForm.Invoke(searchFormInvokeDelegate);
                }
                else
                {
                    searchFormInvokeDelegate = delegate
                    {
                        MessageBox.Show(searchForm, "Поиск успешно завешён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        searchForm.Dispose();
                    };
                    searchForm.Invoke(searchFormInvokeDelegate);
                }
            }
        }
    }
}
