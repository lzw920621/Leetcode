using System;
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
            int n = CoinChange(new int[] { 186, 419, 83, 408 }, 6249);
        }

        public static int CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            Array.Reverse(coins);

            for (int i = 0; i < coins.Length; i++)
            {
                int n = Assist(coins, amount, i, 0);
                if(n!=-1)
                {
                    return n;
                }
            }
            return -1;
        }

        static int Assist(int[] coins,int target,int index,int count)
        {
            //TODO待修改
            if (target == 0) return count;
            if(index < coins.Length)
            {
                if (target < coins[index])
                {                    
                    for (int i = index + 1; i < coins.Length; i++)
                    {
                        int n = Assist(coins, target, i, count);
                        if(n!=-1)
                        {
                            return n;
                        }
                    }
                    //return -1;
                }
                else
                {
                    int n = Assist(coins, target - coins[index], index, count + 1);
                    return n;
                }
            }

            return -1;
        }
    }
}
