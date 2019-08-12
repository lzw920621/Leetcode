using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _238_除自身以外数组的乘积
{
    /*
    给定长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积。

    示例:

    输入: [1,2,3,4]
    输出: [24,12,8,6]

    说明: 请不要使用除法，且在 O(n) 时间复杂度内完成此题。

    进阶：
    你可以在常数空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组不被视为额外空间。）

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/product-of-array-except-self
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] newNums = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] newNums = new int[nums.Length];
            int n1 = 1;
            int n2 = 1;
            newNums[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                n1 *= nums[i - 1];
                newNums[i] = n1;
            }
            for (int i = nums.Length-2; i >=0; i--)
            {
                n2 *= nums[i + 1];
                newNums[i] *= n2;
            }
            return newNums;
        }
    }
}
