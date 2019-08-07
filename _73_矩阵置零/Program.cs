using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _73_矩阵置零
{
    /*
    给定一个 m x n 的矩阵，如果一个元素为 0，则将其所在行和列的所有元素都设为 0。请使用原地算法。

    示例 1:

    输入: 
    [
      [1,1,1],
      [1,0,1],
      [1,1,1]
    ]
    输出: 
    [
      [1,0,1],
      [0,0,0],
      [1,0,1]
    ]

    示例 2:

    输入: 
    [
      [0,1,2,0],
      [3,4,5,2],
      [1,3,1,5]
    ]
    输出: 
    [
      [0,0,0,0],
      [0,4,5,0],
      [0,3,1,0]
    ]

    进阶:

        一个直接的解决方案是使用  O(mn) 的额外空间，但这并不是一个好的解决方案。
        一个简单的改进方案是使用 O(m + n) 的额外空间，但这仍然不是最好的解决方案。
        你能想出一个常数空间的解决方案吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/set-matrix-zeroes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        //方法1
        public void SetZeroes(int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1) return;
            int[] array1 = new int[matrix.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = 1;
            }
            int[] array2 = new int[matrix[0].Length];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = 1;
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(matrix[i][j]==0)
                    {
                        array1[i] = 0;
                        array2[j] = 0;
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(array1[i]==0 || array2[j]==0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        //方法2
        public void SetZeroes2(int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1) return;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        for (int k = 0; k < matrix.Length; k++)//列 零标签
                        {
                            matrix[k][j] = int.MinValue;
                        }
                        for (int k = 0; k < matrix[i].Length; k++)//行 零标签
                        {
                            matrix[i][k] = int.MinValue;
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == int.MinValue)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
}
