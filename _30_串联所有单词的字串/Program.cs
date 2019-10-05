using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30_串联所有单词的字串
{
    /*
        给定一个字符串 s 和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
    注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。
    

    示例 1：

    输入：
      s = "barfoothefoobarman",
      words = ["foo","bar"]
    输出：[0,9]
    解释：
    从索引 0 和 9 开始的子串分别是 "barfoor" 和 "foobar" 。
    输出的顺序不重要, [9,0] 也是有效答案。

    示例 2：

    输入：
      s = "wordgoodgoodgoodbestword",
      words = ["word","good","best","word"]
    输出：[]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
   
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new Program().FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> list = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0) return list;
            Dictionary<string, int> dic1 = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if(dic1.ContainsKey(words[i]))
                {
                    dic1[words[i]]++;
                }
                else
                {
                    dic1[words[i]] = 1;
                }
            }
            int wordsLength = words.Length * words[0].Length;

            bool dicChanged = false;
            Dictionary<string, int> dic2 = new Dictionary<string, int>(dic1);//拷贝副本
            for (int i = 0; i < s.Length-wordsLength+1; i++)
            {
                if(dicChanged)
                {
                    dic2= new Dictionary<string, int>(dic1);//拷贝副本
                    dicChanged = false;
                }
                int tempCount = 0;
                for (int j = 0; j < wordsLength; j += words[0].Length)
                {
                    string temp = s.Substring(i + j, words[0].Length);
                    if(dic2.ContainsKey(temp) && dic2[temp]>0)
                    {
                        dicChanged = true;
                        tempCount++;
                        dic2[temp]--;
                    }
                    else
                    {
                        break;
                    }
                }
                if(tempCount==words.Length)
                {
                    list.Add(i);
                }
            }
            return list;
        }
        
    }
}
