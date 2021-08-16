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
            mainLists.Add(new List<bool> { false, false, false, false, true, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        }

        private Bitmap ImageCreater()
        {
            // x, y
            //this.updateBmp = new Bitmap(squareWidth * mainLists[0].Count, squareHight * mainLists.Count);
            this.updateBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics g = Graphics.FromImage(updateBmp);

            // 要素へのアクセスの仕方
            //Console.WriteLine(mainLists[2][2]);

            for (int i = 0; i < mainLists.Count; i++)
            {
                for (int j = 0; j < mainLists[i].Count; j++)
                {
                    if (!mainLists[i][j])
                    {
                        g.FillRectangle(Brushes.Black, squareWidth * j, squareHight * i, squareWidth, squareHight);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, squareWidth * j, squareHight * i, squareWidth, squareHight);
                    }
                }
            }
            return updateBmp;
        }

        private List<List<bool>> ListCreater()
        {
            var nextList = mainLists;

            // 四隅のセルについての処理
            {
                // 一行目のセル
                // if (mainLists[0])
                {
                    // 右上のセル
                    //if (mainLists[0][0])
                    {
                        var rtCells = new List<bool> { mainLists[0][mainLists[0].Count - 1 - 1], mainLists[0 + 1][mainLists[0 + 1].Count - 1 - 1], mainLists[0 + 1][mainLists[0 + 1].Count - 1] };
                        var rtCellsBool = rtCells.Where(x => x == true).ToList().Count;
                        nextList[0][0] = CellJudgement(mainLists[0][0], rtCellsBool);
                    }
                    // 左上のセル
                    //if (mainLists[0][mainLists[0].Count - 1])
                    {
                        var ltCells = new List<bool> { mainLists[0][mainLists[0].Count - 1 - 1], mainLists[0 + 1][mainLists[0].Count - 1 - 1], mainLists[+1][mainLists[0].Count - 1] };
                        var ltCellsBool = ltCells.Where(x => x == true).ToList().Count;
                        nextList[0][mainLists[0].Count - 1] = CellJudgement(mainLists[0][mainLists[0].Count - 1], ltCellsBool);
                    }
                }
                //// 最後の行のセル
                //// if (mainLists[mainLists.Count -1])
                {
                    //    // 右下のセル
                    //    if (mainLists[mainLists.Count -1][0])
                    {
                        var rbCells = new List<bool> { mainLists[mainLists.Count - 1 - 1][0], mainLists[mainLists.Count - 1 - 1][0 + 1], mainLists[mainLists.Count - 1][0 + 1] };
                        var rbCellsBool = rbCells.Where(x => x == true).ToList().Count;
                        nextList[mainLists.Count - 1][0] = CellJudgement(mainLists[mainLists.Count - 1][0], rbCellsBool);
                    }
                    //    // 右上のセル
                    //    if (mainLists[mainLists.Count -1][mainLists[mainLists.Count -1].Count -1])
                    {
                        var lbCells = new List<bool> { mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1 - 1], mainLists[mainLists.Count - 1 - 1][mainLists[mainLists.Count - 1 - 1].Count - 1 - 1], mainLists[mainLists.Count - 1 - 1][mainLists[mainLists.Count - 1 - 1].Count - 1] };
                        var lbCellsBool = lbCells.Where(x => x == true).ToList().Count;
                        nextList[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1] = CellJudgement(mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1], lbCellsBool);
                    }
                }
            }

            //// 外側のセルについて
            //for (int i = 1; i < mainLists.Count; i++)
            //{
            //    // 一行目のセルについての処理
            //    if (mainLists[i][0])
            //    {
            //        if (mainLists[i - 1][mainLists.Count] && mainLists[i - 1][mainLists.Count + 1] && mainLists[i][mainLists.Count + 1] && mainLists[i + 1][mainLists.Count + 1] && mainLists[i + 1][mainLists.Count])
            //        {
            //            nextList[i][0] = true;
            //        }
            //    }
            //    // 最後の行のセルについての処理
            //    // 最初の列のセルについての処理
            //    // 最後の列のセルについての処理
            //}

            // 内側のセルについての処理
            for (int i = 1; i < mainLists.Count - 1 - 1; i++)
            {
                for (int j = 1; j < mainLists[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { mainLists[i - 1][mainLists[j - 1].Count - 1 - 1], mainLists[i][j - 1], mainLists[i - 1][j + 1], mainLists[i][j + 1], mainLists[i + 1][j + 1], mainLists[i + 1][j], mainLists[i + 1][j - 1], mainLists[i - 1][j - 1], };
                    var ijCellsBool = ijCells.Where(x => x == true).ToList().Count;
                    nextList[i][j] = CellJudgement(mainLists[i][j], ijCellsBool);
                }
            }
            return nextList;
        }
    
        private bool CellJudgement(bool myselfBool, int cellsBool)
        {
            if (!myselfBool)
            {
                // 誕生
                if (cellsBool == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // 生存
                if (cellsBool == 2 || cellsBool == 3)
                {
                    return true;
                }
                // 過疎
                // 過密
                else if (cellsBool <= 1 || cellsBool >= 4)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            mainLists = ListCreater();
            displayBmp = ImageCreater();
            this.pictureBox1.Image = this.displayBmp;
        }
    }
}
