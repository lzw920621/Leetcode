using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _412_Fizz_Buzz
{
    /*
    写一个程序，输出从 1 到 n 数字的字符串表示。

    1. 如果 n 是3的倍数，输出“Fizz”；

    2. 如果 n 是5的倍数，输出“Buzz”；

    3.如果 n 同时是3和5的倍数，输出 “FizzBuzz”。

    示例：

    n = 15,

    返回:
    [
        "1",
        "2",
        "Fizz",
        "4",
        "Buzz",
        "Fizz",
        "7",
        "8",
        "Fizz",
        "Buzz",
        "11",
        "Fizz",
        "13",
        "14",
        "FizzBuzz"
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/fizz-buzz
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<string> FizzBuzz(int n)
        {
            IList<string> list = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if(i%3==0 && i % 5 == 0)
                {
                    list.Add("FizzBuzz");
                }
                else if(i%3==0)
                {
                    list.Add("Fizz");
                }
                else if(i%5==0)
                {
                    list.Add("Buzz");
                }
                else
                {
                    list.Add(i.ToString());
                }
            }
            return list;
        }
    }
}
