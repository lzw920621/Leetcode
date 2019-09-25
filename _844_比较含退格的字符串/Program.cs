﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _844_比较含退格的字符串
{
    /*
        给定 S 和 T 两个字符串，当它们分别被输入到空白的文本编辑器后，判断二者是否相等，并返回结果。 # 代表退格字符。
        
    示例 1：

    输入：S = "ab#c", T = "ad#c"
    输出：true
    解释：S 和 T 都会变成 “ac”。

    示例 2：

    输入：S = "ab##", T = "c#d#"
    输出：true
    解释：S 和 T 都会变成 “”。

    示例 3：

    输入：S = "a##c", T = "#a#c"
    输出：true
    解释：S 和 T 都会变成 “c”。

    示例 4：

    输入：S = "a#c", T = "b"
    输出：false
    解释：S 会变成 “c”，但 T 仍然是 “b”。

 

    提示：

        1 <= S.length <= 200
        1 <= T.length <= 200
        S 和 T 只含有小写字母以及字符 '#'。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/backspace-string-compare
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool BackspaceCompare(string S, string T)
        {
            return GetRealString(S) == GetRealString(T);
        }

        string GetRealString(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i]=='#')
                {
                    if(stack.Count>0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(str[i]);
                }
            }
            StringBuilder sb = new StringBuilder();
            while(stack.Count>0)
            {
                sb.Append(stack.Pop());
            }
            return sb.ToString();
        }
    }
}
