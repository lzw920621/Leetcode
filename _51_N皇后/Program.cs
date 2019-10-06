using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_N皇后
{
    /*
    n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。

    上图为 8 皇后问题的一种解法。

    给定一个整数 n，返回所有不同的 n 皇后问题的解决方案。

    每一种解法包含一个明确的 n 皇后问题的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。

    示例:

    输入: 4
    输出: [
     [".Q..",  // 解法 1
      "...Q",
      "Q...",
      "..Q."],

     ["..Q.",  // 解法 2
      "Q...",
      "...Q",
      ".Q.."]
    ]
    解释: 4 皇后问题存在两个不同的解法。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/n-queens
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。



    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> list = new Program().SolveNQueens(3);

        }

        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> list = new List<IList<string>>();
            if (n < 1) return list;

            NQueens(new List<int>(), 0, n, list);
            return list;
        }

        void NQueens(List<int> tempList,int index, int count,IList<IList<string>> list)
        {
            if(index==count)
            {
                list.Add(ListIntToListString(tempList));
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if(IsValid(tempList,i))
                    {
                        List<int> tempList2 = new List<int>(tempList);
                        tempList2.Add(i);
                        NQueens(tempList2, index + 1, count, list);
                    }
                }
            }
        }

        List<string> ListIntToListString(List<int> tempList)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < tempList.Count; i++)
            {
                StringBuilder sb = new StringBuilder(tempList.Count);
                for (int j = 0; j < tempList.Count; j++)
                {
                    if (tempList[i] == j)
                    {
                        sb.Append('Q');
                    } else
                    {
                        sb.Append('.');
                    }
                }
                list.Add(sb.ToString());
            }
            return list;
        }


        bool IsValid(List<int> tempList,int current)
        {
            if (tempList.Count < 1) return true;
            for (int i = 0; i < tempList.Count; i++)
            {
                if(Math.Abs(current-tempList[i])==tempList.Count-i || current==tempList[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
