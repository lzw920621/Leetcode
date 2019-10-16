using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _367_有效的完全平方数
{
    /*
        给定一个正整数 num，编写一个函数，如果 num 是一个完全平方数，则返回 True，否则返回 False。
    说明：不要使用任何内置的库函数，如  sqrt。

    示例 1：

    输入：16
    输出：True

    示例 2：

    输入：14
    输出：False

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-perfect-square
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool isSquare = IsPerfectSquare(14);
        }

        public static bool IsPerfectSquare(int num)
        {           
            int mid = num+1 / 2;
            while( Math.Abs(num/mid-mid)>1 )
            {
                mid = (num / mid + mid) / 2;
            }
            return mid * mid == num;
        }
    }
}
