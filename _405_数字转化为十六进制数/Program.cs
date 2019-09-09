using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _405_数字转化为十六进制数
{
    /*
    给定一个整数，编写一个算法将这个数转换为十六进制数。对于负整数，我们通常使用 补码运算 方法。
    注意:

        十六进制中所有字母(a-f)都必须是小写。
        十六进制字符串中不能包含多余的前导零。如果要转化的数为0，那么以单个字符'0'来表示；对于其他情况，十六进制字符串中的第一个字符将不会是0字符。 
        给定的数确保在32位有符号整数范围内。
        不能使用任何由库提供的将数字直接转换或格式化为十六进制的方法。

    示例 1：

    输入:
    26

    输出:
    "1a"

    示例 2：

    输入:
    -1

    输出:
    "ffffffff"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。    
    */
    class Program
    {
        static void Main(string[] args)
        {
            string num = ToHex(-1);
        }

        public static string ToHex(int num)
        {
            if (num == 0) return "0";
            string str = "";
            int temp;
            if(num>0)
            {
                while (num > 0)
                {
                    temp = 0b1111 & num;
                    num = num >> 4;
                    switch (temp)
                    {
                        case 10: str = 'a' + str; break;
                        case 11: str = 'b' + str; break;
                        case 12: str = 'c' + str; break;
                        case 13: str = 'd' + str; break;
                        case 14: str = 'e' + str; break;
                        case 15: str = 'f' + str; break;
                        default: str = temp + str; break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    temp = 0b1111 & num;
                    num = num >> 4;
                    switch (temp)
                    {
                        case 10: str = 'a' + str; break;
                        case 11: str = 'b' + str; break;
                        case 12: str = 'c' + str; break;
                        case 13: str = 'd' + str; break;
                        case 14: str = 'e' + str; break;
                        case 15: str = 'f' + str; break;
                        default: str = temp + str; break;
                    }
                }
            }
            return str;
        }

        public static string ToHex2(int num)
        {
            return Convert.ToString(num, 16);
        }
    }
}
