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
        private Bitmap displayBmp;
        private Bitmap updateBmp;
        private int count = 0;
        private List<List<bool>> mainList = new List<List<bool>>();

        public Form1()
        {
            InitializeComponent();
            ImageCreater();
            this.ImageUpdateTimer.Start();
        }

        private Bitmap ImageCreater()
        {
            this.updateBmp = new Bitmap(100, 100);

            Graphics g = Graphics.FromImage(updateBmp);

            if ( count % 2 == 0 )
            {
                g.FillRectangle(Brushes.Black, 10, 10, updateBmp.Width - 90, updateBmp.Height - 90);
            }
            else
            {
                g.FillRectangle(Brushes.White, 10, 20, updateBmp.Width - 90, updateBmp.Height - 90);
            }

            this.count++;
            return updateBmp;
        }

        private List<List<bool>> ListCreater()
        {
            var retList = new List<List<bool>>();
            return retList;
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            displayBmp = ImageCreater();
            this.pictureBox1.Image = this.displayBmp;
        }
    }
}
