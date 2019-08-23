using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _240_搜索二维矩阵
{
    /*
    现有矩阵 matrix 如下：
    [
      [1,   4,  7, 11, 15],
      [2,   5,  8, 12, 19],
      [3,   6,  9, 16, 22],
      [10, 13, 14, 17, 24],
      [18, 21, 23, 26, 30]
    ]

    给定 target = 5，返回 true。
    给定 target = 20，返回 false。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/search-a-2d-matrix-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 2];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[1, 0] = 2;
            matrix[1, 1] = 3;
            matrix[2, 0] = 4;
            matrix[2, 1] = 5;
            bool result = SearchMatrix(matrix, 2);
        }

        public static bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return false;

            int x = matrix.GetLength(0) - 1;
            int y = 0;

            int columns = matrix.GetLength(1);
            while(x>=0 && y<columns)
            {
                if(matrix[x,y]<target)
                {
                    y++;
                }
                else if(matrix[x,y]>target)
                {
                    x--;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
