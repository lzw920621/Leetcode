using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _307_区域和检索_数组可修改
{
    /*
        给定一个整数数组  nums，求出数组从索引 i 到 j  (i ≤ j) 范围内元素的总和，包含 i,  j 两点。

    update(i, val) 函数可以通过将下标为 i 的数值更新为 val，从而对数列进行修改。

    示例:

    Given nums = [1, 3, 5]

    sumRange(0, 2) -> 9
    update(1, 2)
    sumRange(0, 2) -> 8

    说明:

        数组仅可以在 update 函数下进行修改。
        你可以假设 update 函数与 sumRange 函数的调用次数是均匀分布的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/range-sum-query-mutable
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class NumArray
    {
        int[] nums;
        int[] dp;
        public NumArray(int[] nums)
        {
            if (nums.Length < 1) return;
            this.nums = nums;
            dp = new int[nums.Length];
            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = dp[i - 1] + nums[i];
            }
        }

        public void Update(int i, int val)
        {
            int offset = val - nums[i];
            for (int j = i ; j < dp.Length; j++)
            {
                dp[j] += offset;
            }
        }

        public int SumRange(int i, int j)
        {
            if(i==0)
            {
                return dp[j];
            }
            else
            {
                return dp[j] - dp[i - 1];
            }
        }
    }
}
