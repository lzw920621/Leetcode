using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_无重复字符最长子串
{
    /*
     * 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
    示例 1:

    输入: "abcabcbb"
    输出: 3 
    解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。

    示例 2:

    输入: "bbbbb"
    输出: 1
    解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
    
    示例 3:

    输入: "pwwkew"
    输出: 3
    解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
     */


    class Program
    {
        static void Main(string[] args)
        {
            int length = LengthOfLongestSubstring("abcabcbb");
            //int length = LengthOfLongestSubstring_2("abcabcbb");
        }

        public static int LengthOfLongestSubstring(string s)
        {            
            int left = 0, right = 0, longestLength = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            char c;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if(!dic.ContainsKey(c))
                {
                    dic.Add(c, i);                    
                }
                else 
                {                   
                    if (dic[c] >= left)
                    {
                        left = dic[c] + 1;
                    }

                    dic[c] = i;
                }
                
                right = i;
                if(right - left + 1 > longestLength)
                {
                    longestLength = right - left + 1;
                }                
            }

            return longestLength;
        }

        public static int LengthOfLongestSubstring_2(string s)
        {
            if(s==null||s.Length==0)
            {
                return 0;
            }

            int length = 0;
            List<char> list = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if(!list.Contains(s[i]))
                {
                    list.Add(s[i]);
                    length = (list.Count > length) ? list.Count : length;
                }
                else
                {
                    while(list.Contains(s[i]))
                    {
                        list.RemoveAt(0);
                    }
                    list.Add(s[i]);
                }
            }
            return length;
        }
    }
}
