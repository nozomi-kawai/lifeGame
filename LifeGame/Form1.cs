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
        private int squareWidth = 20;
        private int squareHight = 20;
        private int count = 0;
        private List<List<bool>> mainLists = new List<List<bool>>();

        public Form1()
        {
            InitializeComponent();
            InitLists();
            ImageCreater();
            this.ImageUpdateTimer.Start();

        }

        private void InitLists()
        {
            // 初期値を入れる
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, true, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        }

        private Bitmap ImageCreater()
        {
            // x, y
            this.updateBmp = new Bitmap(squareWidth * mainLists[0].Count, squareHight * mainLists.Count);

            Graphics g = Graphics.FromImage(updateBmp);

            //// 要素へのアクセスの仕方
            //Console.WriteLine(mainLists[2][2]);

            for (int i = 0; i < mainLists.Count; i++)
            {
                for (int j = 0; j < mainLists[i].Count; j++)
                {
                    if (!mainLists[i][j])
                    {
                        g.FillRectangle(Brushes.Black, squareHight * j, squareWidth * i, squareWidth, squareHight);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, squareHight * j, squareWidth * i, squareWidth, squareHight);
                    }
                }
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
