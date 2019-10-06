using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _52_N皇后II
{
    /*
        n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。

    上图为 8 皇后问题的一种解法。

    给定一个整数 n，返回 n 皇后不同的解决方案的数量。

    示例:

    输入: 4
    输出: 2
    解释: 4 皇后问题存在如下两个不同的解法。
    [
     [".Q..",  // 解法 1
      "...Q",
      "Q...",
      "..Q."],

     ["..Q.",  // 解法 2
      "Q...",
      "...Q",
      ".Q.."]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/n-queens-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。



    */
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public int TotalNQueens(int n)
        {
            int solutions = 0;
            NQueens(new List<int>(), 0, n, ref solutions);
            return solutions;
        }

        void NQueens(List<int> tempList, int index, int count, ref int solutions)
        {
            if (index == count)
            {
                solutions++;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (IsValid(tempList, i))
                    {
                        List<int> tempList2 = new List<int>(tempList);
                        tempList2.Add(i);
                        NQueens(tempList2, index + 1, count, ref solutions);
                    }
                }
            }
        }

        bool IsValid(List<int> tempList, int current)
        {
            if (tempList.Count < 1) return true;
            for (int i = 0; i < tempList.Count; i++)
            {
                if (Math.Abs(current - tempList[i]) == tempList.Count - i || current == tempList[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
