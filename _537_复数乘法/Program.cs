using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _537_复数乘法
{
    /*
        给定两个表示复数的字符串。

    返回表示它们乘积的字符串。注意，根据定义 i2 = -1 。

    示例 1:

    输入: "1+1i", "1+1i"
    输出: "0+2i"
    解释: (1 + i) * (1 + i) = 1 + i2 + 2 * i = 2i ，你需要将它转换为 0+2i 的形式。

    示例 2:

    输入: "1+-1i", "1+-1i"
    输出: "0+-2i"
    解释: (1 - i) * (1 - i) = 1 + i2 - 2 * i = -2i ，你需要将它转换为 0+-2i 的形式。 

    注意:

        输入字符串不包含额外的空格。
        输入字符串将以 a+bi 的形式给出，其中整数 a 和 b 的范围均在 [-100, 100] 之间。输出也应当符合这种形式。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/complex-number-multiplication
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Program().ComplexNumberMultiply("1+-1i", "1+-1i");
        }

        public string ComplexNumberMultiply(string a, string b)
        {
            int x1, y1, x2, y2;
            string[] strArray1 = a.Split('+');
            x1 = int.Parse(strArray1[0]);
            y1 = int.Parse(strArray1[1].Substring(0, strArray1[1].IndexOf('i')));
            string[] strArray2 = b.Split('+');
            x2 = int.Parse(strArray2[0]);
            y2 = int.Parse(strArray2[1].Substring(0, strArray2[1].IndexOf('i')));

            return "" + (x1 * x2 - y1 * y2) + '+' + (x1 * y2 + x2 * y1) + 'i';
        }
    }
}
