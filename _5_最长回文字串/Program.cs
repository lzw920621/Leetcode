using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_最长回文字串
{
    /*
    给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

    示例 1：
    
    输入: "babad"
    输出: "bab"
    注意: "aba" 也是一个有效答案。

    示例 2：

    输入: "cbbd"
    输出: "bb"

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string LongestPalindrome(string str)
        {
            if(str==null)
            {
                return null;
            }
            int mid = str.Length / 2;
            for (int i = 0; i < mid; i++)
            {

            }
        }
    }
}
