using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CameraCapture
{
    public partial class ImageWindow : Form
    {
        public ImageWindow(Bitmap image, bool imageFit)
        {
            InitializeComponent();

            pictureBox.Image = image;
            pictureBox.Size = image.Size;

            // Resize window
            int newWidth = Math.Max(this.PreferredSize.Width, 305);
            int newHeight = Math.Max(this.PreferredSize.Height, 246);
            if (!imageFit)
            {
                newWidth = Math.Min(newWidth, Screen.PrimaryScreen.Bounds.Width * 2 / 3);
                newHeight = Math.Min(newHeight, Screen.PrimaryScreen.Bounds.Height * 2 / 3);
            }
            this.Size = new Size(newWidth, newHeight);
        }

        private void ImageWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
