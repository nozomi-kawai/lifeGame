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

        // セルのサイズ
        private int cellWidth;
        private int cellHight;
        // セルの数
        private int cellCountWidth;
        private int cellCountHight;

        public LifeGame(int cellCountWidth_ = 20, int cellCountHight_ = 20, int cellWidth_ = 20, int cellHight_ = 20)
        {
            LifeGameSetting(cellCountWidth_, cellCountHight_, cellWidth_, cellHight_);
        }

        private void LifeGameSetting(int cellCountWidth_, int cellCountHight_, int cellWidth_, int cellHight_)
        {
            this.cellWidth = cellWidth_;
            this.cellHight = cellHight_;
            this.cellCountWidth = cellCountWidth_;
            this.cellCountHight = cellCountHight_;
        }

        public Bitmap Init()
        {
            this.InitLists(displayList);
            this.InitLists(updateList);
            return this.InitImages();
        }

        private void InitLists(List<List<bool>> initList_)
        {
            // 初期値を入れる
            for (int i = 0; i < cellCountHight; i++)
            {
                var listRow = new List<bool>();
                for (int j = 0; j < cellCountWidth; j++)
                {
                    listRow.Add(false);
                }
                initList_.Add(listRow);
            }
        }

        private Bitmap InitImages()
        {
            this.displayBmp = new Bitmap(this.cellCountWidth * this.cellWidth, this.cellCountHight * this.cellHight);
            this.updateBmpA = new Bitmap(this.cellCountWidth * this.cellWidth, this.cellCountHight * this.cellHight);
            this.updateBmpB = new Bitmap(this.cellCountWidth * this.cellWidth, this.cellCountHight * this.cellHight);
            displayBmp = CreateImage(this.updateBmpA);
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
                    var ltCells = new List<bool> {                         displayList[0][0 + 1],
                                                    displayList[0 + 1][0], displayList[0 + 1][0 + 1] };
                    var ltCellsBool = ltCells.Where(x => x == true).ToList().Count;
                    updateList[0][0] = JudgementCell(displayList[0][0], ltCellsBool);
                }
                // 右上のセル
                // updateList[0][updateList[0].Count - 1]
                {
                    var rtCells = new List<bool> { displayList[0][displayList[0].Count - 1 - 1],
                                                   displayList[0 + 1][displayList[0 + 1].Count - 1 - 1], displayList[0 + 1][displayList[0 + 1].Count - 1] };
                    var rtCellsBool = rtCells.Where(x => x == true).ToList().Count;
                    updateList[0][displayList[0].Count - 1] = JudgementCell(displayList[0][displayList[0].Count - 1], rtCellsBool);
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
                    var lbCells = new List<bool> { displayList[displayList.Count - 1 - 1][0], displayList[displayList.Count - 1 - 1][0 + 1],
                                                                                              displayList[displayList.Count - 1][0 + 1] };
                    var lbCellsBool = lbCells.Where(x => x == true).ToList().Count;
                    updateList[displayList.Count - 1][0] = JudgementCell(displayList[displayList.Count - 1][0], lbCellsBool);
                }
                // 右下のセル
                // updateList[updateList.Count -1][updateList[updateList.Count -1].Count -1]
                {
                    var rlbCells = new List<bool> { displayList[displayList.Count - 1 - 1][displayList[displayList.Count - 1 - 1].Count - 1 - 1], displayList[displayList.Count - 1 - 1][displayList[displayList.Count - 1 - 1].Count - 1],
                                                    displayList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1 - 1] };
                    var rbCellsBool = rlbCells.Where(x => x == true).ToList().Count;
                    updateList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1] = JudgementCell(displayList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1], rbCellsBool);
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
            for (int j = 1; j < displayList[0].Count - 1 - 1; j++)
            {
                // 一行目のセルについての処理
                // updateList[0][j]
                {
                    var topRowCells = new List<bool>{ displayList[0][j - 1],                            displayList[0][j + 1],
                                                      displayList[0 + 1][j - 1], displayList[0 + 1][j], displayList[0 + 1][j + 1] };
                    var topRowCellsBool = topRowCells.Where(x => x == true).ToList().Count;
                    updateList[0][j] = JudgementCell(displayList[0][j], topRowCellsBool);
                }
                // 最後の行のセルについての処理
                // updateList[(updateList.Count -1][j]
                {
                    var bottomRowCells = new List<bool> { displayList[displayList.Count - 1 -1][j - 1], displayList[displayList.Count - 1 - 1][j], displayList[displayList.Count - 1 - 1][j + 1],
                                                          displayList[displayList.Count - 1][j - 1],                                               displayList[displayList.Count - 1][j + 1] };
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
            for (int i = 1; i < displayList.Count - 1 - 1; i++)
            {
                // 最初の列のセルについての処理
                // updateList[i][0]
                {
                    var leftColumnCells = new List<bool> { displayList[i - 1][0], displayList[i - 1][0 + 1],
                                                                                  displayList[i][0 + 1],
                                                           displayList[i + 1][0], displayList[i + 1][0 + 1]};
                    var leftColumnCellsBool = leftColumnCells.Where(x => x == true).ToList().Count;
                    updateList[i][0] = JudgementCell(displayList[i][0], leftColumnCellsBool);
                }
                // 最後の列のセルについての処理
                // updateList[i][updateList[i].Count - 1]
                {
                    var rightColumnCells = new List<bool> { displayList[i - 1][displayList[i - 1].Count - 1 - 1], displayList[i - 1][displayList[i - 1].Count - 1],
                                                            displayList[i][displayList[i].Count - 1 - 1],
                                                            displayList[i + 1][displayList[i + 1].Count - 1 - 1], displayList[i + 1][displayList[i + 1].Count - 1] };
                    var rightColumnCellsBool = rightColumnCells.Where(x => x == true).ToList().Count;
                    updateList[i][displayList[i].Count - 1] = JudgementCell(displayList[i][displayList[i].Count - 1], rightColumnCellsBool);
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
            for (int i = 1; i < displayList.Count - 1 - 1; i++)
            {
                for (int j = 1; j < displayList[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { displayList[i - 1][j - 1], displayList[i - 1][j], displayList[i - 1][j + 1],
                                                   displayList[i][j - 1],                            displayList[i][j + 1],
                                                   displayList[i + 1][j - 1], displayList[i + 1][j], displayList[i + 1][j + 1] };
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
                        g.FillRectangle(Brushes.Black, this.cellWidth * j, this.cellHight * i, this.cellWidth, this.cellHight);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, this.cellWidth * j, this.cellHight * i, this.cellWidth, this.cellHight);
                    }
                }
            }
            return updateBmp;
        }

        /// <summary>
        /// 新しいリストを作成して返す
        /// </summary>
        /// <returns>作成された新しいリスト</returns>
        private List<List<bool>> CreateList()
        {
            List<List<bool>> updateList = new List<List<bool>>(this.displayList.Count);
            for (int i = 0; i < displayList.Count; i++)
            {
                var row = Enumerable.Range(0, displayList.Count).Select(x => false).ToList();
                updateList.Add(row);
            }

            updateList = CreateCornerCell(updateList);
            updateList = CreateOutsideCell(updateList);
            updateList = CreateCenterCell(updateList);

            return updateList;
        }

        public Bitmap displayNext()
        {
            // リストを更新する
            this.updateList = this.CreateList();
            // 画像を更新する
            // 表示する画像を切り替える
            if (this.displayBmp == this.updateBmpA)
            {
                displayBmp = CreateImage(this.updateBmpB);
            }
            else
            {
                displayBmp = CreateImage(this.updateBmpA);
            }

            return this.displayBmp;
        }
    }
}
