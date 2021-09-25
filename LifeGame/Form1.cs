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
        // 表示する画像
        private Bitmap displayBmp;
        // セルのサイズ
        private int squareWidth = 20;
        private int squareHight = 20;
        // セルの数
        private int imageCellWidth = 20;
        private int imageCellHight = 20;
        // 画像を作成するためのリスト
        private List<List<bool>> mainList = new List<List<bool>>();

        public Form1()
        {           
            InitializeComponent();
            // タイマースタート
            this.ImageUpdateTimer.Start();
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.displayBmp;
        }
    }
}
