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
            displayBmp = CreateImage(this.updateBmpA);
            this.pictureBox1.Image = this.displayBmp;
            this.ImageUpdateTimer.Start();
        }

        //private void InitLists()
        //{
        //    // 初期値を入れる
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //    mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        //}

        private void InitLists()
        {
            // 初期値を入れる
            mainLists.Add(new List<bool> { true,  true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false,  false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            mainLists.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        }

        private Bitmap CreateImage(Bitmap updateBmp)
        {

            Graphics g = Graphics.FromImage(updateBmp);

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

        /// <summary>
        /// 一行目の四隅のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateTopRowCornerCell(List<List<bool>> nextList)
        {
            // if (mainLists[0])
            {
                // 左上のセル
                //if (mainLists[0][0])
                {
                    var ltCells = new List<bool> {                      mainLists[0][0 + 1],
                                                    mainLists[0 + 1][0], mainLists[0 + 1][0 + 1] };
                    var ltCellsBool = ltCells.Where(x => x == true).ToList().Count;
                    nextList[0][0] = JudgementCell(mainLists[0][0], ltCellsBool);
                }
                // 右上のセル
                //if (mainLists[0][mainLists[0 + 1].Count - 1])
                {
                    var rtCells = new List<bool> { mainLists[0][mainLists[0].Count - 1 - 1],
                                                    mainLists[0 + 1][mainLists[0 + 1].Count - 1 - 1], mainLists[0 + 1][mainLists[0 + 1].Count - 1] };
                    var rtCellsBool = rtCells.Where(x => x == true).ToList().Count;
                    nextList[0][mainLists[0 + 1].Count - 1] = JudgementCell(mainLists[0][mainLists[0 + 1].Count - 1], rtCellsBool);
                }
            }
            return nextList;
        }

        /// <summary>
        /// 最後の行の四隅のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateBottomRowCornerCell(List<List<bool>> nextList)
        {
            // if (mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1])
            {
                // 右下のセル
                //    if (mainLists[mainLists.Count -1][mainLists[mainLists.Count -1].Count -1])
                {
                    var lbCells = new List<bool> { mainLists[mainLists.Count - 1 - 1][mainLists[mainLists.Count - 1 - 1].Count - 1 - 1], mainLists[mainLists.Count - 1 - 1][mainLists[mainLists.Count - 1 - 1].Count - 1],
                                                    mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1 -1] };
                    var lbCellsBool = lbCells.Where(x => x == true).ToList().Count;
                    nextList[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1] = JudgementCell(mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1], lbCellsBool);
                }
                // 左下のセル
                //    if (mainLists[mainLists.Count -1][0])
                {
                    var rbCells = new List<bool> { mainLists[mainLists.Count - 1 - 1][0], mainLists[mainLists.Count - 1 - 1][0 + 1],
                                                                                            mainLists[mainLists.Count - 1][0 + 1] };
                    var rbCellsBool = rbCells.Where(x => x == true).ToList().Count;
                    nextList[mainLists.Count - 1][0] = JudgementCell(mainLists[mainLists.Count - 1][0], rbCellsBool);
                }
            }
            return nextList;
        }

        /// <summary>
        /// 四隅のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateCornerCell(List<List<bool>> nextList)
        {
            nextList = CreateTopRowCornerCell(nextList);
            nextList = CreateBottomRowCornerCell(nextList);
            return nextList;
        }

        /// <summary>
        /// 外側の行のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideRowCell(List<List<bool>> nextList)
        {
            for (int j = 1; j < mainLists[0].Count - 1 - 1; j++)
            {
                // 一行目のセルについての処理
                //if (mainLists[0][j])
                {
                    var topRowCells = new List<bool>{ mainLists[0][j - 1],                          mainLists[0][j + 1],
                                                      mainLists[0 + 1][j - 1], mainLists[0 + 1][j], mainLists[0 + 1][j + 1] };
                    var topRowCellsBool = topRowCells.Where(x => x == true).ToList().Count;
                    nextList[0][j] = JudgementCell(mainLists[0][j], topRowCellsBool);
                }
                // 最後の行のセルについての処理
                //if (mainLists[(mainLists.Count -1][j])
                {
                    var bottomRowCells = new List<bool> { mainLists[mainLists.Count - 1 -1][j - 1], mainLists[mainLists.Count - 1 - 1][j], mainLists[mainLists.Count - 1 - 1][j + 1],
                                                          mainLists[mainLists.Count - 1][j - 1],                                           mainLists[mainLists.Count - 1][j + 1] };
                    var bottomRowCellsBool = bottomRowCells.Where(x => x == true).ToList().Count;
                    nextList[mainLists.Count - 1][j] = JudgementCell(mainLists[mainLists.Count - 1][j], bottomRowCellsBool);
                }
            }
            return nextList;
        }

        /// <summary>
        /// 外側の列のセルのついての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideColumnCell(List<List<bool>> nextList)
        {
            // 
            for (int i = 1; i < mainLists.Count - 1 - 1; i++)
            {
                // 最初の列のセルについての処理
                //if (mainLists[i][0])
                {
                    var leftColumnCells = new List<bool> { mainLists[i - 1][0], mainLists[i - 1][0 + 1],
                                                                                mainLists[i][0 + 1],
                                                           mainLists[i + 1][0], mainLists[i + 1][0 + 1]};
                    var leftColumnCellsBool = leftColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][0] = JudgementCell(mainLists[i][0], leftColumnCellsBool);
                }
                // 最後の列のセルについての処理
                //if (mainLists[i][mainLists[i].Count - 1])
                {
                    var rightColumnCells = new List<bool> { mainLists[i - 1][mainLists[i - 1].Count - 1 - 1], mainLists[i - 1][mainLists[i - 1].Count - 1],
                                                            mainLists[i][mainLists[i].Count - 1 - 1],
                                                            mainLists[i + 1][mainLists[i + 1].Count - 1 - 1], mainLists[i + 1][mainLists[i + 1].Count - 1] };
                    var rightColumnCellsBool = rightColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][0] = JudgementCell(mainLists[i][0], rightColumnCellsBool);
                }
            }
            return nextList;
        }

        /// <summary>
        /// 外側のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideCell(List<List<bool>> nextList)
        {
            nextList = CreateOutsideRowCell(nextList);
            nextList = CreateOutsideColumnCell(nextList);

            return nextList;
        }

        /// <summary>
        /// 内側のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateCenterCell(List<List<bool>> nextList)
        {
            for (int i = 1; i < mainLists.Count - 1 - 1; i++)
            {
                for (int j = 1; j < mainLists[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { mainLists[i - 1][j - 1], mainLists[i - 1][j],     mainLists[i - 1][j + 1],
                                                   mainLists[i][j - 1],                              mainLists[i][j + 1],
                                                   mainLists[i + 1][j - 1], mainLists[i + 1][j],     mainLists[i + 1][j + 1] };
                    var ijCellsBool = ijCells.Where(x => x == true).ToList().Count;
                    nextList[i][j] = JudgementCell(mainLists[i][j], ijCellsBool);
                }
            }
            return nextList;
        }

        private List<List<bool>> CreateList()
        {
            List<List<bool>> nextList = new List<List<bool>>(mainLists.Count);
            for (int i = 0; i < mainLists.Count; i++)
            {
                var row = Enumerable.Range(0, mainLists.Count).Select(x => false).ToList();
                nextList.Add(row);
            }

            nextList = CreateCornerCell(nextList);
            nextList = CreateOutsideCell(nextList);
            nextList = CreateCenterCell(nextList);

            return nextList;
        }

        private bool JudgementCell(bool myselfBool, int cellsBool)
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
            this.mainLists = CreateList();
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
