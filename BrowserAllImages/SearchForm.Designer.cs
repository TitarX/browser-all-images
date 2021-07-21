namespace BrowserAllImages
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rootSearchFolderTextBox = new System.Windows.Forms.TextBox();
            this.splitPanel1 = new System.Windows.Forms.Panel();
            this.createDateFromMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.createDateToMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.allFormatsCheckBox = new System.Windows.Forms.CheckBox();
            this.pngFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.jpegFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.bmpFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.gifFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.tiffFormatCheckBox = new System.Windows.Forms.CheckBox();
            this.splitPanel2 = new System.Windows.Forms.Panel();
            this.createDateLabel = new System.Windows.Forms.Label();
            this.createDateFromTextBox = new System.Windows.Forms.TextBox();
            this.createDateToTextBox = new System.Windows.Forms.TextBox();
            this.createDateUntilLabel = new System.Windows.Forms.Label();
            this.allCreateDateCheckBox = new System.Windows.Forms.CheckBox();
            this.splitPanel3 = new System.Windows.Forms.Panel();
            this.imageWidthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageWidthToTextBox = new System.Windows.Forms.TextBox();
            this.imageWidthFromTextBox = new System.Windows.Forms.TextBox();
            this.allSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageHeightToTextBox = new System.Windows.Forms.TextBox();
            this.imageHeightFromTextBox = new System.Windows.Forms.TextBox();
            this.imageHeightLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootSearchFolderTextBox
            // 
            this.rootSearchFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootSearchFolderTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.rootSearchFolderTextBox.Location = new System.Drawing.Point(12, 12);
            this.rootSearchFolderTextBox.Name = "rootSearchFolderTextBox";
            this.rootSearchFolderTextBox.Size = new System.Drawing.Size(608, 20);
            this.rootSearchFolderTextBox.TabIndex = 0;
            this.rootSearchFolderTextBox.Text = "Корневая папка поиска";
            this.rootSearchFolderTextBox.Click += new System.EventHandler(this.RootSearchFolderTextBox_Click);
            // 
            // splitPanel1
            // 
            this.splitPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPanel1.Location = new System.Drawing.Point(12, 38);
            this.splitPanel1.Name = "splitPanel1";
            this.splitPanel1.Size = new System.Drawing.Size(608, 30);
            this.splitPanel1.TabIndex = 1;
            // 
            // createDateFromMonthCalendar
            // 
            this.createDateFromMonthCalendar.Location = new System.Drawing.Point(108, 153);
            this.createDateFromMonthCalendar.Name = "createDateFromMonthCalendar";
            this.createDateFromMonthCalendar.TabIndex = 30;
            this.createDateFromMonthCalendar.Visible = false;
            this.createDateFromMonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CreateDateFromMonthCalendar_DateSelected);
            // 
            // createDateToMonthCalendar
            // 
            this.createDateToMonthCalendar.Location = new System.Drawing.Point(263, 153);
            this.createDateToMonthCalendar.Name = "createDateToMonthCalendar";
            this.createDateToMonthCalendar.TabIndex = 0;
            this.createDateToMonthCalendar.Visible = false;
            this.createDateToMonthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.CreateDateToMonthCalendar_DateSelected);
            // 
            // allFormatsCheckBox
            // 
            this.allFormatsCheckBox.AutoSize = true;
            this.allFormatsCheckBox.Checked = true;
            this.allFormatsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allFormatsCheckBox.Location = new System.Drawing.Point(12, 97);
            this.allFormatsCheckBox.Name = "allFormatsCheckBox";
            this.allFormatsCheckBox.Size = new System.Drawing.Size(95, 17);
            this.allFormatsCheckBox.TabIndex = 2;
            this.allFormatsCheckBox.Text = "Все форматы";
            this.allFormatsCheckBox.UseVisualStyleBackColor = true;
            this.allFormatsCheckBox.CheckedChanged += new System.EventHandler(this.AllFormatsCheckBox_CheckedChanged);
            // 
            // pngFormatCheckBox
            // 
            this.pngFormatCheckBox.AutoSize = true;
            this.pngFormatCheckBox.Checked = true;
            this.pngFormatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pngFormatCheckBox.Enabled = false;
            this.pngFormatCheckBox.Location = new System.Drawing.Point(112, 74);
            this.pngFormatCheckBox.Name = "pngFormatCheckBox";
            this.pngFormatCheckBox.Size = new System.Drawing.Size(45, 17);
            this.pngFormatCheckBox.TabIndex = 3;
            this.pngFormatCheckBox.Text = "Png";
            this.pngFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // jpegFormatCheckBox
            // 
            this.jpegFormatCheckBox.AutoSize = true;
            this.jpegFormatCheckBox.Checked = true;
            this.jpegFormatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.jpegFormatCheckBox.Enabled = false;
            this.jpegFormatCheckBox.Location = new System.Drawing.Point(12, 74);
            this.jpegFormatCheckBox.Name = "jpegFormatCheckBox";
            this.jpegFormatCheckBox.Size = new System.Drawing.Size(49, 17);
            this.jpegFormatCheckBox.TabIndex = 4;
            this.jpegFormatCheckBox.Text = "Jpeg";
            this.jpegFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // bmpFormatCheckBox
            // 
            this.bmpFormatCheckBox.AutoSize = true;
            this.bmpFormatCheckBox.Checked = true;
            this.bmpFormatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bmpFormatCheckBox.Enabled = false;
            this.bmpFormatCheckBox.Location = new System.Drawing.Point(163, 74);
            this.bmpFormatCheckBox.Name = "bmpFormatCheckBox";
            this.bmpFormatCheckBox.Size = new System.Drawing.Size(47, 17);
            this.bmpFormatCheckBox.TabIndex = 5;
            this.bmpFormatCheckBox.Text = "Bmp";
            this.bmpFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // gifFormatCheckBox
            // 
            this.gifFormatCheckBox.AutoSize = true;
            this.gifFormatCheckBox.Checked = true;
            this.gifFormatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gifFormatCheckBox.Enabled = false;
            this.gifFormatCheckBox.Location = new System.Drawing.Point(67, 74);
            this.gifFormatCheckBox.Name = "gifFormatCheckBox";
            this.gifFormatCheckBox.Size = new System.Drawing.Size(39, 17);
            this.gifFormatCheckBox.TabIndex = 6;
            this.gifFormatCheckBox.Text = "Gif";
            this.gifFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // tiffFormatCheckBox
            // 
            this.tiffFormatCheckBox.AutoSize = true;
            this.tiffFormatCheckBox.Checked = true;
            this.tiffFormatCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tiffFormatCheckBox.Enabled = false;
            this.tiffFormatCheckBox.Location = new System.Drawing.Point(216, 74);
            this.tiffFormatCheckBox.Name = "tiffFormatCheckBox";
            this.tiffFormatCheckBox.Size = new System.Drawing.Size(41, 17);
            this.tiffFormatCheckBox.TabIndex = 7;
            this.tiffFormatCheckBox.Text = "Tiff";
            this.tiffFormatCheckBox.UseVisualStyleBackColor = true;
            // 
            // splitPanel2
            // 
            this.splitPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPanel2.Location = new System.Drawing.Point(14, 120);
            this.splitPanel2.Name = "splitPanel2";
            this.splitPanel2.Size = new System.Drawing.Size(608, 30);
            this.splitPanel2.TabIndex = 8;
            // 
            // createDateLabel
            // 
            this.createDateLabel.AutoSize = true;
            this.createDateLabel.Location = new System.Drawing.Point(12, 153);
            this.createDateLabel.Name = "createDateLabel";
            this.createDateLabel.Size = new System.Drawing.Size(90, 13);
            this.createDateLabel.TabIndex = 9;
            this.createDateLabel.Text = "Дата создания: ";
            // 
            // createDateFromTextBox
            // 
            this.createDateFromTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.createDateFromTextBox.Enabled = false;
            this.createDateFromTextBox.Location = new System.Drawing.Point(108, 153);
            this.createDateFromTextBox.Name = "createDateFromTextBox";
            this.createDateFromTextBox.ReadOnly = true;
            this.createDateFromTextBox.Size = new System.Drawing.Size(133, 20);
            this.createDateFromTextBox.TabIndex = 10;
            this.createDateFromTextBox.Click += new System.EventHandler(this.CreateDateFromTextBox_Click);
            // 
            // createDateToTextBox
            // 
            this.createDateToTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.createDateToTextBox.Enabled = false;
            this.createDateToTextBox.Location = new System.Drawing.Point(263, 153);
            this.createDateToTextBox.Name = "createDateToTextBox";
            this.createDateToTextBox.ReadOnly = true;
            this.createDateToTextBox.Size = new System.Drawing.Size(133, 20);
            this.createDateToTextBox.TabIndex = 11;
            this.createDateToTextBox.Click += new System.EventHandler(this.CreateDateToTextBox_Click);
            // 
            // createDateUntilLabel
            // 
            this.createDateUntilLabel.AutoSize = true;
            this.createDateUntilLabel.Location = new System.Drawing.Point(247, 156);
            this.createDateUntilLabel.Name = "createDateUntilLabel";
            this.createDateUntilLabel.Size = new System.Drawing.Size(10, 13);
            this.createDateUntilLabel.TabIndex = 12;
            this.createDateUntilLabel.Text = "-";
            // 
            // allCreateDateCheckBox
            // 
            this.allCreateDateCheckBox.AutoSize = true;
            this.allCreateDateCheckBox.Checked = true;
            this.allCreateDateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allCreateDateCheckBox.Location = new System.Drawing.Point(15, 179);
            this.allCreateDateCheckBox.Name = "allCreateDateCheckBox";
            this.allCreateDateCheckBox.Size = new System.Drawing.Size(177, 17);
            this.allCreateDateCheckBox.TabIndex = 13;
            this.allCreateDateCheckBox.Text = "Файлы любой даты создания";
            this.allCreateDateCheckBox.UseVisualStyleBackColor = true;
            this.allCreateDateCheckBox.CheckedChanged += new System.EventHandler(this.AllCreateDateCheckBox_CheckedChanged);
            // 
            // splitPanel3
            // 
            this.splitPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitPanel3.Location = new System.Drawing.Point(12, 202);
            this.splitPanel3.Name = "splitPanel3";
            this.splitPanel3.Size = new System.Drawing.Size(608, 30);
            this.splitPanel3.TabIndex = 14;
            // 
            // imageWidthLabel
            // 
            this.imageWidthLabel.AutoSize = true;
            this.imageWidthLabel.Location = new System.Drawing.Point(12, 238);
            this.imageWidthLabel.Name = "imageWidthLabel";
            this.imageWidthLabel.Size = new System.Drawing.Size(49, 13);
            this.imageWidthLabel.TabIndex = 16;
            this.imageWidthLabel.Text = "Ширина:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "-";
            // 
            // imageWidthToTextBox
            // 
            this.imageWidthToTextBox.Enabled = false;
            this.imageWidthToTextBox.Location = new System.Drawing.Point(222, 238);
            this.imageWidthToTextBox.Name = "imageWidthToTextBox";
            this.imageWidthToTextBox.Size = new System.Drawing.Size(133, 20);
            this.imageWidthToTextBox.TabIndex = 18;
            // 
            // imageWidthFromTextBox
            // 
            this.imageWidthFromTextBox.Enabled = false;
            this.imageWidthFromTextBox.Location = new System.Drawing.Point(67, 238);
            this.imageWidthFromTextBox.Name = "imageWidthFromTextBox";
            this.imageWidthFromTextBox.Size = new System.Drawing.Size(133, 20);
            this.imageWidthFromTextBox.TabIndex = 17;
            // 
            // allSizeCheckBox
            // 
            this.allSizeCheckBox.AutoSize = true;
            this.allSizeCheckBox.Checked = true;
            this.allSizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allSizeCheckBox.Location = new System.Drawing.Point(15, 290);
            this.allSizeCheckBox.Name = "allSizeCheckBox";
            this.allSizeCheckBox.Size = new System.Drawing.Size(183, 17);
            this.allSizeCheckBox.TabIndex = 20;
            this.allSizeCheckBox.Text = "Изображения любого размера";
            this.allSizeCheckBox.UseVisualStyleBackColor = true;
            this.allSizeCheckBox.CheckedChanged += new System.EventHandler(this.AllSizeCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "-";
            // 
            // imageHeightToTextBox
            // 
            this.imageHeightToTextBox.Enabled = false;
            this.imageHeightToTextBox.Location = new System.Drawing.Point(222, 264);
            this.imageHeightToTextBox.Name = "imageHeightToTextBox";
            this.imageHeightToTextBox.Size = new System.Drawing.Size(133, 20);
            this.imageHeightToTextBox.TabIndex = 23;
            // 
            // imageHeightFromTextBox
            // 
            this.imageHeightFromTextBox.Enabled = false;
            this.imageHeightFromTextBox.Location = new System.Drawing.Point(67, 264);
            this.imageHeightFromTextBox.Name = "imageHeightFromTextBox";
            this.imageHeightFromTextBox.Size = new System.Drawing.Size(133, 20);
            this.imageHeightFromTextBox.TabIndex = 22;
            // 
            // imageHeightLabel
            // 
            this.imageHeightLabel.AutoSize = true;
            this.imageHeightLabel.Location = new System.Drawing.Point(12, 264);
            this.imageHeightLabel.Name = "imageHeightLabel";
            this.imageHeightLabel.Size = new System.Drawing.Size(48, 13);
            this.imageHeightLabel.TabIndex = 21;
            this.imageHeightLabel.Text = "Высота:";
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(545, 348);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 25;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.Location = new System.Drawing.Point(12, 348);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 26;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 30);
            this.panel1.TabIndex = 28;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 374);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.TabIndex = 31;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 396);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.createDateFromMonthCalendar);
            this.Controls.Add(this.createDateToMonthCalendar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imageHeightToTextBox);
            this.Controls.Add(this.imageHeightFromTextBox);
            this.Controls.Add(this.imageHeightLabel);
            this.Controls.Add(this.allSizeCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageWidthToTextBox);
            this.Controls.Add(this.imageWidthFromTextBox);
            this.Controls.Add(this.imageWidthLabel);
            this.Controls.Add(this.splitPanel3);
            this.Controls.Add(this.allCreateDateCheckBox);
            this.Controls.Add(this.createDateUntilLabel);
            this.Controls.Add(this.createDateToTextBox);
            this.Controls.Add(this.createDateFromTextBox);
            this.Controls.Add(this.createDateLabel);
            this.Controls.Add(this.splitPanel2);
            this.Controls.Add(this.tiffFormatCheckBox);
            this.Controls.Add(this.gifFormatCheckBox);
            this.Controls.Add(this.bmpFormatCheckBox);
            this.Controls.Add(this.jpegFormatCheckBox);
            this.Controls.Add(this.pngFormatCheckBox);
            this.Controls.Add(this.allFormatsCheckBox);
            this.Controls.Add(this.splitPanel1);
            this.Controls.Add(this.rootSearchFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(640, 420);
            this.MinimumSize = new System.Drawing.Size(640, 420);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый поиск";
            this.Click += new System.EventHandler(this.SearchForm_Click);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rootSearchFolderTextBox;
        private System.Windows.Forms.Panel splitPanel1;
        private System.Windows.Forms.CheckBox allFormatsCheckBox;
        private System.Windows.Forms.CheckBox pngFormatCheckBox;
        private System.Windows.Forms.CheckBox jpegFormatCheckBox;
        private System.Windows.Forms.CheckBox bmpFormatCheckBox;
        private System.Windows.Forms.CheckBox gifFormatCheckBox;
        private System.Windows.Forms.CheckBox tiffFormatCheckBox;
        private System.Windows.Forms.Panel splitPanel2;
        private System.Windows.Forms.Label createDateLabel;
        private System.Windows.Forms.TextBox createDateFromTextBox;
        private System.Windows.Forms.TextBox createDateToTextBox;
        private System.Windows.Forms.Label createDateUntilLabel;
        private System.Windows.Forms.CheckBox allCreateDateCheckBox;
        private System.Windows.Forms.Panel splitPanel3;
        private System.Windows.Forms.Label imageWidthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imageWidthToTextBox;
        private System.Windows.Forms.TextBox imageWidthFromTextBox;
        private System.Windows.Forms.CheckBox allSizeCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox imageHeightToTextBox;
        private System.Windows.Forms.TextBox imageHeightFromTextBox;
        private System.Windows.Forms.Label imageHeightLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar createDateFromMonthCalendar;
        private System.Windows.Forms.MonthCalendar createDateToMonthCalendar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}