﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_最长有效括号
{
    /*
    给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。

    示例 1:

    输入: "(()"
    输出: 2
    解释: 最长有效括号子串为 "()"

    示例 2:

    输入: ")()())"
    输出: 4
    解释: 最长有效括号子串为 "()()"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-valid-parentheses
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = LongestValidParentheses1(")()())");
        }

        public static int LongestValidParentheses(string s)
        {
            //TODO
            BitArray bitArray = new BitArray(s.Length);
        }

        public static int LongestValidParentheses1(String s)
        {
            int maxans = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count==0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxans = Math.Max(maxans, i - stack.Peek());
                    }
                }
            }
            return maxans;
        }

        
    }
}
