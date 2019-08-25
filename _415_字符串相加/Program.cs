using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _415_字符串相加
{
    /*
    给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。

    注意：

        num1 和num2 的长度都小于 5100.
        num1 和num2 都只包含数字 0-9.
        num1 和num2 都不包含任何前导零。
        你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/add-strings
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string AddStrings(string num1, string num2)
        {
            char[] array = new char[num1.Length > num2.Length ? num1.Length : num2.Length];
            int minLength = Math.Min(num1.Length, num2.Length);
            int i = num1.Length - 1, j = num2.Length - 1;
            int index = 0;
            int carry = 0;
            int temp;
            while(index<minLength)
            {
                temp = num1[i] + num2[j] - '0' - '0' + carry;
                carry = temp / 10;
                array[index] = (char)(temp % 10 + '0');
                index++;
                i--;
                j--;
            }
            if(num1.Length>=num2.Length)
            {
                while (index < array.Length)
                {
                    temp = num1[i] - '0' + carry;
                    carry = temp / 10;
                    array[index] = (char)(temp % 10 + '0');
                    index++;
                    i--;
                }
            }
            else
            {
                while (index < array.Length)
                {
                    temp = num2[j] - '0' + carry;
                    carry = temp / 10;
                    array[index] = (char)(temp % 10 + '0');
                    index++;
                    j--;
                }
            }
            
            Array.Reverse(array);
            if (carry>0)
            {                
                return carry + new string(array);
            }
            return new string(array);
        }
    }
}
