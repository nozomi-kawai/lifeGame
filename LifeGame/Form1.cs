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
        private Bitmap updateBmpA;
        private Bitmap updateBmpB;
        private int squareWidth = 20;
        private int squareHight = 20;
        private int imageCellWidth = 20;
        private int imageCellHight = 20;
        private List<List<bool>> mainLists = new List<List<bool>>();

        public Form1()
        {
            InitializeComponent();
            InitLists();
            this.updateBmpA = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            this.updateBmpB = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            displayBmp = ImageCreater(this.updateBmpA);
            this.pictureBox1.Image = this.displayBmp;
            this.ImageUpdateTimer.Start();
        }

        private void InitLists()
        {
            // 初期値を入れる
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        }

        private Bitmap ImageCreater(Bitmap updateBmp)
        {

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
            List<List<bool>> nextList = new List<List<bool>>();
            foreach (var item in mainLists)
            {
                nextList.Add(item);
            }

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

            // 外側のセルについて
            // 外側の行のセルについての処理
            for (int j = 1; j < mainLists[0].Count - 1 - 1; j++)
            {
                // 一行目のセルについての処理
                //if (mainLists[0][j])
                {
                    var topRowCells = new List<bool>{ mainLists[0][j - 1],                          mainLists[0][j + 1],
                                                      mainLists[0 + 1][j - 1], mainLists[0 + 1][j], mainLists[0 + 1][j + 1] };
                    var topRowCellsBool = topRowCells.Where(x => x == true).ToList().Count;
                    nextList[0][j] = CellJudgement(mainLists[0][j], topRowCellsBool);
                }
                // 最後の行のセルについての処理
                //if (mainLists[(mainLists.Count -1][j])
                {
                    var bottomRowCells = new List<bool> { mainLists[mainLists.Count - 1 -1][j - 1], mainLists[mainLists.Count - 1 - 1][j], mainLists[mainLists.Count - 1 - 1][j + 1],
                                                          mainLists[mainLists.Count - 1][j - 1],                                           mainLists[mainLists.Count - 1][j + 1] };
                    var bottomRowCellsBool = bottomRowCells.Where(x => x == true).ToList().Count;
                    nextList[mainLists.Count - 1][j] = CellJudgement(mainLists[mainLists.Count - 1][j], bottomRowCellsBool);
                }
            }
            // 外側の列のセルのついての処理
            for (int i = 1; i < mainLists.Count - 1 - 1; i++)
            {
                // 最初の列のセルについての処理
                //if (mainLists[i][0])
                {
                    var leftColumnCells = new List<bool> { mainLists[i - 1][0], mainLists[i - 1][0 + 1],
                                                                                mainLists[i][0 + 1],
                                                           mainLists[i + 1][0], mainLists[i + 1][0 + 1]};
                    var leftColumnCellsBool = leftColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][0] = CellJudgement(mainLists[i][0], leftColumnCellsBool);
                }
                // 最後の列のセルについての処理
                //if (mainLists[i][mainLists[i].Count - 1])
                {
                    var rightColumnCells = new List<bool> { mainLists[i - 1][mainLists[i - 1].Count - 1 - 1], mainLists[i - 1][mainLists[i - 1].Count - 1],
                                                            mainLists[i][mainLists[i].Count - 1 - 1],
                                                            mainLists[i + 1][mainLists[i + 1].Count - 1 - 1], mainLists[i + 1][mainLists[i + 1].Count - 1] };
                    var rightColumnCellsBool = rightColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][0] = CellJudgement(mainLists[i][0], rightColumnCellsBool);
                }
            }

            // 内側のセルについての処理
            for (int i = 1; i < mainLists.Count - 1 - 1; i++)
            {
                for (int j = 1; j < mainLists[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { mainLists[i - 1][j - 1], mainLists[i - 1][j],     mainLists[i - 1][j + 1],
                                                   mainLists[i][j - 1],                              mainLists[i][j + 1],
                                                   mainLists[i + 1][j - 1], mainLists[i + 1][j],     mainLists[i + 1][j + 1] };
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
                if (cellsBool == 3)
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
                // 過疎 || 過密
                else  // if (cellsBool <= 1 || cellsBool >= 4)
                {
                    return false;
                }
            }
        }

        private void ImageUpdateTimer_Tick(object sender, EventArgs e)
        {
            this.mainLists = ListCreater();
            this.pictureBox1.Image = this.displayBmp;
            if (this.pictureBox1.Image == this.updateBmpA)
            {
                displayBmp = ImageCreater(this.updateBmpB);
            }
            else
            {
                displayBmp = ImageCreater(this.updateBmpA);
            }
        }
    }
}
