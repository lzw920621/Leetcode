using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _304_二维区域和检索_矩阵不可变
{
    /*
    给定一个二维矩阵，计算其子矩形范围内元素的总和，该子矩阵的左上角为 (row1, col1) ，右下角为 (row2, col2)。

    Range Sum Query 2D
    上图子矩阵左上角 (row1, col1) = (2, 1) ，右下角(row2, col2) = (4, 3)，该子矩形内元素的总和为 8。

    示例:

    给定 matrix = [
      [3, 0, 1, 4, 2],
      [5, 6, 3, 2, 1],
      [1, 2, 0, 1, 5],
      [4, 1, 0, 1, 7],
      [1, 0, 3, 0, 5]
    ]

    sumRegion(2, 1, 4, 3) -> 8
    sumRegion(1, 1, 2, 2) -> 11
    sumRegion(1, 2, 2, 4) -> 12

    说明:

        你可以假设矩阵不可变。
        会多次调用 sumRegion 方法。
        你可以假设 row1 ≤ row2 且 col1 ≤ col2。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/range-sum-query-2d-immutable
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class NumMatrix
    {
        int[][] matrix;
        int[,] dp;

        public NumMatrix(int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1) return;

            this.matrix = matrix;
            this.dp = new int[matrix.Length, matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i, 0] = matrix[i][0];
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    dp[i, j] = dp[i, j - 1] + matrix[i][j];
                }
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j];
                }
            }
        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if(row1==0)
            {
                if(col1==0)
                {
                    return dp[row2, col2];
                }
                else
                {
                    return dp[row2, col2] - dp[row2, col1 - 1];
                }
            }
            else
            {
                if (col1 == 0)
                {
                    return dp[row2, col2] - dp[row1 - 1, col2];
                }
                else
                {
                    return dp[row2, col2] - dp[row2, col1 - 1] - dp[row1 - 1, col2] + dp[row1 - 1, col1 - 1];
                }
            }
        }
    }
}
