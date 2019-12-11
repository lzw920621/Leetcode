using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _720_词典中最长的单词
{
    /*
        给出一个字符串数组words组成的一本英语词典。从中找出最长的一个单词，该单词是由words词典中其他单词逐步添加一个字母组成。
    若其中有多个可行的答案，则返回答案中字典序最小的单词。若无答案，则返回空字符串。

    示例 1:

    输入: 
    words = ["w","wo","wor","worl", "world"]
    输出: "world"
    解释: 
    单词"world"可由"w", "wo", "wor", 和 "worl"添加一个字母组成。

    示例 2:

    输入: 
    words = ["a", "banana", "app", "appl", "ap", "apply", "apple"]
    输出: "apple"
    解释: 
    "apply"和"apple"都能由词典中的单词组成。但是"apple"得字典序小于"apply"。

    注意:
        所有输入的字符串都只包含小写字母。
        words数组长度范围为[1,1000]。
        words[i]的长度范围为[1,30]。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-word-in-dictionary
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "yo", "ew", "fc", "zrc", "yodn", "fcm", "qm", "qmo", "fcmz", "z", "ewq", "yod", "ewqz", "y" };
            string longestWord = new Program().LongestWord(words);
        }

        public string LongestWord(string[] words)
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            Trie trie = new Trie();
            foreach (var word in words)
            {
                trie.InsertString(word);
                if(dic.ContainsKey(word.Length))
                {
                    dic[word.Length].Add(word);
                }
                else
                {
                    dic[word.Length] = new List<string> { word };
                }
            }
            var dic2 = dic.OrderBy(keyPair => keyPair.Key).Reverse();
            foreach (var keyPair in dic2)
            {
                List<string> tempList = keyPair.Value;
                tempList.Sort();
                foreach (var word in tempList)
                {
                    if(Helper(trie,word))
                    {
                        return word;
                    }
                }
            }
            return "";
        }
        
        bool Helper(Trie trie, string str)
        {
            if(str.Length==1)
            {
                return trie.Search(str);
            }
            if(trie.Search(str))
            {
                return Helper(trie,str.Substring(0, str.Length - 1));
            }
            return false;
        }
    }

    class Node
    {
        public bool isEndOfWord;
        public Node[] childs = new Node[26];
        public string str;
    }

    class Trie
    {
        public Node root;
        public Trie()
        {
            root = new Node();
        }

        public void InsertString(string str)
        {
            Node temp = root;
            for (int i = 0; i < str.Length; i++)
            {
                if (temp.childs[str[i] - 'a'] == null)
                {
                    temp.childs[str[i] - 'a'] = new Node();
                }
                temp = temp.childs[str[i] - 'a'];
            }
            temp.isEndOfWord = true;
            temp.str = str;
        }

        public bool Search(string word)
        {
            Node tempNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (tempNode.childs[word[i] - 'a'] != null)
                {
                    tempNode = tempNode.childs[word[i] - 'a'];
                }
                else
                {
                    return false;
                }
            }
            return tempNode.isEndOfWord;
        }
    }
}
