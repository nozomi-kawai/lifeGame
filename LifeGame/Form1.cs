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
        // セルの数
        private static int cellCountWidth = 20;
        private static int cellCountHight = 20;
        // セルのサイズ
        private static int cellWidth = 20;
        private static int cellHight = 20;

        private static LifeGame lifeGame = new LifeGame(
            cellCountWidth, cellCountHight, cellWidth, cellHight);


        public Form1()
        {           
            InitializeComponent();
            this.pictureBox1.Image = lifeGame.Init();
            // タイマースタート
            this.ImageUpdateTimer.Start();
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = lifeGame.displayNext();
        }
    }
}
