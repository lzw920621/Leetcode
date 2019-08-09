using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_Pow_x_n_
{
    /*
    实现 pow(x, n) ，即计算 x 的 n 次幂函数。

    示例 1:

    输入: 2.00000, 10
    输出: 1024.00000

    示例 2:

    输入: 2.10000, 3
    输出: 9.26100

    示例 3:

    输入: 2.00000, -2
    输出: 0.25000
    解释: 2-2 = 1/22 = 1/4 = 0.25

    说明:

        -100.0 < x < 100.0
        n 是 32 位有符号整数，其数值范围是 [−231, 231 − 1] 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/powx-n
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            double num = MyPow(2, 10);
        }

        public static double MyPow(double x, int n)
        {
            if (x == 1) return 1;
            if (x == 0) return 0;
            if (n == 0) return 1;

            if(n%2==0)//n是偶数
            {
                double temp = MyPow(x, n / 2);
                return temp * temp;
            }
            else// n是奇数
            {
                if(n>0)
                {
                    return x * MyPow(x, n - 1);
                }
                else
                {
                    return 1/x * MyPow(x, n + 1);
                }                
            }  
        }
    }
}
