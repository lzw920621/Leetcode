using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _122_买卖股票的最佳时期II
{
    /*
    给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。

    设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。

    注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

    示例 1:

    输入: [7,1,5,3,6,4]
    输出: 7
    解释: 在第 2 天（股票价格 = 1）的时候买入，在第 3 天（股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
         随后，在第 4 天（股票价格 = 3）的时候买入，在第 5 天（股票价格 = 6）的时候卖出, 这笔交易所能获得利润 = 6-3 = 3 。

    示例 2:

    输入: [1,2,3,4,5]
    输出: 4
    解释: 在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
         注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。
         因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。

    示例 3:

    输入: [7,6,4,3,1]
    输出: 0
    解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int profit = MaxProfit(new int[] {8, 6, 4, 3, 3, 2, 3, 5, 8, 3, 8, 2, 6});
        }

        public static int MaxProfit(int[] prices)
        {
            if (prices.Length < 2) return 0;
            else if (prices.Length < 3) return prices[0] < prices[1] ? prices[1] - prices[0] : 0;

            int first, second , third;
            int priceBuy = 0;
            int profit = 0;
            bool buyed = false;
            if(prices[1]>prices[0])
            {
                priceBuy = prices[0];
                buyed = true;
            }
            for (third = 2; third < prices.Length; third++)
            {
                first = third - 2;
                second = third - 1;
                if(buyed==true)//已买入 寻找卖出机会
                {
                    if (prices[first] <= prices[second] && prices[second] > prices[third])//卖出时机
                    {
                        profit += prices[second] - priceBuy;
                        buyed = false;
                    }
                }
                else//未买入 寻找买入机会
                {
                    if (prices[first] >= prices[second] && prices[second] < prices[third])//买入时机
                    {
                        priceBuy = prices[second];
                        buyed = true;
                    }
                }                
            }
            if (buyed==true && prices[prices.Length - 1]>=priceBuy)//已经到最后一天而且未卖出
            {
                profit += prices[prices.Length - 1] - priceBuy;
            }
            return profit;
        }

        public int MaxProfit1(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }
    }
}
