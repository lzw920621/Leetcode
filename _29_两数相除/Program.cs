using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_两数相除
{
    /*
        给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。
    返回被除数 dividend 除以除数 divisor 得到的商。

    示例 1:

    输入: dividend = 10, divisor = 3
    输出: 3

    示例 2:

    输入: dividend = 7, divisor = -3
    输出: -2

    说明:
        被除数和除数均为 32 位有符号整数。
        除数不为 0。
        假设我们的环境只能存储 32 位有符号整数，其数值范围是 [−231,  231 − 1]。本题中，如果除法结果溢出，则返回 231 − 1。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/divide-two-integers
    著作权归领扣网络所有。商业转载请联系官方授权,非商业转载请注明出处

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = new Program().Divide(2147483647, 1);
        }

        public int Divide(int dividend, int divisor)
        {
            if( dividend== int.MinValue && divisor==-1) 
            {
                return int.MaxValue;
            }
            if (dividend == 0) return 0;
            //int result = 0;
            if(dividend>0)//被除数大于零
            {
                if(divisor>0)//除数大于零
                {
                    return Helper(dividend, divisor);
                }
                else//除数小于零
                {
                    if (divisor == int.MinValue) return 0;
                    return -Helper(dividend, -divisor);
                }
            }
            else//被除数小于零
            {
                if (divisor > 0)//除数大于零
                {
                    if (-divisor < dividend) return 0;

                    return -1 - Helper(-(dividend + divisor), divisor);
                }
                else//除数小于零
                {
                    if(divisor==int.MinValue)
                    {
                        if (dividend == int.MinValue) return 1;
                        else return 0;
                    }
                    else
                    {
                        if (divisor < dividend) return 0;

                        return 1 + Helper(-(dividend - divisor), -divisor);
                    }
                }
            }           
        }

        int Helper(int numA,int numB)
        {
            if (numA==0 || numA < numB) return 0;
            int num = numB;
            int result = 1;

            while (num < numA)
            {
                int temp = num << 1;

                if (temp >0)
                {
                    num = temp;
                    if (num <= numA)
                    {
                        result *= 2;
                    }
                }
                else
                {
                    break;
                }               
            }
            if(num>numA)
            {
                num = num >> 1;
            }
            return result + Helper(numA - num, numB);
        }



    }
}
