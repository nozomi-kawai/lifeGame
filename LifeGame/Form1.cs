using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class Form1 : Form
    {
        private Bitmap bmpUpdate;
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
            ImageCreater();
            this.ImageUpdateTimer.Start();
        }

        private void ImageCreater()
        {
            this.bmpUpdate = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(bmpUpdate);

            if (this.count % 3 == 0)
            {
                g.FillRectangle(Brushes.White, 10, 20, bmpUpdate.Width - 20, bmpUpdate.Height - 40);
            }
            else if (this.count % 3 == 1)
            {
                g.FillRectangle(Brushes.Blue, 10, 20, bmpUpdate.Width - 20, bmpUpdate.Height - 40);
            }
            else if (this.count % 3 == 2)
            {
                g.FillRectangle(Brushes.Pink, 10, 20, bmpUpdate.Width - 20, bmpUpdate.Height - 40);
            }
            else
            {
                g.FillRectangle(Brushes.Black, 10, 20, bmpUpdate.Width - 20, bmpUpdate.Height - 40);
            }

            this.pictureBox1.Image = this.bmpUpdate;
            this.count++;

        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            ImageCreater();
        }
    }
}
