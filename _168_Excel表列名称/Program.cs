using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _168_Excel表列名称
{
    /*
        给定一个正整数，返回它在 Excel 表中相对应的列名称。

    例如，
        1 -> A
        2 -> B
        3 -> C
        ...
        26 -> Z
        27 -> AA
        28 -> AB 
        ...

    示例 1:

    输入: 1
    输出: "A"

    示例 2:

    输入: 28
    输出: "AB"

    示例 3:

    输入: 701
    输出: "ZY"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/excel-sheet-column-title
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = ConvertToTitle(52);
        }

        static char[] array = { ' ','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static string ConvertToTitle(int n)
        {
            string str = "";
            while(n>26)
            {
                int temp = n % 26;
                n = n / 26;
                if(temp==0)
                {
                    str += 'Z';
                    n--;
                }
                else
                {
                    str = array[temp] + str;
                }                
            }
            if(n>0)
            {
                str = array[n] + str;
            }
            return str;
        }
    }
}
