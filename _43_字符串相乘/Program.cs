using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43_字符串相乘
{
    /*
    给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
    示例 1:

    输入: num1 = "2", num2 = "3"
    输出: "6"

    示例 2:

    输入: num1 = "123", num2 = "456"
    输出: "56088"

    说明：

        num1 和 num2 的长度小于110。
        num1 和 num2 只包含数字 0-9。
        num1 和 num2 均不以零开头，除非是数字 0 本身。
        不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/multiply-strings
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = Multiply("123", "456");
        }

        public static string Multiply(string num1, string num2)
        {
            char[] numArray1= num1.ToCharArray();
            Array.Reverse(numArray1);
            char[] numArray2 = num2.ToCharArray();
            Array.Reverse(numArray2);
            char[] numArray3 = new char[num1.Length + num2.Length];
            for (int i = 0; i < numArray3.Length; i++)
            {
                numArray3[i] = '0';
            }

            int carry;
            
            for (int i = 0; i < num1.Length; i++)        
            {
                carry = 0;
                for (int j = 0; j < num2.Length; j++)
                {
                    int temp = (numArray1[i] - '0') * (numArray2[j] - '0') + carry;
                    carry = temp / 10;                    
                    int temp2 = numArray3[i + j] - '0' + temp % 10;
                    carry = temp2 / 10 + carry;
                    numArray3[i + j] = (char)(temp2 % 10 + '0');
                }
                if(carry>0)
                {
                    numArray3[i + num2.Length] = (char)(carry + '0');
                }
            }
            int length=1;
            for (int i = numArray3.Length-1; i >0; i--)
            {
                if(numArray3[i]!='0')
                {
                    length = i + 1;
                    break;
                }
            }
            Array.Resize(ref numArray3, length);
            Array.Reverse(numArray3);
            return new string(numArray3);           
        }
    }
}
