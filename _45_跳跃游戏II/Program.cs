using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45_跳跃游戏II
{
    /*
        给定一个非负整数数组，你最初位于数组的第一个位置。
    数组中的每个元素代表你在该位置可以跳跃的最大长度。
    你的目标是使用最少的跳跃次数到达数组的最后一个位置。

    示例:

    输入: [2,3,1,1,4]
    输出: 2
    解释: 跳到最后一个位置的最小跳跃数是 2。
         从下标为 0 跳到下标为 1 的位置，跳 1 步，然后跳 3 步到达数组的最后一个位置。

    说明:

    假设你总是可以到达数组的最后一个位置。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/jump-game-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        */
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
        }

        //动态规划 部分测试用例超时
        public int Jump(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;
            for (int i = 1; i < nums.Length; i++)
            {                
                for (int j = 0; j < i; j++)
                {
                    if(j+nums[j]>=i)
                    {
                        dp[i] = Math.Min(dp[i], dp[j] + 1);                        
                    }                    
                }
            }
            return dp[nums.Length - 1];
        }
        //部分测试用例超时
        public int Jump2(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;
            int reach = 0;
            for (int i = 0; i < nums.Length; i++)
            {                
                reach = i + nums[i];
                for (int j = i+1; j <= reach && j<nums.Length; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[i] + 1);
                }
            }
            return dp[nums.Length - 1];
        }
    }
}
