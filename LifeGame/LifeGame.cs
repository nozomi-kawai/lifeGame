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
        private List<List<bool>> displayList;
        private List<List<bool>> updateList;
        private Bitmap displayBmp;
        private Bitmap updateBmp;

        public void InitListCreater(List<List<bool>> mainList_)
        {
            this.updateList = mainList_;
        }

        private void InitLists()
        {
            // 初期値を入れる
            var listRow = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }
            updateList.Add(listRow);
        }

        /// <summary>
        /// 一行目の四隅のセルについての処理
        /// </summary>
        /// <param name="nextList">変更するリスト</param>
        /// <returns>変更済みのリスト</returns>
        private List<List<bool>> CreateTopRowCornerCell(List<List<bool>> nextList)
        {
            // mainLists[0]
            {
                // 左上のセル
                // mainLists[0][0]
                {
                    var ltCells = new List<bool> {                         displayList[0][0 + 1],
                                                    displayList[0 + 1][0], displayList[0 + 1][0 + 1] };
                    var ltCellsBool = ltCells.Where(x => x == true).ToList().Count;
                    nextList[0][0] = JudgementCell(displayList[0][0], ltCellsBool);
                }
                // 右上のセル
                // mainLists[0][mainLists[0].Count - 1]
                {
                    var rtCells = new List<bool> { displayList[0][displayList[0].Count - 1 - 1],
                                                    displayList[0 + 1][displayList[0 + 1].Count - 1 - 1], displayList[0 + 1][displayList[0 + 1].Count - 1] };
                    var rtCellsBool = rtCells.Where(x => x == true).ToList().Count;
                    nextList[0][displayList[0].Count - 1] = JudgementCell(displayList[0][displayList[0].Count - 1], rtCellsBool);
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
            // mainLists[mainLists.Count - 1][mainLists[mainLists.Count - 1].Count - 1]
            {
                // 左下のセル
                // mainLists[mainLists.Count -1][0]
                {
                    var lbCells = new List<bool> { displayList[displayList.Count - 1 - 1][0], displayList[displayList.Count - 1 - 1][0 + 1],
                                                                                              displayList[displayList.Count - 1][0 + 1] };
                    var lbCellsBool = lbCells.Where(x => x == true).ToList().Count;
                    nextList[displayList.Count - 1][0] = JudgementCell(displayList[displayList.Count - 1][0], lbCellsBool);
                }
                // 右下のセル
                // mainLists[mainLists.Count -1][mainLists[mainLists.Count -1].Count -1]
                {
                    var rlbCells = new List<bool> { displayList[displayList.Count - 1 - 1][displayList[displayList.Count - 1 - 1].Count - 1 - 1], displayList[displayList.Count - 1 - 1][displayList[displayList.Count - 1 - 1].Count - 1],
                                                    displayList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1 - 1] };
                    var rbCellsBool = rlbCells.Where(x => x == true).ToList().Count;
                    nextList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1] = JudgementCell(displayList[displayList.Count - 1][displayList[displayList.Count - 1].Count - 1], rbCellsBool);
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
            for (int j = 1; j < displayList[0].Count - 1 - 1; j++)
            {
                // 一行目のセルについての処理
                // mainLists[0][j]
                {
                    var topRowCells = new List<bool>{ displayList[0][j - 1],                            displayList[0][j + 1],
                                                      displayList[0 + 1][j - 1], displayList[0 + 1][j], displayList[0 + 1][j + 1] };
                    var topRowCellsBool = topRowCells.Where(x => x == true).ToList().Count;
                    nextList[0][j] = JudgementCell(displayList[0][j], topRowCellsBool);
                }
                // 最後の行のセルについての処理
                // mainLists[(mainLists.Count -1][j]
                {
                    var bottomRowCells = new List<bool> { displayList[displayList.Count - 1 -1][j - 1], displayList[displayList.Count - 1 - 1][j], displayList[displayList.Count - 1 - 1][j + 1],
                                                          displayList[displayList.Count - 1][j - 1],                                               displayList[displayList.Count - 1][j + 1] };
                    var bottomRowCellsBool = bottomRowCells.Where(x => x == true).ToList().Count;
                    nextList[displayList.Count - 1][j] = JudgementCell(displayList[displayList.Count - 1][j], bottomRowCellsBool);
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
            for (int i = 1; i < displayList.Count - 1 - 1; i++)
            {
                // 最初の列のセルについての処理
                // mainLists[i][0]
                {
                    var leftColumnCells = new List<bool> { displayList[i - 1][0], displayList[i - 1][0 + 1],
                                                                                  displayList[i][0 + 1],
                                                           displayList[i + 1][0], displayList[i + 1][0 + 1]};
                    var leftColumnCellsBool = leftColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][0] = JudgementCell(displayList[i][0], leftColumnCellsBool);
                }
                // 最後の列のセルについての処理
                // mainLists[i][mainLists[i].Count - 1]
                {
                    var rightColumnCells = new List<bool> { displayList[i - 1][displayList[i - 1].Count - 1 - 1], displayList[i - 1][displayList[i - 1].Count - 1],
                                                            displayList[i][displayList[i].Count - 1 - 1],
                                                            displayList[i + 1][displayList[i + 1].Count - 1 - 1], displayList[i + 1][displayList[i + 1].Count - 1] };
                    var rightColumnCellsBool = rightColumnCells.Where(x => x == true).ToList().Count;
                    nextList[i][displayList[i].Count - 1] = JudgementCell(displayList[i][displayList[i].Count - 1], rightColumnCellsBool);
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
            for (int i = 1; i < displayList.Count - 1 - 1; i++)
            {
                for (int j = 1; j < displayList[i].Count - 1 - 1; j++)
                {
                    var ijCells = new List<bool> { displayList[i - 1][j - 1], displayList[i - 1][j], displayList[i - 1][j + 1],
                                                   displayList[i][j - 1],                            displayList[i][j + 1],
                                                   displayList[i + 1][j - 1], displayList[i + 1][j], displayList[i + 1][j + 1] };
                    var ijCellsBool = ijCells.Where(x => x == true).ToList().Count;
                    nextList[i][j] = JudgementCell(displayList[i][j], ijCellsBool);
                }
            }
            return nextList;
        }

        /// <summary>
        /// 新しいリストを作成して返す
        /// </summary>
        /// <returns>作成された新しいリスト</returns>
        private List<List<bool>> CreateList()
        {
            List<List<bool>> nextList = new List<List<bool>>(displayList.Count);
            for (int i = 0; i < displayList.Count; i++)
            {
                var row = Enumerable.Range(0, displayList.Count).Select(x => false).ToList();
                nextList.Add(row);
            }

            nextList = CreateCornerCell(nextList);
            nextList = CreateOutsideCell(nextList);
            nextList = CreateCenterCell(nextList);

            return nextList;
        }

        public List<List<bool>> ListChange()
        {
            this.displayList = CreateList();

            return this.displayList;
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

            for (int i = 0; i < mainList.Count; i++)
            {
                for (int j = 0; j < mainList[i].Count; j++)
                {
                    if (!mainList[i][j])
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

        public Bitmap nextDisplay()
        {
            // TODO: 次の世代に進める
            // TODO: 画像を作成する
            return this.displayBmp;
        }

    }
}
}
