using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _172_阶乘后的零
{
    /*
    给定一个整数 n，返回 n! 结果尾数中零的数量。

    示例 1:

    输入: 3
    输出: 0
    解释: 3! = 6, 尾数中没有零。

    示例 2:

    输入: 5
    输出: 1
    解释: 5! = 120, 尾数中有 1 个零.

    说明: 你算法的时间复杂度应为 O(log n) 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/factorial-trailing-zeroes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = TrailingZeroes(50);
        }

        public static int TrailingZeroes(int n)
        {
            int num5 = 1;
            while(Math.Pow(5, num5) <=n)
            {
                num5++;
            }
            num5--;

            int numOfZero = 0;
            
            for (int i = 1; i <= num5; i++)
            {
                numOfZero += n / (int)(Math.Pow(5, i));
            }
            return numOfZero;
        }
    }
}
