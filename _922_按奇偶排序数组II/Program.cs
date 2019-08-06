using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _922_按奇偶排序数组II
{
    /*
    给定一个非负整数数组 A， A 中一半整数是奇数，一半整数是偶数。
    对数组进行排序，以便当 A[i] 为奇数时，i 也是奇数；当 A[i] 为偶数时， i 也是偶数。
    你可以返回任何满足上述条件的数组作为答案。
    
    示例：

    输入：[4,2,5,7]
    输出：[4,5,2,7]
    解释：[4,7,2,5]，[2,5,4,7]，[2,7,4,5] 也会被接受。
    
    提示：
        2 <= A.length <= 20000
        A.length % 2 == 0
        0 <= A[i] <= 1000

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sort-array-by-parity-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static int[] SortArrayByParityII(int[] A)
        {
            int oddIndex = 1;
            int evenIndex = 0;
            while(oddIndex<A.Length && evenIndex<A.Length)
            {
                if((A[oddIndex]&1)==1)//奇数位 是 奇数 跳到下个奇数位
                {
                    oddIndex += 2;
                }
                else//奇数位 非 奇数
                {
                    if((A[evenIndex]&1)==0)//偶数位 是 偶数 跳到下个偶数位
                    {
                        evenIndex += 2;
                    }
                    else//偶数位 非 偶数  交换奇数位和偶数位的值
                    {
                        int temp = A[oddIndex];
                        A[oddIndex] = A[evenIndex];
                        A[evenIndex] = temp;
                    }
                }
            }
            return A;
        }

    }
}
