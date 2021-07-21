using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;

namespace BrowserAllImages
{
    public partial class MainForm : Form
    {
        public delegate void AddPictureBoxToFlowLayoutPanelDelegate(PictureBoxWithImagePath pictureBoxWithImagePath);

        private PictureBoxWithImageChanged pictureBoxWithImageChanged = null;
        private PictureBoxWithImagePath currentBoxWithImagePath = null;
        private SearchForm searchForm = null;
        private SettingsData settingsData = null;
        public AddPictureBoxToFlowLayoutPanelDelegate addPictureBoxToFlowLayoutPanelDelegate = null;

        public MainForm()
        {
            InitializeComponent();
            InitializeComponent2();
        }

        public void InitializeComponent2()
        {
            addPictureBoxToFlowLayoutPanelDelegate = new AddPictureBoxToFlowLayoutPanelDelegate(AddPictureBoxToFlowLayoutPanel);

            panel.BackColor = Color.White;
            flowLayoutPanel.BackColor = Color.White;

            pictureBoxWithImageChanged = new PictureBoxWithImageChanged();
            pictureBoxWithImageChanged.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxWithImageChanged.ImageChanged += PictureBoxWithImageChanged_ImageChanged;
            panel.Controls.Add(pictureBoxWithImageChanged);

            settingsData = SettingsDataProcess.CreateSettingsData();

            this.FormClosing += SaveSettings;
            this.Load += AddActionToMainFormLoad;
        }

        public double PreviousImageHeight
        {
            get
            {
                return flowLayoutPanel.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight * 3 / 2;
            }
        }

        public void Reset()
        {
            currentBoxWithImagePath = null;
            pictureBoxWithImageChanged.Image = null;
            toolStripStatusLabel.Text = "";
            flowLayoutPanel.Controls.Clear();
        }

        private void RemoveDataLostFile()
        {
            pictureBoxWithImageChanged.Image = null;
            MessageBox.Show(this, "Не найден файл изображения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            flowLayoutPanel.Controls.Remove(currentBoxWithImagePath);
            currentBoxWithImagePath = null;
            toolStripStatusLabel.Text = "";
        }

        private void AddPictureBoxToFlowLayoutPanel(PictureBoxWithImagePath pictureBoxWithImagePath)
        {
            pictureBoxWithImagePath.Click += PictureBoxWithImagePath_Click;

            try
            {
                flowLayoutPanel.Controls.Add(pictureBoxWithImagePath);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(searchForm, "Недостаточно памяти для загрузки всех найденных изображений", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                searchForm.Dispose();
            }
        }

        private void ExitFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBoxWithImageChanged_ImageChanged(object sender, EventArgs e)
        {
            if (pictureBoxWithImageChanged.Image == null)
            {
                editMenuItem.Enabled = false;
                contextMenuStrip.Enabled = false;
            }
            else
            {
                editMenuItem.Enabled = true;
                contextMenuStrip.Enabled = true;
            }
        }

        private void AddActionToMainFormLoad(object sender, EventArgs e)
        {
            if (settingsData.IsMainFormMaximize)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Size = new Size(settingsData.MainFormWidth, settingsData.MainFormHeight);
                this.Location = new Point(settingsData.MainFormX, settingsData.MainFormY);
            }

            contextMenuStrip.Items.Add(openFolderEditMenuItem);
            contextMenuStrip.Items.Add(pathToClipboardEditMenuItem);
            contextMenuStrip.Items.Add(imageToClipboardEditMenuItem);
            contextMenuStrip.Items.Add(moveImageToClipboardEditMenuItem);
            contextMenuStrip.Items.Add(deleteImageEditMenuItem);
            pictureBoxWithImageChanged.ContextMenuStrip = contextMenuStrip;
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                settingsData.IsMainFormMaximize = true;

                settingsData.MainFormX = 0;
                settingsData.MainFormY = 0;
                settingsData.MainFormWidth = 0;
                settingsData.MainFormHeight = 0;
            }
            else
            {
                settingsData.IsMainFormMaximize = false;

                settingsData.MainFormX = this.Location.X;
                settingsData.MainFormY = this.Location.Y;
                settingsData.MainFormWidth = this.Size.Width;
                settingsData.MainFormHeight = this.Size.Height;
            }

            SettingsDataProcess.SaveSettingsData(settingsData);
        }

        private void PictureBoxWithImagePath_Click(object sender, EventArgs e)
        {
            if (currentBoxWithImagePath != null)
            {
                currentBoxWithImagePath.BorderStyle = BorderStyle.None;
            }
            currentBoxWithImagePath = ((PictureBoxWithImagePath)sender);
            currentBoxWithImagePath.BorderStyle = BorderStyle.Fixed3D;
            String imagePath = currentBoxWithImagePath.ImagePath;
            toolStripStatusLabel.Text = imagePath;
            try
            {
                if (pictureBoxWithImageChanged.Image != null)
                {
                    pictureBoxWithImageChanged.Image.Dispose();
                }

                pictureBoxWithImageChanged.Image = Image.FromFile(imagePath);
            }
            catch (FileNotFoundException)
            {
                RemoveDataLostFile();
            }
        }

        private void NewSearchFileMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            searchForm = new SearchForm(this);
            searchForm.ShowDialog();
        }

        private void DeleteImageEditMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = currentBoxWithImagePath.ImagePath;

            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(this, "Удалить файл текущего изображения?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        pictureBoxWithImageChanged.Image.Dispose();
                        pictureBoxWithImageChanged.Image = null;
                        File.Delete(filePath);
                        MessageBox.Show(this, "Файл изображения успешно удалён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flowLayoutPanel.Controls.Remove(currentBoxWithImagePath);
                        currentBoxWithImagePath = null;
                        toolStripStatusLabel.Text = "";
                    }
                    catch (IOException)
                    {
                        PictureBoxWithImagePath_Click(currentBoxWithImagePath, new EventArgs());
                        MessageBox.Show(this, "Невозможно удалить файл изображения, так как он занят другим процессом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        PictureBoxWithImagePath_Click(currentBoxWithImagePath, new EventArgs());
                        MessageBox.Show(this, "Невозможно удалить файл изображения, по данному пути отказано в доступе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                RemoveDataLostFile();
            }
        }

        private void OpenFolderEditMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = currentBoxWithImagePath.ImagePath;

            if (File.Exists(filePath))
            {
                Process.Start("explorer.exe", String.Concat("/select, ", filePath));
            }
            else
            {
                RemoveDataLostFile();
            }
        }

        private void PathToClipboardEditMenuItem1_Click(object sender, EventArgs e)
        {
            String filePath = currentBoxWithImagePath.ImagePath;

            if (File.Exists(filePath))
            {
                Clipboard.SetText(filePath);
            }
            else
            {
                RemoveDataLostFile();
            }
        }

        private void ImageToClipboardEditMenuItem1_Click(object sender, EventArgs e)
        {
            String filePath = currentBoxWithImagePath.ImagePath;

            if (File.Exists(filePath))
            {
                StringCollection stringCollection = new StringCollection();
                stringCollection.Add(filePath);
                Clipboard.SetFileDropList(stringCollection);
            }
            else
            {
                RemoveDataLostFile();
            }
        }

        private void MoveEditMenuItem1_Click(object sender, EventArgs e)
        {
            String filePath = currentBoxWithImagePath.ImagePath;

            if (File.Exists(filePath))
            {
                DialogResult dialogResult = MessageBox.Show(this,
                    "Переместить файл изображения не удастся, если он заблокирован другим приложением или диск защищён от записи.\n\nПродолжить?",
                    "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    pictureBoxWithImageChanged.Image.Dispose();
                    pictureBoxWithImageChanged.Image = null;
                    flowLayoutPanel.Controls.Remove(currentBoxWithImagePath);
                    currentBoxWithImagePath = null;
                    toolStripStatusLabel.Text = "";

                    byte[] moveEffect = new byte[] { 2, 0, 0, 0 };
                    MemoryStream dropEffect = new MemoryStream();
                    dropEffect.Write(moveEffect, 0, moveEffect.Length);

                    StringCollection stringCollection = new StringCollection();
                    stringCollection.Add(filePath);

                    DataObject data = new DataObject();
                    data.SetFileDropList(stringCollection);
                    data.SetData("Preferred DropEffect", dropEffect);

                    Clipboard.SetDataObject(data, true);
                }
            }
            else
            {
                RemoveDataLostFile();
            }
        }
    }
}
