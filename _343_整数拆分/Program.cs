﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _343_整数拆分
{
    /*
        给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。

    示例 1:

    输入: 2
    输出: 1
    解释: 2 = 1 + 1, 1 × 1 = 1。

    示例 2:

    输入: 10
    输出: 36
    解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。

    说明: 你可以假设 n 不小于 2 且不大于 58。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/integer-break
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = new Program().IntegerBreak(10);
        }

        //static Dictionary<int, int> dic = new Dictionary<int, int>();
        public int IntegerBreak(int n)
        {
            if (n < 4) return n;
            int[] dp = new int[n+1];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;
            dp[4] = 4;
            for (int i = 5; i <= n; i++)
            {
                for (int j = 1; j < i/2; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j] * dp[j]);
                }
            }
            
            return dp[n];
        }
        
    }
}
