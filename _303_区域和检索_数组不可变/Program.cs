using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _303_区域和检索_数组不可变
{
    /*
    给定一个整数数组  nums，求出数组从索引 i 到 j  (i ≤ j) 范围内元素的总和，包含 i,  j 两点。

    示例：

    给定 nums = [-2, 0, 3, -5, 2, -1]，求和函数为 sumRange()

    sumRange(0, 2) -> 1
    sumRange(2, 5) -> -1
    sumRange(0, 5) -> -3

    说明:

        你可以假设数组不可变。
        会多次调用 sumRange 方法。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/range-sum-query-immutable
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            NumArray numArray = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
            int num1 = numArray.SumRange(0, 2);
            int num2 = numArray.SumRange(2, 5);
            int num3 = numArray.SumRange(0, 5);
        }
    }

    public class NumArray
    {
        int[] nums;
        int[,] dp;
        public NumArray(int[] nums)
        {
            this.nums = nums;
            this.dp = new int[nums.Length, nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i, i] = nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    dp[i, j] = dp[i, j - 1] + nums[j];
                }
            }
        }

        public int SumRange(int i, int j)
        {
            return dp[i, j];         
        }
    }

    public class NumArray2
    {
        int[] nums;
        int[] dp;
        public NumArray2(int[] nums)
        {
            if (nums == null || nums.Length < 1) return;
            this.nums = nums;
            this.dp = new int[nums.Length];
            dp[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = dp[i - 1] + nums[i];
            }
        }

        public int SumRange(int i, int j)
        {            
            return dp[j] - dp[i]+nums[i];
        }
    }
}
