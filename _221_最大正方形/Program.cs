using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221_最大正方形
{
    /*
        在一个由 0 和 1 组成的二维矩阵内，找到只包含 1 的最大正方形，并返回其面积。

    示例:

    输入: 

    1 0 1 0 0
    1 0 1 1 1
    1 1 1 1 1
    1 0 0 1 0

    输出: 4

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximal-square
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[4][]
            {
                new char[]{ '1', '0', '1', '0', '0' },
                new char[]{ '1', '0', '1', '1', '1' },
                new char[]{ '1', '1', '1', '1', '1' },
                new char[]{ '1', '0', '0', '1', '0' }
            };
            int area = MaximalSquare(matrix);
        }

        
        public static int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length < 1) return 0;
            int maxLen = 0;
            int[,] dp = new int[matrix.Length, matrix[0].Length];//dp[i,j]表示以右下角坐标为(i,j)的最大正方形边长;
            for (int i = 0; i < matrix[0].Length; i++)//处理第一行
            {
                if (matrix[0][i] == '1')
                {
                    dp[0, i] = 1;
                    maxLen = 1;
                }
            }
            for (int j = 0; j < matrix.Length; j++)//处理第一列
            {
                if (matrix[j][0] == '1')
                {
                    dp[j, 0] = 1;
                    maxLen = 1;
                }
            }

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '1' && dp[i - 1, j - 1] > 0)
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                        maxLen = Math.Max(dp[i, j], maxLen);
                    }
                    else if (matrix[i][j] == '1')
                    {
                        dp[i, j] = 1;
                    }
                }
            }

            return maxLen*maxLen;
        }

        public int MaximalSquare2(char[][] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = rows > 0 ? matrix[0].Length : 0;

            int[,] dp = new int[rows + 1, cols + 1];

            int maxLen = 0;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (matrix[i - 1][j - 1] == '1')
                    {
                        dp[i, j] = 1 +
                                Math.Min(dp[i - 1, j - 1],
                                          Math.Min(dp[i - 1, j], dp[i, j - 1]));
                        maxLen = Math.Max(maxLen, dp[i, j]);
                    }
                }
            }
            return maxLen * maxLen;

        }
    }
}
