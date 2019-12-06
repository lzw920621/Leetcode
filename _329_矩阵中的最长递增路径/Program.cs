using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _329_矩阵中的最长递增路径
{
    /*
        给定一个整数矩阵，找出最长递增路径的长度。
    对于每个单元格，你可以往上，下，左，右四个方向移动。 你不能在对角线方向上移动或移动到边界外（即不允许环绕）。

    示例 1:

    输入: nums = 
    [
      [9,9,4],
      [6,6,8],
      [2,1,1]
    ] 
    输出: 4 
    解释: 最长递增路径为 [1, 2, 6, 9]。

    示例 2:

    输入: nums = 
    [
      [3,4,5],
      [3,2,6],
      [2,2,1]
    ] 
    输出: 4 
    解释: 最长递增路径是 [3, 4, 5, 6]。注意不允许在对角线方向上移动。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-increasing-path-in-a-matrix
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][]
            {
                new int[]{9,9,4},
                new int[]{6,6,8},
                new int[]{2,1,1}
            };
            int max = new Program().LongestIncreasingPath(matrix);
            
        }

        public int LongestIncreasingPath(int[][] matrix)
        {            
            if (matrix.Length < 1) return 0;
            int max = 0;
            int[,] map = new int[matrix.Length, matrix[0].Length];
            
            bool[,] array = new bool[matrix.Length, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int length = Helper(matrix, array, i, j, map);
                    
                    max = Math.Max(max, length);
                }
            }
            return max;
        }
       
        int Helper(int[][] matrix, bool[,] array, int x, int y, int[,] map)
        {
            if (map[x, y] != 0) return map[x, y];

            array[x, y] = true;

            int temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0;
            if (x - 1 >= 0 && matrix[x - 1][y] > matrix[x][y] && array[x - 1, y] == false)
            {
                if (map[x - 1, y] == 0)
                {
                    map[x - 1, y] = Helper(matrix, array, x - 1, y, map);
                }
                temp1 = map[x - 1, y];
            }
            if (x + 1 < matrix.Length && matrix[x + 1][y] > matrix[x][y] && array[x + 1, y] == false)
            {
                if (map[x + 1, y] == 0)
                {
                    map[x + 1, y] = Helper(matrix, array, x + 1, y,  map);
                }
                temp2 = map[x + 1, y];
            }
            if (y - 1 >= 0 && matrix[x][y - 1] > matrix[x][y] && array[x, y - 1] == false)
            {
                if (map[x, y - 1] == 0)
                {
                    map[x, y - 1] = Helper(matrix, array, x, y - 1, map);
                }
                temp3 = map[x, y - 1];
            }
            if (y + 1 < matrix[x].Length && matrix[x][y + 1] > matrix[x][y] && array[x, y + 1] == false)
            {
                if (map[x, y + 1] == 0)
                {
                    map[x, y + 1] = Helper(matrix, array, x, y + 1, map);
                }
                temp4 = map[x, y + 1];
            }

            array[x, y] = false;

            int max = Math.Max(Math.Max(temp1, temp2), Math.Max(temp3, temp4));
            map[x, y] = max + 1;
            return map[x, y];
        }
    }
}
