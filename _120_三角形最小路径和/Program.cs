using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120_三角形最小路径和
{
    /*
        给定一个三角形，找出自顶向下的最小路径和。每一步只能移动到下一行中相邻的结点上。
    例如，给定三角形：
    [
         [2],
        [3,4],
       [6,5,7],
      [4,1,8,3]
    ]

    自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。

    说明：

    如果你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题，那么你的算法会很加分。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/triangle
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        //动态规划 原地修改
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            for (int i = 1; i < triangle.Count; i++)
            {
                triangle[i][0] += triangle[i - 1][0];//当前行的行首元素加上上一行的行首元素
                triangle[i][triangle[i].Count - 1] += triangle[i - 1][triangle[i - 1].Count - 1];//当前行的行尾元素加上上一行的行尾元素
                for (int j = 1; j < triangle[i].Count - 1; j++)
                {
                    triangle[i][j] += Math.Min(triangle[i - 1][j - 1], triangle[i - 1][j]);
                }
            }
            return triangle.Last().Min();
        }
    }
}
