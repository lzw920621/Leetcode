﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _151_翻转字符串里的单词
{
    /*
        给定一个字符串，逐个翻转字符串中的每个单词。

    示例 1：

    输入: "the sky is blue"
    输出: "blue is sky the"

    示例 2：

    输入: "  hello world!  "
    输出: "world! hello"
    解释: 输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。

    示例 3：

    输入: "a good   example"
    输出: "example good a"
    解释: 如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。

 

    说明：

        无空格字符构成一个单词。
        输入字符串可以在前面或者后面包含多余的空格，但是反转后的字符不能包括。
        如果两个单词间有多余的空格，将反转后单词间的空格减少到只含一个。

 

    进阶：

    请选用 C 语言的用户尝试使用 O(1) 额外空间复杂度的原地解法。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-words-in-a-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Program().ReverseWords("a good   example");
        }

        public string ReverseWords(string s)
        {
            string[] strArray = s.Trim().Split(' ');
            if (strArray.Length == 1 && strArray[0] == "") return "";
            StringBuilder sb = new StringBuilder();
            for (int i = strArray.Length - 1; i >= 0; i--)
            {
                if (strArray[i] != "")
                {
                    sb.Append(strArray[i]);
                    sb.Append(" ");
                }
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
