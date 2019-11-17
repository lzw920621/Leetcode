using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _140_单词拆分II
{
    /*
        给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，在字符串中增加空格来构建一个句子，
    使得句子中所有的单词都在词典中。返回所有这些可能的句子。

    说明：
        分隔时可以重复使用字典中的单词。
        你可以假设字典中没有重复的单词。

    示例 1：

    输入:
    s = "catsanddog"
    wordDict = ["cat", "cats", "and", "sand", "dog"]
    输出:
    [
      "cats and dog",
      "cat sand dog"
    ]

    示例 2：

    输入:
    s = "pineapplepenapple"
    wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
    输出:
    [
      "pine apple pen apple",
      "pineapple pen apple",
      "pine applepen apple"
    ]
    解释: 注意你可以重复使用字典中的单词。

    示例 3：

    输入:
    s = "catsandog"
    wordDict = ["cats", "dog", "sand", "and", "cat"]
    输出:
    []

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/word-break-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = new List<string> { "cat", "cats", "and", "sand", "dog" };
            string s = "catsanddog";
            IList<string> result = new Program().WordBreak(s, list);
        }

        int maxLength = 0;
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            IList<string> list = new List<string>();
            HashSet<string> set = new HashSet<string>();

            maxLength = 0;
            foreach (var item in wordDict)
            {
                set.Add(item);
                if(maxLength<item.Length)
                {
                    maxLength = item.Length;
                }
            }

            if (WordBreak2(s, set) == false) return list;

            BackTrace(s, 0, new StringBuilder(s.Length*2), set, list);
            return list;
        }

        void BackTrace(string s,int index,StringBuilder sb, HashSet<string> set,IList<string> list)
        {
            if(index==s.Length)
            {
                list.Add(sb.ToString());
                return;
            }
            for (int i = index; i < s.Length; i++)
            {
                if (i - index + 1 > maxLength)
                {
                    break;
                }
                string str = s.Substring(index, i - index + 1);
                if(set.Contains(str))
                {
                    if(sb.Length>0)
                    {
                        str = " " + str;
                    }
                    sb.Append(str);              
                    BackTrace(s, i + 1, sb, set, list);
                    sb.Remove(sb.Length - str.Length, str.Length);
                }
            }
        }

        //判断是否能分割
        public bool WordBreak2(string s, HashSet<string> set)
        {
            if (set == null || set.Count == 0) return false;

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (dp[j] && set.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];

        }
    }
}
