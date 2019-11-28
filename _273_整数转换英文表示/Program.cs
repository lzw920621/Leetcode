using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _273_整数转换英文表示
{
    /*
        将非负整数转换为其对应的英文表示。可以保证给定输入小于 231 - 1 。

    示例 1:

    输入: 123
    输出: "One Hundred Twenty Three"

    示例 2:

    输入: 12345
    输出: "Twelve Thousand Three Hundred Forty Five"

    示例 3:

    输入: 1234567
    输出: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"

    示例 4:

    输入: 1234567891
    输出: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/integer-to-english-words
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Program().NumberToWords(1234567891);
        }

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            string str="";
            int temp;
            while(num>0)
            {
                if (num >= 1000000000)
                {
                    temp = num / 1000000000;
                    num = num % 1000000000;

                    str = NumberToString(temp) + " Billion ";
                }
                else if (num >= 1000000)
                {
                    temp = num / 1000000;
                    num = num % 1000000;

                    str += NumberToString(temp) + " Million ";
                }
                else if (num >= 1000)
                {
                    temp = num / 1000;
                    num = num % 1000;

                    str += NumberToString(temp) + " Thousand ";
                }
                else//num<1000
                {
                    str += NumberToString(num);
                    break;
                }
            }
            
            return str.Trim();
        }

        static string NumberToString(int num)
        {
            string[] array1 = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };           
            string[] array2 = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] array3 = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            string str="";
            int n1 = num / 100;
            num = num % 100;
            int n2 = num / 10;
            int n3 = num % 10;
            if(n1>0)
            {
                str = array1[n1 - 1] + " Hundred";
            }
            if(n2>1)
            {
                str += " "+array2[n2 - 2];
            }
            else if(n2==1)
            {
                str += " " + array3[n3];
                return str.Trim();
            }
            
            if(n3>0)
            {
                str += " " + array1[n3 - 1];
            }
            return str.Trim();
        }
    }
}
