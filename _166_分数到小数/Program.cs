using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _166_分数到小数
{
    /*
    给定两个整数，分别表示分数的分子 numerator 和分母 denominator，以字符串形式返回小数。
    如果小数部分为循环小数，则将循环的部分括在括号内。

    示例 1:
    输入: numerator = 1, denominator = 2
    输出: "0.5"

    示例 2:
    输入: numerator = 2, denominator = 1
    输出: "2"

    示例 3:
    输入: numerator = 2, denominator = 3
    输出: "0.(6)"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/fraction-to-recurring-decimal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = FractionToDecimal(2,3);
        }

        public static string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == -2147483648 && denominator == -1) return "2147483648";

            Dictionary<int, int> modDic = new Dictionary<int, int>();//存储 余数
            List<int> quoList = new List<int>();//存储 商

            int quotient = numerator / denominator;//整数部分
            int mod = numerator % denominator;//余数
            mod = Math.Abs(mod);
            denominator = Math.Abs(denominator);
            if (mod==0)
            {
                return quotient.ToString();
            }
            int i = 0;
            while( mod != 0 )
            {
                int temp = mod * 10;
        
                mod = temp % denominator;
                if(modDic.ContainsKey(temp))//出现重复的余数 循环节点出现
                {
                    int index = modDic[temp];
                    StringBuilder sb = new StringBuilder();
                    sb.Append(quotient);
                    sb.Append('.');
                    for (int j = 0; j < index; j++)
                    {
                        sb.Append(quoList[j]);
                    }
                    sb.Append("(");
                    for (int j = index; j < quoList.Count; j++)
                    {
                        sb.Append(quoList[j]);
                    }
                    sb.Append(")");
                    return sb.ToString();
                }
                else
                {
                    modDic.Add(temp, i);
                }

                int quoTemp = temp / denominator;
                quoList.Add(quoTemp);

                i++;
            }
            string str = quotient + "." + string.Concat(quoList);
            return str;
        }
    }
}
