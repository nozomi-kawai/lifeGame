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
using LifeGame;

namespace LifeGame
{
    public partial class Form1 : Form
    {
        private Bitmap displayBmp;
        private Bitmap updateBmpA;
        private Bitmap updateBmpB;
        private int squareWidth = 20;
        private int squareHight = 20;
        private int imageCellWidth = 20;
        private int imageCellHight = 20;
        private List<List<bool>> mainList = new List<List<bool>>();
        private ListCreater listCreater = new ListCreater();

        public Form1()
        {
            InitializeComponent();
            InitLists();
            listCreater.InitListCreater(mainList);
            this.updateBmpA = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            this.updateBmpB = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            displayBmp = CreateImage(this.updateBmpA);
            this.pictureBox1.Image = this.displayBmp;
            this.ImageUpdateTimer.Start();
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            mainList = listCreater.ListChange();
            if (this.pictureBox1.Image == this.updateBmpA)
            {
                displayBmp = CreateImage(this.updateBmpB);
            }
            else
            {
                displayBmp = CreateImage(this.updateBmpA);
            }
            this.pictureBox1.Image = this.displayBmp;
        }
    }
}
