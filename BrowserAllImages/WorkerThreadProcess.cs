using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace BrowserAllImages
{
    public class WorkerThreadProcess
    {
        public delegate void InvokeDelegate();

        private InvokeDelegate invokeDelegate = null;
        private DataForWorkerThread dataForWorkerThread = null;
        private Thread thisThread = null;
        private bool isAborted = false;
        private bool isNoResult = false;

        public WorkerThreadProcess(DataForWorkerThread dataForWorkerThread)
        {
            this.dataForWorkerThread = dataForWorkerThread;

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

        public bool IsAborted
        {
            get
            {
                return isAborted;
            }
        }

        public bool IsNoResult
        {
            get
            {
                return isNoResult;
            }
        }

        private void GetAllFiles(DirectoryInfo directoryInfo, ArrayList filesInfo)
        {
            try
            {
                directoryInfo.GetFiles().ToList().ForEach(fileInfo => filesInfo.Add(fileInfo));
                directoryInfo.GetDirectories().ToList().ForEach(nextDirectoryInfo => GetAllFiles(nextDirectoryInfo, filesInfo));
            }
            catch (UnauthorizedAccessException) { }
        }

        private void Run()
        {
            try
            {
                StringBuilder formatsRegexStringBuilder = new StringBuilder();
                if (dataForWorkerThread.IsAllFormats)
                {
                    formatsRegexStringBuilder.Append(@"(?:^\.jpeg$)|(?:^\.jfif$)|(?:^\.jpg$)|(?:^\.jpe$)|(?:^\.gif$)|(?:^\.png$)|(?:^\.bmp$)|(?:^\.tiff$)|(?:^\.tif$)");
                }
                else
                {
                    if (dataForWorkerThread.IsJpegFormat)
                    {
                        formatsRegexStringBuilder.Append(@"(?:^\.jpeg$)|(?:^\.jfif$)|(?:^\.jpg$)|(?:^\.jpe$)");
                    }
                    if (dataForWorkerThread.IsGifFormats)
                    {
                        if (formatsRegexStringBuilder.Length > 0)
                        {
                            formatsRegexStringBuilder.Append("|");
                        }
                        formatsRegexStringBuilder.Append(@"(?:^\.gif$)");
                    }
                    if (dataForWorkerThread.IsPngFormats)
                    {
                        if (formatsRegexStringBuilder.Length > 0)
                        {
                            formatsRegexStringBuilder.Append("|");
                        }
                        formatsRegexStringBuilder.Append(@"(?:^\.png$)");
                    }
                    if (dataForWorkerThread.IsBmpFormats)
                    {
                        if (formatsRegexStringBuilder.Length > 0)
                        {
                            formatsRegexStringBuilder.Append("|");
                        }
                        formatsRegexStringBuilder.Append(@"(?:^\.bmp$)");
                    }
                    if (dataForWorkerThread.IsTiffFormats)
                    {
                        if (formatsRegexStringBuilder.Length > 0)
                        {
                            formatsRegexStringBuilder.Append("|");
                        }
                        formatsRegexStringBuilder.Append(@"(?:^\.tiff$)|(?:^\.tif$)");
                    }
                }

                ArrayList filesInfo = new ArrayList();
                GetAllFiles(new DirectoryInfo(dataForWorkerThread.RooSearchFolder), filesInfo);

                invokeDelegate = delegate
                {
                    dataForWorkerThread.SearchForm.ToolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    dataForWorkerThread.SearchForm.ToolStripProgressBar.Maximum = filesInfo.Count;
                    dataForWorkerThread.SearchForm.ToolStripStatusLabel.Text = "Поиск";
                };
                dataForWorkerThread.SearchForm.Invoke(invokeDelegate);

                isNoResult = true;
                foreach (FileInfo fileInfo in filesInfo)
                {
                    try
                    {
                        while (dataForWorkerThread.IsNowPause)
                        {
                            Thread.Sleep(1000);
                        }

                        invokeDelegate = delegate
                        {
                            dataForWorkerThread.SearchForm.ToolStripProgressBar.Value++;
                        };
                        dataForWorkerThread.SearchForm.Invoke(invokeDelegate);

                        if (Regex.IsMatch(fileInfo.Extension, formatsRegexStringBuilder.ToString(), RegexOptions.IgnoreCase))
                        {

                            if (!dataForWorkerThread.IsAllCreateDate)
                            {
                                DateTime fileCreationTime = fileInfo.CreationTime;
                                fileCreationTime = new DateTime(fileCreationTime.Year, fileCreationTime.Month, fileCreationTime.Day);
                                if (fileCreationTime.CompareTo(dataForWorkerThread.CreateDateFrom) < 0 || fileCreationTime.CompareTo(dataForWorkerThread.CreateDateTo) > 0)
                                {
                                    continue;
                                }
                            }

                            String filePathString = fileInfo.FullName;
                            Image image = Image.FromFile(filePathString);
                            int imageWidth = image.Size.Width;
                            int imageHeight = image.Size.Height;

                            if (imageWidth == 0 || imageHeight == 0)
                            {
                                continue;
                            }

                            if (!dataForWorkerThread.IsAllSize)
                            {
                                if (imageWidth < dataForWorkerThread.ImageWidthFrom || imageWidth > dataForWorkerThread.ImageWidthTo ||
                                    imageHeight < dataForWorkerThread.ImageHeightFrom || imageHeight > dataForWorkerThread.ImageHeightTo)
                                {
                                    continue;
                                }
                            }

                            double previousImageHeight = dataForWorkerThread.MainForm.PreviousImageHeight;
                            double previousImageWidth = image.Size.Width / (image.Size.Height / previousImageHeight);

                            PictureBoxWithImagePath pictureBoxWithImagePath = new PictureBoxWithImagePath();
                            pictureBoxWithImagePath.Size = new Size(Convert.ToInt32(previousImageWidth), Convert.ToInt32(previousImageHeight));
                            pictureBoxWithImagePath.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBoxWithImagePath.ImagePath = filePathString;

                            pictureBoxWithImagePath.Image = new Bitmap(image, Convert.ToInt32(previousImageWidth), Convert.ToInt32(previousImageHeight));
                            image.Dispose();

                            isNoResult = false;
                            dataForWorkerThread.MainForm.Invoke(dataForWorkerThread.MainForm.addPictureBoxToFlowLayoutPanelDelegate, new Object[] { pictureBoxWithImagePath });
                        }
                    }
                    catch (OutOfMemoryException) { }
                    catch (FileNotFoundException) { }
                }
            }
            catch (ThreadAbortException)
            {
                isAborted = true;
            }
        }
    }
}
