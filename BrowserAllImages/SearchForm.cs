using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace BrowserAllImages
{
    public partial class SearchForm : Form
    {
        private DataForWorkerThread dataForWorkerThread = null;
        private Regex onlyDigitsRegex = null;
        private Thread workerThread = null;
        private Thread waitingWorkerThread = null;
        private bool isClosing = false;

        public SearchForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeComponent2(mainForm);
        }

        private void InitializeComponent2(MainForm mainForm)
        {
            this.FormClosing += SearchForm_Closing;
            toolStripProgressBar.Size = new Size(this.Size.Width / 4 * 3, toolStripProgressBar.Size.Height);

            dataForWorkerThread = new DataForWorkerThread();
            dataForWorkerThread.MainForm = mainForm;
            dataForWorkerThread.SearchForm = this;

            onlyDigitsRegex = new Regex("[^0-9]");

            rootSearchFolderTextBox.GotFocus += RootSearchFolderTextBox_GotFocus;
            rootSearchFolderTextBox.LostFocus += RootSearchFolderTextBox_LostFocus;

            jpegFormatCheckBox.CheckedChanged += FormatsCheckBox_CheckedChanged;
            gifFormatCheckBox.CheckedChanged += FormatsCheckBox_CheckedChanged;
            pngFormatCheckBox.CheckedChanged += FormatsCheckBox_CheckedChanged;
            bmpFormatCheckBox.CheckedChanged += FormatsCheckBox_CheckedChanged;
            tiffFormatCheckBox.CheckedChanged += FormatsCheckBox_CheckedChanged;

            imageWidthFromTextBox.TextChanged += ImageSize_TextChanged;
            imageWidthToTextBox.TextChanged += ImageSize_TextChanged;
            imageHeightFromTextBox.TextChanged += ImageSize_TextChanged;
            imageHeightToTextBox.TextChanged += ImageSize_TextChanged;

            rootSearchFolderTextBox.TextChanged += DetermineAccessToStartButton;
            createDateFromTextBox.TextChanged += DetermineAccessToStartButton;
            createDateToTextBox.TextChanged += DetermineAccessToStartButton;
            imageWidthFromTextBox.TextChanged += DetermineAccessToStartButton;
            imageWidthToTextBox.TextChanged += DetermineAccessToStartButton;
            imageHeightFromTextBox.TextChanged += DetermineAccessToStartButton;
            imageHeightToTextBox.TextChanged += DetermineAccessToStartButton;
            allFormatsCheckBox.CheckedChanged += DetermineAccessToStartButton;
            jpegFormatCheckBox.CheckedChanged += DetermineAccessToStartButton;
            gifFormatCheckBox.CheckedChanged += DetermineAccessToStartButton;
            pngFormatCheckBox.CheckedChanged += DetermineAccessToStartButton;
            bmpFormatCheckBox.CheckedChanged += DetermineAccessToStartButton;
            tiffFormatCheckBox.CheckedChanged += DetermineAccessToStartButton;
            allCreateDateCheckBox.CheckedChanged += DetermineAccessToStartButton;
            allSizeCheckBox.CheckedChanged += DetermineAccessToStartButton;

            closeButton.Select();
        }

        public ToolStripProgressBar ToolStripProgressBar
        {
            get
            {
                return toolStripProgressBar;
            }
        }

        public ToolStripStatusLabel ToolStripStatusLabel
        {
            get
            {
                return toolStripStatusLabel;
            }
        }

        public bool IsClosing
        {
            get
            {
                return isClosing;
            }
        }

        public void RestoreStatusFormComponents()
        {
            rootSearchFolderTextBox.Text = dataForWorkerThread.RooSearchFolder;

            allFormatsCheckBox.Checked = dataForWorkerThread.IsAllFormats;
            allCreateDateCheckBox.Checked = dataForWorkerThread.IsAllCreateDate;
            allSizeCheckBox.Checked = dataForWorkerThread.IsAllSize;

            if (!dataForWorkerThread.IsAllFormats)
            {
                jpegFormatCheckBox.Checked = dataForWorkerThread.IsJpegFormat;
                gifFormatCheckBox.Checked = dataForWorkerThread.IsGifFormats;
                pngFormatCheckBox.Checked = dataForWorkerThread.IsPngFormats;
                bmpFormatCheckBox.Checked = dataForWorkerThread.IsBmpFormats;
                tiffFormatCheckBox.Checked = dataForWorkerThread.IsTiffFormats;
            }

            if (!dataForWorkerThread.IsAllCreateDate)
            {
                createDateFromTextBox.Text = dataForWorkerThread.CreateDateFrom.ToShortDateString();
                createDateToTextBox.Text = dataForWorkerThread.CreateDateTo.ToShortDateString();
            }

            if (!dataForWorkerThread.IsAllSize)
            {
                imageWidthFromTextBox.Text = Convert.ToString(dataForWorkerThread.ImageWidthFrom);
                imageWidthToTextBox.Text = Convert.ToString(dataForWorkerThread.ImageWidthTo);
                imageHeightFromTextBox.Text = Convert.ToString(dataForWorkerThread.ImageHeightFrom);
                imageHeightToTextBox.Text = Convert.ToString(dataForWorkerThread.ImageHeightTo);
            }

            createDateFromMonthCalendar.Visible = false;
            createDateToMonthCalendar.Visible = false;

            startButton.Text = "Старт";
            closeButton.Text = "Закрыть";
            toolStripStatusLabel.Text = "";
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar.Value = 0;
        }

        private void SearchForm_Closing(object sender, EventArgs e)
        {
            if (workerThread != null && workerThread.IsAlive)
            {
                isClosing = true;
                workerThread.Abort();
                workerThread.Join();
            }
        }

        private void RootSearchFolderTextBox_GotFocus(object sender, EventArgs e)
        {
            if (rootSearchFolderTextBox.Text.Trim().Equals("Корневая папка поиска"))
            {
                rootSearchFolderTextBox.Text = "";
                rootSearchFolderTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void RootSearchFolderTextBox_LostFocus(object sender, EventArgs e)
        {
            if (rootSearchFolderTextBox.Text.Trim().Equals(""))
            {
                rootSearchFolderTextBox.Text = "Корневая папка поиска";
                rootSearchFolderTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void RootSearchFolderTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                rootSearchFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void AllFormatsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allFormatsCheckBox.Checked)
            {
                jpegFormatCheckBox.Checked = true;
                jpegFormatCheckBox.Enabled = false;
                gifFormatCheckBox.Checked = true;
                gifFormatCheckBox.Enabled = false;
                pngFormatCheckBox.Checked = true;
                pngFormatCheckBox.Enabled = false;
                bmpFormatCheckBox.Checked = true;
                bmpFormatCheckBox.Enabled = false;
                tiffFormatCheckBox.Checked = true;
                tiffFormatCheckBox.Enabled = false;
            }
            else
            {
                jpegFormatCheckBox.Checked = false;
                jpegFormatCheckBox.Enabled = true;
                gifFormatCheckBox.Checked = false;
                gifFormatCheckBox.Enabled = true;
                pngFormatCheckBox.Checked = false;
                pngFormatCheckBox.Enabled = true;
                bmpFormatCheckBox.Checked = false;
                bmpFormatCheckBox.Enabled = true;
                tiffFormatCheckBox.Checked = false;
                tiffFormatCheckBox.Enabled = true;
            }
        }

        private void FormatsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (jpegFormatCheckBox.Checked && gifFormatCheckBox.Checked && pngFormatCheckBox.Checked && bmpFormatCheckBox.Checked && tiffFormatCheckBox.Checked)
            {
                allFormatsCheckBox.Checked = true;
            }
        }

        private void AllCreateDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allCreateDateCheckBox.Checked)
            {
                createDateFromTextBox.Text = "";
                createDateFromTextBox.Enabled = false;
                createDateFromTextBox.BackColor = SystemColors.Control;
                createDateToTextBox.Text = "";
                createDateToTextBox.Enabled = false;
                createDateToTextBox.BackColor = SystemColors.Control;
            }
            else
            {
                createDateFromTextBox.Enabled = true;
                createDateFromTextBox.BackColor = SystemColors.Window;
                createDateToTextBox.Enabled = true;
                createDateToTextBox.BackColor = SystemColors.Window;
            }
        }

        private void CreateDateFromTextBox_Click(object sender, EventArgs e)
        {
            createDateFromMonthCalendar.Visible = true;
            createDateToMonthCalendar.Visible = false;
        }

        private void CreateDateToTextBox_Click(object sender, EventArgs e)
        {
            createDateToMonthCalendar.Visible = true;
            createDateFromMonthCalendar.Visible = false;
        }

        private void CreateDateFromMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            createDateFromMonthCalendar.Visible = false;

            DateTime createDateFrom = e.End;
            createDateFromTextBox.Text = createDateFrom.ToShortDateString();
            dataForWorkerThread.CreateDateFrom = createDateFrom;
        }

        private void CreateDateToMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            createDateToMonthCalendar.Visible = false;

            DateTime createDateTo = e.End;
            createDateToTextBox.Text = createDateTo.ToShortDateString();
            dataForWorkerThread.CreateDateTo = createDateTo;
        }

        private void SearchForm_Click(object sender, EventArgs e)
        {
            createDateFromMonthCalendar.Visible = false;
            createDateToMonthCalendar.Visible = false;
        }

        private void AllSizeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allSizeCheckBox.Checked)
            {
                imageWidthFromTextBox.Text = "";
                imageWidthFromTextBox.Enabled = false;
                imageWidthToTextBox.Text = "";
                imageWidthToTextBox.Enabled = false;
                imageHeightFromTextBox.Text = "";
                imageHeightFromTextBox.Enabled = false;
                imageHeightToTextBox.Text = "";
                imageHeightToTextBox.Enabled = false;
            }
            else
            {
                imageWidthFromTextBox.Enabled = true;
                imageWidthToTextBox.Enabled = true;
                imageHeightFromTextBox.Enabled = true;
                imageHeightToTextBox.Enabled = true;
            }
        }

        private void ImageSize_TextChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = (TextBox)sender;
            String onlyDigitsString = onlyDigitsRegex.Replace(currentTextBox.Text, "");
            currentTextBox.Text = onlyDigitsString;
            currentTextBox.SelectionStart = onlyDigitsString.Length;
            currentTextBox.ScrollToCaret();
        }

        private void DetermineAccessToStartButton(object sender, EventArgs e)
        {
            if (workerThread == null || !workerThread.IsAlive)
            {
                bool accessBool = true;

                String rootSearchFolder = rootSearchFolderTextBox.Text.Trim();
                if (rootSearchFolder.Equals("") || !new DirectoryInfo(rootSearchFolder).Exists)
                {
                    accessBool = false;
                }
                else if (!jpegFormatCheckBox.Checked && !gifFormatCheckBox.Checked && !pngFormatCheckBox.Checked && !bmpFormatCheckBox.Checked && !tiffFormatCheckBox.Checked)
                {
                    accessBool = false;
                }
                else if (!allCreateDateCheckBox.Checked && (createDateFromTextBox.Text.Trim().Equals("") || createDateToTextBox.Text.Trim().Equals("")))
                {
                    accessBool = false;
                }
                else if (!allSizeCheckBox.Checked && (
                    imageWidthFromTextBox.Text.Trim().Equals("") || imageWidthToTextBox.Text.Trim().Equals("") ||
                    imageHeightFromTextBox.Text.Trim().Equals("") || imageHeightToTextBox.Text.Trim().Equals("")
                    ))
                {
                    accessBool = false;
                }

                if (accessBool)
                {
                    startButton.Enabled = true;
                }
                else
                {
                    startButton.Enabled = false;
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if ((workerThread != null && workerThread.IsAlive) || (waitingWorkerThread != null && waitingWorkerThread.IsAlive))
            {
                if (workerThread != null && workerThread.IsAlive)
                {
                    dataForWorkerThread.IsNowPause = false;
                    workerThread.Abort();
                    workerThread.Join();
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if ((workerThread != null && workerThread.IsAlive) || (waitingWorkerThread != null && waitingWorkerThread.IsAlive))
            {
                dataForWorkerThread.IsNowPause = !dataForWorkerThread.IsNowPause;

                if (dataForWorkerThread.IsNowPause)
                {
                    startButton.Text = "Старт";
                    toolStripStatusLabel.Text = "Приостановлено";
                }
                else
                {
                    startButton.Text = "Пауза";
                    toolStripStatusLabel.Text = "Поиск";
                }
            }
            else
            {
                dataForWorkerThread.MainForm.Reset();

                startButton.Text = "Пауза";
                closeButton.Text = "Стоп";

                toolStripStatusLabel.Text = "Подготовка";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;

                dataForWorkerThread.IsNowPause = false;

                dataForWorkerThread.RooSearchFolder = rootSearchFolderTextBox.Text.Trim();
                dataForWorkerThread.IsAllFormats = allFormatsCheckBox.Checked;
                dataForWorkerThread.IsAllCreateDate = allCreateDateCheckBox.Checked;
                dataForWorkerThread.IsAllSize = allSizeCheckBox.Checked;

                if (!dataForWorkerThread.IsAllFormats)
                {
                    dataForWorkerThread.IsJpegFormat = jpegFormatCheckBox.Checked;
                    dataForWorkerThread.IsGifFormats = gifFormatCheckBox.Checked;
                    dataForWorkerThread.IsPngFormats = pngFormatCheckBox.Checked;
                    dataForWorkerThread.IsBmpFormats = bmpFormatCheckBox.Checked;
                    dataForWorkerThread.IsTiffFormats = tiffFormatCheckBox.Checked;
                }

                if (!dataForWorkerThread.IsAllSize)
                {
                    dataForWorkerThread.ImageWidthFrom = Convert.ToInt32(imageWidthFromTextBox.Text.Trim());
                    dataForWorkerThread.ImageWidthTo = Convert.ToInt32(imageWidthToTextBox.Text.Trim());
                    dataForWorkerThread.ImageHeightFrom = Convert.ToInt32(imageHeightFromTextBox.Text.Trim());
                    dataForWorkerThread.ImageHeightTo = Convert.ToInt32(imageHeightToTextBox.Text.Trim());
                }

                WorkerThreadProcess workerThreadProcess = new WorkerThreadProcess(dataForWorkerThread);
                this.workerThread = workerThreadProcess.ThisThread;
                WaitingWorkerThreadProcess waitingWorkerThreadProcess = new WaitingWorkerThreadProcess(this, workerThreadProcess);
                this.waitingWorkerThread = waitingWorkerThreadProcess.ThisThread;
            }
        }
    }
}
