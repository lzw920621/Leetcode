using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _139_单词拆分
{
    /*
        给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，判定 s 是否可以被空格拆分为一个或多个在字典中出现的单词。

    说明：

        拆分时可以重复使用字典中的单词。
        你可以假设字典中没有重复的单词。

    示例 1：

    输入: s = "leetcode", wordDict = ["leet", "code"]
    输出: true
    解释: 返回 true 因为 "leetcode" 可以被拆分成 "leet code"。

    示例 2：

    输入: s = "applepenapple", wordDict = ["apple", "pen"]
    输出: true
    解释: 返回 true 因为 "applepenapple" 可以被拆分成 "apple pen apple"。
         注意你可以重复使用字典中的单词。

    示例 3：

    输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/word-break
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = new Program().WordBreak2("leetcode", new List<string>() { "leet", "code" });
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            for (int i = 0; i < wordDict.Count; i++)
            {
                if(s.Length>=wordDict[i].Length && s.StartsWith(wordDict[i]))
                {
                    if (s == wordDict[i]) return true;

                    string tempStr = s.Substring(wordDict[i].Length);
                    if(WordBreak(tempStr,wordDict)==true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public bool WordBreak2(string s, IList<string> wordDict)
        {
            if (wordDict == null || wordDict.Count == 0) return false;

            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (dp[j] && wordDict.Contains(s.Substring(j, i-j)))
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
