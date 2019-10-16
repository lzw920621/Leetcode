﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _647_回文子串
{
    /*
        给定一个字符串，你的任务是计算这个字符串中有多少个回文子串。

    具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被计为是不同的子串。

    示例 1:

    输入: "abc"
    输出: 3
    解释: 三个回文子串: "a", "b", "c".

    示例 2:

    输入: "aaa"
    输出: 6
    说明: 6个回文子串: "a", "a", "a", "aa", "aa", "aaa".

    注意:

        输入的字符串长度不会超过1000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/palindromic-substrings
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int CountSubstrings(string s)
        {            
            bool[,] dp = new bool[s.Length, s.Length];//dp[index1,index2]表示从index1到index2的字符串是回文字串
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (s[i] == s[j] && (i - j < 2 || dp[j + 1, i - 1]))
                    {
                        dp[j, i] = true;//i-j是回文子串
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
