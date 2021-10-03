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
        // セルの数
        private static int cellCountWidth = 30;
        private static int cellCountHeight = 30;
        // セルのサイズ
        // TODO セルのサイズは正方形がいい
        private static int cellWidth = 10;
        private static int cellHeight = 10;

        private static LifeGame lifeGame;

        private static bool debugMode = true;

        public Form1()
        {           
            InitializeComponent();
            lifeGame = new LifeGame(cellCountWidth, cellCountHeight, cellWidth, cellHeight, debugMode);
            this.pictureBox1.Image = lifeGame.Init();
            // タイマースタート
            this.ImageUpdateTimer.Start();
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = lifeGame.nextGeneration();
        }
    }
}
