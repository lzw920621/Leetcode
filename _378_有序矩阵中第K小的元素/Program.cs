using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _378_有序矩阵中第K小的元素
{
    /*
    给定一个 n x n 矩阵，其中每行和每列元素均按升序排序，找到矩阵中第k小的元素。
    请注意，它是排序后的第k小元素，而不是第k个元素。

    示例:
    matrix = 
    [
       [ 1,  5,  9],
       [10, 11, 13],
       [12, 13, 15]
    ],
    k = 8,

    返回 13。

    说明:
    你可以假设 k 的值永远是有效的, 1 ≤ k ≤ n2 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/kth-smallest-element-in-a-sorted-matrix
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][] { new int[] { 1, 5, 9 },
                                            new int[] { 10, 11, 13 },
                                            new int[] { 12, 13, 15 } };

            int num=KthSmallest(matrix,8);
        }

        public static int KthSmallest(int[][] matrix, int k)
        {
            int[] array = new int[matrix.Length * matrix.Length];//已排序数组
            //提前分配的临时数组(用来存放 合并后的有序序列) 
            //避免每次在merge方法里分配两个新数组 提高效率
            int[] tempArray = new int[matrix.Length * matrix.Length];


            for (int i = 0; i < matrix.Length; i++)
            {
                Merge(array, i * matrix.Length, matrix[i], tempArray);
            }
            return array[k - 1];
        }
        public static void Merge(int[] array, int count, int[] array2, int[] tempArray)
        {
            int i = 0;
            int j = 0;
            int index = 0;
            while (i < count && j < array2.Length)
            {
                if (array[i] < array2[j])
                {
                    tempArray[index] = array[i];
                    i++;
                    index++;
                }
                else
                {
                    tempArray[index] = array2[j];
                    j++;
                    index++;
                }
            }
            while (i < count)
            {
                tempArray[index] = array[i];
                i++;
                index++;
            }
            while (j < array2.Length)
            {
                tempArray[index] = array2[j];
                j++;
                index++;
            }

            for (int k = 0; k < index; k++)//将临时数组tempArray中合并好的元素放到 原数组array中
            {
                array[k] = tempArray[k];
            }
        }

        //方法2  二分查找
        public int KthSmallest2(int[][] matrix, int k)
        {
            int rows = matrix.Length, cols = matrix[0].Length;
            int low = matrix[0][0], high = matrix[rows - 1][cols - 1];
            int count = 0, j = 0;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                count = 0;
                j = cols - 1;

                for (int i = 0; i < rows; i++)
                {
                    while (j >= 0 && matrix[i][j] > mid)
                        j--;
                    count += (j + 1);
                }
                if (count < k)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
    }
}
