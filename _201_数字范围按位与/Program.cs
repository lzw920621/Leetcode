using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _201_数字范围按位与
{
    /*
    给定范围 [m, n]，其中 0 <= m <= n <= 2147483647，返回此范围内所有数字的按位与（包含 m, n 两端点）。

    示例 1: 

    输入: [5,7]
    输出: 4

    示例 2:

    输入: [0,1]
    输出: 0

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/bitwise-and-of-numbers-range
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int RangeBitwiseAnd(int m, int n)
        {
            int mask = int.MaxValue;
            while ((m & mask) != (n & mask))
            {
                mask = mask << 1;
            }
            return m & mask;
        }

        public static int RangeBitwiseAnd1(int m, int n)
        {
            while (n > m)
                n = n & (n - 1);
            return n;
        }
    }
}
