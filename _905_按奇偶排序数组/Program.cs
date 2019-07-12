using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _905_按奇偶排序数组
{
    /*
    给定一个非负整数数组 A，返回一个数组，在该数组中， A 的所有偶数元素之后跟着所有奇数元素。

    你可以返回满足此条件的任何数组作为答案。

    示例：

    输入：[3,1,2,4]
    输出：[2,4,3,1]
    输出 [4,2,3,1]，[2,4,1,3] 和 [4,2,1,3] 也会被接受。

    提示：
        1 <= A.length <= 5000
        0 <= A[i] <= 5000

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sort-array-by-parity
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = SortArrayByParity(new int[] { 1,3 });
        }

        public static int[] SortArrayByParity(int[] A)
        {
            int left = 0;
            int right = A.Length - 1;
            while (left < right)
            {
                while (left < right && A[left] % 2 != 1)//从左往右选一个奇数
                {
                    left++;
                }
                while (right > left && A[right] % 2 != 0)//从右往左选一个偶数
                {
                    right--;
                }
                //交换
                Swap(A, left, right);
            }
            return A;
        }
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
