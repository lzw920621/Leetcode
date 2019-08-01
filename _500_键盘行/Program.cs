using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _500_键盘行
{
    /*
    给定一个单词列表，只返回可以使用在键盘同一行的字母打印出来的单词。键盘如下图所示。
    
    American keyboard

    示例：

    输入: ["Hello", "Alaska", "Dad", "Peace"]
    输出: ["Alaska", "Dad"]
    
    注意：

        你可以重复使用键盘上同一字符。
        你可以假设输入的字符串将只包含字母。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/keyboard-row
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string[] FindWords(string[] words)
        {
            HashSet<char> set1 = new HashSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
                'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
            HashSet<char> set2 = new HashSet<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
            'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'};
            HashSet<char> set3 = new HashSet<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm' ,
            'Z', 'X', 'C', 'V', 'B', 'N', 'M'};
            Dictionary<char, HashSet<char>> dic = new Dictionary<char, HashSet<char>>()
            { { 'q', set1 }, { 'w', set1 }, { 'e', set1 }, { 'r', set1 },{ 't', set1},
                { 'y', set1 }, { 'u', set1 }, { 'i', set1 }, { 'o', set1 }, { 'p', set1 },
                {'a',set2 },{'s',set2 },{'d',set2 },{'f',set2 },{'g',set2 },{'h',set2 },{'j',set2 },{'k',set2 },{'l',set2 },
                {'z',set3 },{'x',set3 },{'c',set3 },{'v',set3 },{'b',set3 },{'n',set3 },{'m',set3 }
            };
            List<string> list = new List<string>();
            bool flag = true;
            for (int i = 0; i < words.Length; i++)
            {
                flag = true;
                HashSet<char> temp;
                if (words[i][0]>64 && words[i][0]<91)
                {
                    temp = dic[(char)(words[i][0] + 32)];
                }
                else
                {
                    temp = dic[words[i][0]];
                }
                
                for (int j = 1; j < words[i].Length; j++)
                {
                    if(!temp.Contains(words[i][j]))
                    {
                        flag = false;
                    }
                }
                if(flag==true)
                {
                    list.Add(words[i]);
                }
            }
            return list.ToArray();
        }
    }
}
