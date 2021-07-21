using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BrowserAllImages
{
    class PictureBoxWithImageChanged : PictureBox
    {
        public event EventHandler ImageChanged;

        public Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                base.Image = value;
                this.ImageChanged(this, new EventArgs());
            }
        }

    }
}
