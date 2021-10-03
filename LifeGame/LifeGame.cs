using System;
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
                this.SettingLifeGameParam(cellCountWidth, cellCountHeight, cellWidth, cellHeight);
                InitLists(this.displayList);
                InitLists(this.updateList);
            }
            else
            {
                this.SettingLifeGameParam(20, 20, 20, 20);
                this.debugInitList(this.displayList);
                this.debugInitList(this.updateList);
            }
        }

        public void SettingLifeGameParam(int cellCountWidth, int cellCountHeight, int cellWidth, int cellHeight)
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

        private List<List<bool>> JudgementAroundCell(List<List<bool>> updateList)
        {
            int bkRow;
            int nextRow;
            int bkColumn;
            int nextColumn;

            for (int r = 0; r <= this.displayList.Count - 1; r++)
            {
                // Row
                if (r == 0)
                {
                    bkRow = this.displayList.Count - 1;
                    nextRow = 1;
                }
                else if (r == this.displayList.Count - 1)
                {
                    bkRow = this.displayList.Count - 1 - 1;
                    nextRow = 0;
                }
                else
                {
                    bkRow = r - 1;
                    nextRow = r + 1;
                }

                for (int c = 1; c < displayList[r].Count- 1; c++)
                {
                    // Column
                    if (c == 0)
                    {
                        bkColumn = this.displayList[r].Count - 1;
                        nextColumn = 1;
                    }
                    else if (c == this.displayList[r].Count - 1)
                    {
                        bkColumn = this.displayList[r].Count - 1 - 1;
                        nextColumn = 0;
                    }
                    else
                    {
                        bkColumn = c - 1;
                        nextColumn = c + 1;
                    }

                    var rcCells = new List<bool> { this.displayList[bkRow][bkColumn],   this.displayList[bkRow][c],   this.displayList[bkRow][nextColumn],
                                                   this.displayList[r][bkColumn],                                     this.displayList[r][nextColumn],
                                                   this.displayList[nextRow][bkColumn], this.displayList[nextRow][c], this.displayList[nextRow][nextColumn] };
                    var rcCellsBool = rcCells.Where(x => x == true).ToList().Count;
                    updateList[r][c] = JudgementCell(displayList[r][c], rcCellsBool);
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
            updateList = JudgementAroundCell(updateList);

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
