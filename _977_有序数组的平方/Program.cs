using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _977_有序数组的平方
{
    /*
    给定一个按非递减顺序排序的整数数组 A，返回每个数字的平方组成的新数组，要求也按非递减顺序排序。
 
    示例 1：
    输入：[-4,-1,0,3,10]
    输出：[0,1,9,16,100]

    示例 2：
    输入：[-7,-3,2,3,11]
    输出：[4,9,9,49,121]
    
    提示：
    1 <= A.length <= 10000
    -10000 <= A[i] <= 10000
    A 已按非递减顺序排序。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/squares-of-a-sorted-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = SortedSquares_(new int[] { -2,0 });
        }

        public static int[] SortedSquares(int[] A)
        {
            
            int[] array = new int[A.Length];
            if (A[0]>=0)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    array[i] = A[i] * A[i];
                }
                return array;
            }
            if(A[A.Length-1]<=0)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    array[A.Length - i - 1] = A[i] * A[i];
                }
                return array;
            }
            
            int left = 0, right = A.Length - 1;
            int index = right;
            while (A[left] <= 0 && A[right]>0)
            {
                if (-A[left] <= A[right])
                {
                    array[index] = A[right] * A[right];
                    right--;
                }
                else
                {
                    array[index] = A[left] * A[left];
                    left++;
                }
                index--;
            }
            while(A[left] <= 0)
            {
                array[index] = A[left] * A[left];
                left++;
                index--;
            }
            while (A[right] > 0)
            {
                array[index] = A[right] * A[right];
                right--;
                index--;
            }

            return array;
        }

        public static int[] SortedSquares_(int[] A)
        {            
            int[] array = new int[A.Length];            
            int left = 0, right = A.Length - 1;            
            for (int i = array.Length-1; i >=0 ; i--)
            {
                if(Math.Abs(A[left])<=Math.Abs(A[right]))
                {
                    array[i] = A[right] * A[right];
                    right--;
                }
                else
                {
                    array[i] = A[left] * A[left];
                    left++;
                }
            }
            return array;
        }
    }
}
