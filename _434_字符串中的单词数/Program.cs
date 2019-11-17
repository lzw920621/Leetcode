using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _434_字符串中的单词数
{
    /*
        统计字符串中的单词个数，这里的单词指的是连续的不是空格的字符。

    请注意，你可以假定字符串里不包括任何不可打印的字符。

    示例:

    输入: "Hello, my name is John"
    输出: 5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/number-of-segments-in-a-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {

        }

        public int CountSegments(string s)
        {
            bool flag = true;
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(flag==true)
                {
                    if (s[i]!=' ')
                    {
                        count++;
                        flag = false;
                    }
                }
                else
                {
                    //s[i]是空格
                    if(s[i] == ' ')
                    {
                        flag = true;
                    }
                }
            }

            return count;
        }
    }
}
