﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeGame
{
    class LifeGame
    {
        // Bitmap描画用のList
        private List<List<bool>> displayList = new List<List<bool>>();
        private List<List<bool>> updateList = new List<List<bool>>();

        // 表示用のBitmap
        private Bitmap displayBmp;
        // 更新用のBitmap
        private Bitmap updateBmpA;
        private Bitmap updateBmpB;

        // セルの数
        private int cellCountWidth;
        private int cellCountHeight;

        // セルのサイズ
        private int cellWidth;
        private int cellHeight;

        public LifeGame(int cellCountWidth, int cellCountHeight, int cellWidth, int cellHeight, bool debugMode)
        {
            if (!debugMode)
            {
                this.LifeGameSetting(cellCountWidth, cellCountHeight, cellWidth, cellHeight);
                InitLists(this.displayList);
                InitLists(this.updateList);
            }
            else
            {
                this.LifeGameSetting(20, 20, 20, 20);
                this.debugInitList(this.displayList);
                this.debugInitList(this.updateList);
            }
        }

        public void LifeGameSetting(int cellCountWidth, int cellCountHeight, int cellWidth, int cellHeight)
        {
            this.cellCountWidth = cellCountWidth;
            this.cellCountHeight = cellCountHeight;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;
        }

        public Bitmap Init()
        {
            return this.InitImages();
        }

        private void InitLists(List<List<bool>> initList)
        {
            Random random = new System.Random();
            // 初期値を入れる
            for (int i = 0; i < this.cellCountHeight; i++)
            {
                var listRow = new List<bool>();
                for (int j = 0; j < this.cellCountWidth; j++)
                {
                    listRow.Add(random.Next(0, 2) == 0);
                }
                initList.Add(listRow);
            }
        }

        public void debugInitList(List<List<bool>> initList)
        {
            // 初期値を入れる
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            initList.Add(new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
        }

        private Bitmap InitImages()
        {
            this.updateBmpA = new Bitmap(this.cellCountWidth * this.cellWidth, this.cellCountHeight * this.cellHeight);
            this.updateBmpB = new Bitmap(this.cellCountWidth * this.cellWidth, this.cellCountHeight * this.cellHeight);
            this.displayBmp = CreateImage(this.updateBmpA);
            return displayBmp;
        }

        /// <summary>
        /// 一行目の四隅のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateTopRowCornerCell(List<List<bool>> updateList)
        {
            // updateList[0]
            {
                // 左上のセル
                // updateList[0][0]
                {
                    var ltCells = new List<bool> {                              this.displayList[0][0 + 1],
                                                    this.displayList[0 + 1][0], this.displayList[0 + 1][0 + 1] };
                    var ltCellsBool = ltCells.Where(x => x == true).ToList().Count;
                    updateList[0][0] = JudgementCell(this.displayList[0][0], ltCellsBool);
                }
                // 右上のセル
                // updateList[0][updateList[0].Count - 1]
                {
                    var rtCells = new List<bool> { this.displayList[0][this.displayList[0].Count - 1 - 1],
                                                   this.displayList[0 + 1][this.displayList[0 + 1].Count - 1 - 1], this.displayList[0 + 1][this.displayList[0 + 1].Count - 1] };
                    var rtCellsBool = rtCells.Where(x => x == true).ToList().Count;
                    updateList[0][this.displayList[0].Count - 1] = JudgementCell(this.displayList[0][this.displayList[0].Count - 1], rtCellsBool);
                }
            }
            return updateList;
        }

        /// <summary>
        /// 最後の行の四隅のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateBottomRowCornerCell(List<List<bool>> updateList)
        {
            // updateList[updateList.Count - 1][updateList[updateList.Count - 1].Count - 1]
            {
                // 左下のセル
                // updateList[updateList.Count -1][0]
                {
                    var lbCells = new List<bool> { this.displayList[this.displayList.Count - 1 - 1][0], this.displayList[this.displayList.Count - 1 - 1][0 + 1],
                                                                                                        this.displayList[this.displayList.Count - 1][0 + 1] };
                    var lbCellsBool = lbCells.Where(x => x == true).ToList().Count;
                    updateList[displayList.Count - 1][0] = JudgementCell(displayList[displayList.Count - 1][0], lbCellsBool);
                }
                // 右下のセル
                // updateList[updateList.Count -1][updateList[updateList.Count -1].Count -1]
                {
                    var rlbCells = new List<bool> { this.displayList[this.displayList.Count - 1 - 1][this.displayList[this.displayList.Count - 1 - 1].Count - 1 - 1], this.displayList[this.displayList.Count - 1 - 1][this.displayList[this.displayList.Count - 1 - 1].Count - 1],
                                                    this.displayList[this.displayList.Count - 1][this.displayList[this.displayList.Count - 1].Count - 1 - 1] };
                    var rbCellsBool = rlbCells.Where(x => x == true).ToList().Count;
                    updateList[this.displayList.Count - 1][this.displayList[this.displayList.Count - 1].Count - 1] = JudgementCell(this.displayList[this.displayList.Count - 1][this.displayList[this.displayList.Count - 1].Count - 1], rbCellsBool);
                }
            }
            return updateList;
        }

        /// <summary>
        /// 四隅のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateCornerCell(List<List<bool>> updateList)
        {
            updateList = CreateTopRowCornerCell(updateList);
            updateList = CreateBottomRowCornerCell(updateList);
            return updateList;
        }

        /// <summary>
        /// 外側の行のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideRowCell(List<List<bool>> updateList)
        {
            for (int j = 1; j < this.displayList[0].Count - 1 - 1; j++)
            {
                // 一行目のセルについての処理
                // updateList[0][j]
                {
                    var topRowCells = new List<bool>{ this.displayList[0][j - 1],                                 this.displayList[0][j + 1],
                                                      this.displayList[0 + 1][j - 1], this.displayList[0 + 1][j], this.displayList[0 + 1][j + 1] };
                    var topRowCellsBool = topRowCells.Where(x => x == true).ToList().Count;
                    updateList[0][j] = JudgementCell(this.displayList[0][j], topRowCellsBool);
                }
                // 最後の行のセルについての処理
                // updateList[(updateList.Count -1][j]
                {
                    var bottomRowCells = new List<bool> { this.displayList[displayList.Count - 1 - 1][j - 1], this.displayList[displayList.Count - 1 - 1][j], this.displayList[displayList.Count - 1 - 1][j + 1],
                                                          this.displayList[displayList.Count - 1][j - 1],                                                     this.displayList[displayList.Count - 1][j + 1] };
                    var bottomRowCellsBool = bottomRowCells.Where(x => x == true).ToList().Count;
                    updateList[displayList.Count - 1][j] = JudgementCell(displayList[displayList.Count - 1][j], bottomRowCellsBool);
                }
            }
            return updateList;
        }

        /// <summary>
        /// 外側の列のセルのついての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideColumnCell(List<List<bool>> updateList)
        {
            // 
            for (int i = 1; i < this.displayList.Count - 1 - 1; i++)
            {
                // 最初の列のセルについての処理
                // updateList[i][0]
                {
                    var leftColumnCells = new List<bool> { this.displayList[i - 1][0], this.displayList[i - 1][0 + 1],
                                                                                       this.displayList[i][0 + 1],
                                                           this.displayList[i + 1][0], this.displayList[i + 1][0 + 1]};
                    var leftColumnCellsBool = leftColumnCells.Where(x => x == true).ToList().Count;
                    updateList[i][0] = JudgementCell(this.displayList[i][0], leftColumnCellsBool);
                }
                // 最後の列のセルについての処理
                // updateList[i][updateList[i].Count - 1]
                {
                    var rightColumnCells = new List<bool> { this.displayList[i - 1][this.displayList[i - 1].Count - 1 - 1], this.displayList[i - 1][this.displayList[i - 1].Count - 1],
                                                            this.displayList[i][this.displayList[i].Count - 1 - 1],
                                                            this.displayList[i + 1][this.displayList[i + 1].Count - 1 - 1], this.displayList[i + 1][this.displayList[i + 1].Count - 1] };
                    var rightColumnCellsBool = rightColumnCells.Where(x => x == true).ToList().Count;
                    updateList[i][this.displayList[i].Count - 1] = JudgementCell(this.displayList[i][this.displayList[i].Count - 1], rightColumnCellsBool);
                }
            }
            return updateList;
        }

        /// <summary>
        /// 外側のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateOutsideCell(List<List<bool>> updateList)
        {
            updateList = CreateOutsideRowCell(updateList);
            updateList = CreateOutsideColumnCell(updateList);

            return updateList;
        }

        /// <summary>
        /// 内側のセルについての処理
        /// </summary>
        /// <param name="updateList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateCenterCell(List<List<bool>> updateList)
        {
            for (int i = 1; i < this.displayList.Count - 1 - 1; i++)
            {
                for (int j = 1; j < displayList[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { this.displayList[i - 1][j - 1], this.displayList[i - 1][j], this.displayList[i - 1][j + 1],
                                                   this.displayList[i][j - 1],                                 this.displayList[i][j + 1],
                                                   this.displayList[i + 1][j - 1], this.displayList[i + 1][j], this.displayList[i + 1][j + 1] };
                    var ijCellsBool = ijCells.Where(x => x == true).ToList().Count;
                    updateList[i][j] = JudgementCell(displayList[i][j], ijCellsBool);
                }
            }
            return updateList;
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

        private Bitmap CreateImage(Bitmap updateBmp)
        {

            Graphics g = Graphics.FromImage(updateBmp);

            for (int i = 0; i < updateList.Count; i++)
            {
                for (int j = 0; j < updateList[i].Count; j++)
                {
                    if (!updateList[i][j])
                    {
                        g.FillRectangle(Brushes.Black, this.cellWidth * j, this.cellHeight * i, this.cellWidth, this.cellHeight);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, this.cellWidth * j, this.cellHeight * i, this.cellWidth, this.cellHeight);
                    }
                }
            }
            return updateBmp;
        }

        /// <summary>
        /// 新しいリストを作成して返す
        /// </summary>
        /// <returns>作成された新しいリスト</returns>
        private List<List<bool>> CreateList(List<List<bool>> updateList)
        {
            updateList = CreateCornerCell(updateList);
            updateList = CreateOutsideCell(updateList);
            updateList = CreateCenterCell(updateList);

            return updateList;
        }

        private List<List<bool>> updateDisplayList()
        {
            for (int r = 0; r < this.displayList.Count; r++)
            {
                for (int c = 0; c < this.displayList[r].Count; c++)
                {
                    this.displayList[r][c] = this.updateList[r][c];
                }
            }
            return this.displayList;
        }

        public Bitmap nextGeneration()
        {
            // リストを更新する
            this.updateList = this.CreateList(this.updateList);
            // displayListもupdateList更新後に更新してあげないといけない
            this.displayList = updateDisplayList();
            // 画像を更新する
            // 表示する画像を切り替える
            if (this.displayBmp == this.updateBmpA)
            {
                this.displayBmp = CreateImage(this.updateBmpB);
            }
            else
            {
                this.displayBmp = CreateImage(this.updateBmpA);
            }
            
            return this.displayBmp;
        }
    }
}
