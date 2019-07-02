using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _66_加一
{
    /*
    给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。

    最高位数字存放在数组的首位， 数组中每个元素只存储一个数字。

    你可以假设除了整数 0 之外，这个整数不会以零开头。

    示例 1:

    输入: [1,2,3]
    输出: [1,2,4]
    解释: 输入数组表示数字 123。

    示例 2:

    输入: [4,3,2,1]
    输出: [4,3,2,2]
    解释: 输入数组表示数字 4321。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/plus-one
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = PlusOne(new int[] { 9,9 });
        }

        public static int[] PlusOne(int[] digits)
        {
            int temp = digits[digits.Length - 1] + 1;
            int carry = temp >= 10 ? 1 : 0;
            digits[digits.Length - 1] = temp % 10;

            for (int i = digits.Length - 2; i > -1; i--)
            {
                temp = digits[i] + carry;
                carry = temp >=10 ? 1 : 0;
                digits[i] = temp % 10;
                if (carry == 0)
                {
                    break;
                }
            }
            if (carry == 1)
            {
                int[] array = new int[digits.Length + 1];
                array[0] = 1;
                digits.CopyTo(array, 1);
                return array;
            }
            else
            {
                return digits;
            }
        }
    }
}
