using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _377_组合总和
{
    /*
        给定一个由正整数组成且不存在重复数字的数组，找出和为给定目标正整数的组合的个数。

    示例:

    nums = [1, 2, 3]
    target = 4

    所有可能的组合为：
    (1, 1, 1, 1)
    (1, 1, 2)
    (1, 2, 1)
    (1, 3)
    (2, 1, 1)
    (2, 2)
    (3, 1)

    请注意，顺序不同的序列被视作不同的组合。

    因此输出为 7。

    进阶：
    如果给定的数组中含有负数会怎么样？
    问题会产生什么变化？
    我们需要在题目中添加什么限制来允许负数的出现？

    致谢：
    特别感谢 @pbrother 添加此问题并创建所有测试用例。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/combination-sum-iv
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = new Program().CombinationSum4_1(new int[] {3, 33, 333 }, 10000);
        }

        public int CombinationSum4(int[] nums, int target)
        {
            //dfs会超时
            //使用dp数组，dp[i]代表组合数为i时使用nums中的数能组成的组合数的个数
            //别怪我写的这么完整
            //dp[i]=dp[i-nums[0]]+dp[i-nums[1]]+dp[i=nums[2]]+...
            //举个例子比如nums=[1,3,4],target=7;
            //dp[7]=dp[6]+dp[4]+dp[3]
            //其实就是说7的组合数可以由三部分组成，1和dp[6]，3和dp[4],4和dp[3];
            int[] dp = new int[target + 1];
            //是为了算上自己的情况，比如dp[1]可以由dp【0】和1这个数的这种情况组成。
            dp[0] = 1;
            for (int i = 1; i <= target; i++)
            {
                foreach (int num in nums)
                {
                    if (i >= num)
                    {
                        dp[i] += dp[i - num];
                    }
                }
            }
            return dp[target];
        }


        public int CombinationSum4_1(int[] nums, int target)
        {
            Array.Sort(nums);
            int[] memo = new int[target+1];
            for (int i = 1; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            memo[0] = 1;
            Helper(nums, target, memo);
            return memo[target];
        }

        int Helper(int[] nums,int target,int[] memo)
        {
            if(memo[target]!=-1)
            {
                return memo[target];
            }
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(target>=nums[i])
                {
                    count += Helper(nums, target - nums[i], memo);
                }
                else
                {
                    break;
                }
            }
            memo[target] = count;
            return count;
        }
    }
}
