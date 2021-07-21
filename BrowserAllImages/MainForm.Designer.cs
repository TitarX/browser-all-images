namespace BrowserAllImages
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSearchFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathToClipboardEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToClipboardEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveImageToClipboardEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 424);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 321);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(632, 100);
            this.flowLayoutPanel.TabIndex = 1;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.Location = new System.Drawing.Point(0, 27);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(632, 288);
            this.panel.TabIndex = 2;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.editMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSearchFileMenuItem,
            this.exitFileMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(45, 20);
            this.fileMenuItem.Text = "Файл";
            // 
            // newSearchFileMenuItem
            // 
            this.newSearchFileMenuItem.Name = "newSearchFileMenuItem";
            this.newSearchFileMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newSearchFileMenuItem.Text = "Новый поиск";
            this.newSearchFileMenuItem.Click += new System.EventHandler(this.NewSearchFileMenuItem_Click);
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.Name = "exitFileMenuItem";
            this.exitFileMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitFileMenuItem.Text = "Выход";
            this.exitFileMenuItem.Click += new System.EventHandler(this.ExitFileMenuItem_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderEditMenuItem,
            this.pathToClipboardEditMenuItem,
            this.imageToClipboardEditMenuItem,
            this.moveImageToClipboardEditMenuItem,
            this.deleteImageEditMenuItem});
            this.editMenuItem.Enabled = false;
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(56, 20);
            this.editMenuItem.Text = "Правка";
            // 
            // openFolderEditMenuItem
            // 
            this.openFolderEditMenuItem.Name = "openFolderEditMenuItem";
            this.openFolderEditMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openFolderEditMenuItem.Text = "Открыть папку";
            this.openFolderEditMenuItem.Click += new System.EventHandler(this.OpenFolderEditMenuItem_Click);
            // 
            // pathToClipboardEditMenuItem
            // 
            this.pathToClipboardEditMenuItem.Name = "pathToClipboardEditMenuItem";
            this.pathToClipboardEditMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pathToClipboardEditMenuItem.Text = "Копировать путь";
            this.pathToClipboardEditMenuItem.Click += new System.EventHandler(this.PathToClipboardEditMenuItem1_Click);
            // 
            // imageToClipboardEditMenuItem
            // 
            this.imageToClipboardEditMenuItem.Name = "imageToClipboardEditMenuItem";
            this.imageToClipboardEditMenuItem.Size = new System.Drawing.Size(221, 22);
            this.imageToClipboardEditMenuItem.Text = "Копировать изображение";
            this.imageToClipboardEditMenuItem.Click += new System.EventHandler(this.ImageToClipboardEditMenuItem1_Click);
            // 
            // moveImageToClipboardEditMenuItem
            // 
            this.moveImageToClipboardEditMenuItem.Name = "moveImageToClipboardEditMenuItem";
            this.moveImageToClipboardEditMenuItem.Size = new System.Drawing.Size(221, 22);
            this.moveImageToClipboardEditMenuItem.Text = "Переместить изображение";
            this.moveImageToClipboardEditMenuItem.Click += new System.EventHandler(this.MoveEditMenuItem1_Click);
            // 
            // deleteImageEditMenuItem
            // 
            this.deleteImageEditMenuItem.Name = "deleteImageEditMenuItem";
            this.deleteImageEditMenuItem.Size = new System.Drawing.Size(221, 22);
            this.deleteImageEditMenuItem.Text = "Удалить изображение";
            this.deleteImageEditMenuItem.Click += new System.EventHandler(this.DeleteImageEditMenuItem_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Enabled = false;
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(153, 26);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browser all images";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSearchFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathToClipboardEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToClipboardEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveImageToClipboardEditMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
    }
}

