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
        private List<List<bool>> mainList = new List<List<bool>>();

        public Form1()
        {
            InitializeComponent();
            ImageCreater();
            this.ImageUpdateTimer.Start();
        }

        private void ImageCreater()
        {
            this.bmpUpdate = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(bmpUpdate);

            if ( count % 2 == 0 )
            {
                g.FillRectangle(Brushes.Black, 10, 10, bmpUpdate.Width - 90, bmpUpdate.Height - 90);
            }
            else
            {
                g.FillRectangle(Brushes.White, 10, 20, bmpUpdate.Width - 90, bmpUpdate.Height - 90);
            }

            this.pictureBox1.Image = this.bmpUpdate;
            this.count++;

        }

        private List<List<bool>> ListCreater()
        {
            var retList = new List<List<bool>>();
            return retList;
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            ImageCreater();
        }
    }
}
