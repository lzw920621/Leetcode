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
            char[] array = ProcessStr("babad");
        }

        //穷举法
        public static string LongestPalindrome(string s)
        {
            if(s==null||s.Length<2)
            {
                return s;
            }
            int max = 0;
            string subString = null;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if(Assist(s,i,j))
                    {
                        if(j-i+1>max)
                        {
                            max = j - i + 1;
                            subString = s.Substring(i, max);
                        }
                    }
                }
            }

            return subString;
        }

        static bool Assist(string str,int left,int right)//判断是否是回文子串
        {
            int mid = (left + right) / 2;
            while(left<=mid)
            {
                if(str[left]!=str[right])
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }

        //中心点扩散法
        public static string LongestPalindrome2(string s)
        {
            if (s == null || s.Length < 2)
            {
                return s;
            }
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
            
        }
        static int expandAroundCenter(string s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }
            return R - L - 1;
        }










        static char[] ProcessStr(string s)//给字符串的相邻字符添加 "隔板" '#'
        {
            char[] tempArray = new char[s.Length * 2 + 1];
            int index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                tempArray[index] = '#';
                index++;
                tempArray[index] = s[i];
                index++;
            }
            tempArray[tempArray.Length - 1] = '#';
            return tempArray;
        }
    }
}
