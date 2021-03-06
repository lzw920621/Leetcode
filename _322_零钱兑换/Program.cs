﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _322_零钱兑换
{
    /*
    给定不同面额的硬币 coins 和一个总金额 amount。编写一个函数来计算可以凑成总金额所需的最少的硬币个数。
    如果没有任何一种硬币组合能组成总金额，返回 -1。

    示例 1:
    输入: coins = [1, 2, 5], amount = 11
    输出: 3 
    解释: 11 = 5 + 5 + 1

    示例 2:

    输入: coins = [2], amount = 3
    输出: -1

    说明:
    你可以认为每种硬币的数量是无限的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/coin-change
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {            
            int n = CoinChange2(new int[] { 186,419,83,408 },6249);
        }

        
        public static int CoinChange(int[] coins, int amount)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>() { { 0, 0 } };
            for (int i = 0; i < coins.Length; i++)
            {
                dic[coins[i]] = 1;
            }
            return Assist(coins, amount, dic);
        }
        public static int Assist(int[] coins, int amount,Dictionary<int,int> dic)
        {
            if (amount < 0) return -1;
            if (dic.ContainsKey(amount))
            {
                return dic[amount];
            }
            
            int count = -1;
            for (int i = 0; i < coins.Length; i++)
            {
                int temp = Assist(coins, amount - coins[i], dic) + 1;
                if (temp == 0)
                {
                    dic[amount - coins[i]] = -1;
                }
                else
                {
                    if (count > 0)
                    {
                        count = Math.Min(count, temp);
                    }
                    else
                    {
                        count = temp;
                    }
                }
            }
            dic[amount] = count;
            return count;
        }


        public static int CoinChange2(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = amount+1;
            }
                        
            for (int i = 1; i <= amount; i++)
            {               
                for (int j = 0; j < coins.Length; j++)
                {
                    if(i>= coins[j])
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }                
            }
            return dp[amount] < amount + 1 ? dp[amount] : -1;
        }
    }
}
