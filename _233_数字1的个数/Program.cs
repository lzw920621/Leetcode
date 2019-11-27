using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _233_数字1的个数
{
    /*
        给定一个整数 n，计算所有小于等于 n 的非负整数中数字 1 出现的个数。

    示例:

    输入: 13
    输出: 6 
    解释: 数字 1 出现在以下数字中: 1, 10, 11, 12, 13 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/number-of-digit-one
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = new Program().CountDigitOne(1410065408);
        }

        public int CountDigitOne(int n)
        {
            int count = 0, k;
            try
            {
                checked
                {
                    for (int i = 1; (k = n / i) > 0; i *= 10)//i=1表示 个位  i=10表示十位  i=100表示百位  i=1000表示千位
                    {
                        // k / 10 为高位的数字。
                        count += (k / 10) * i;
                        // 当前位的数字。
                        int cur = k % 10;
                        if (cur > 1)
                        {
                            count += i;
                        }
                        else if (cur == 1)
                        {
                            // n - k * i 为低位的数字。
                            count += n - k * i + 1;
                        }
                    }
                }
            }
            catch
            {

            }
                       
            return count;
        }

        
    }
}
