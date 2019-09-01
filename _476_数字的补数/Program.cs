using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _476_数字的补数
{
    /*
    给定一个正整数，输出它的补数。补数是对该数的二进制表示取反。

    注意:
        给定的整数保证在32位带符号整数的范围内。
        你可以假定二进制数不包含前导零位。

    示例 1:
    输入: 5
    输出: 2
    解释: 5的二进制表示为101（没有前导零位），其补数为010。所以你需要输出2。

    示例 2:
    输入: 1
    输出: 0
    解释: 1的二进制表示为1（没有前导零位），其补数为0。所以你需要输出0。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/number-complement
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.MaxValue;
            int num = FindComplement(5);
        }

        public static int FindComplement(int num)
        {
            int temp = num, c = 0;
            while (temp > 0)
            {
                temp >>= 1;
                c = (c << 1) + 1;
            }
            return num ^ c;
        }
    }
}
