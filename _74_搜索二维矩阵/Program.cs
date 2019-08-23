using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _74_搜索二维矩阵
{
    /*
    编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：

    每行中的整数从左到右按升序排列。
    每行的第一个整数大于前一行的最后一个整数。

    示例 1:

    输入:
    matrix = [
      [1,   3,  5,  7],
      [10, 11, 16, 20],
      [23, 30, 34, 50]
    ]
    target = 3
    输出: true

    示例 2:

    输入:
    matrix = [
      [1,   3,  5,  7],
      [10, 11, 16, 20],
      [23, 30, 34, 50]
    ]
    target = 13
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/search-a-2d-matrix
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][]
            {
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,50}
            };
            bool result = SearchMatrix(matrix, 3);
        }
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length < 1 || matrix[0].Length < 1) return false;
            int right = matrix.Length * matrix[0].Length - 1;
            return BinarySearch(matrix, 0, right, target);
        }
        static bool BinarySearch(int[][] matrix,int left,int right,int target)
        {
            if(left>right)
            {
                return false;
            }
            
            int mid = (left + right) / 2;
            int x3 = mid / matrix[0].Length;
            int y3 = mid % matrix[0].Length;

            if(matrix[x3][y3]==target)
            {
                return true;
            }
            
            if(matrix[x3][y3]<target)
            {
                return BinarySearch(matrix, mid + 1, right, target);
            }
            else
            {                
                return BinarySearch(matrix, left, mid - 1, target);
            }
        }
    }
}
