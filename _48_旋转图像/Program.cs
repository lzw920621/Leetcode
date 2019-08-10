using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_旋转图像
{
    /*
    给定一个 n × n 的二维矩阵表示一个图像。
    将图像顺时针旋转 90 度。

    说明：
    你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。

    示例 1:

    给定 matrix = 
    [
      [1,2,3],
      [4,5,6],
      [7,8,9]
    ],

    原地旋转输入矩阵，使其变为:
    [
      [7,4,1],
      [8,5,2],
      [9,6,3]
    ]

    示例 2:

    给定 matrix =
    [
      [ 5, 1, 9,11],
      [ 2, 4, 8,10],
      [13, 3, 6, 7],
      [15,14,12,16]
    ], 

    原地旋转输入矩阵，使其变为:
    [
      [15,13, 2, 5],
      [14, 3, 4, 1],
      [12, 6, 8, 9],
      [16, 7,10,11]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/rotate-image
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Rotate(int[][] matrix)
        {
            Mirror1(matrix);
            Mirror2(matrix);
        }

        public static void Mirror1(int[][] matrix)//从左上角到右下角对折
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i+1; j < matrix.Length; j++)
                {
                    Swap(matrix, i, j, j, i);
                }
            }
        }
        public static void Mirror2(int[][] matrix)//左右翻转
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length/2; j++)
                {
                    Swap(matrix, i, j, i, matrix.Length - 1 - j);
                }
            }
        }
        static void Swap(int[][] matrix,int x1,int y1,int x2,int y2)
        {
            int temp = matrix[x1][y1];
            matrix[x1][y1] = matrix[x2][y2];
            matrix[x2][y2] = temp;
        }
    }
}
