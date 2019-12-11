using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _676_实现一个魔法字典
{
    /*
        实现一个带有buildDict, 以及 search方法的魔法字典。
    对于buildDict方法，你将被给定一串不重复的单词来构建一个字典。
    对于search方法，你将被给定一个单词，并且判定能否只将这个单词中一个字母换成另一个字母，
    使得所形成的新单词存在于你构建的字典中。

    示例 1:

    Input: buildDict(["hello", "leetcode"]), Output: Null
    Input: search("hello"), Output: False
    Input: search("hhllo"), Output: True
    Input: search("hell"), Output: False
    Input: search("leetcoded"), Output: False

    注意:

        你可以假设所有输入都是小写字母 a-z。
        为了便于竞赛，测试所用的数据量很小。你可以在竞赛结束后，考虑更高效的算法。
        请记住重置MagicDictionary类中声明的类变量，因为静态/类变量会在多个测试用例中保留。 请参阅这里了解更多详情。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/implement-magic-dictionary
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            MagicDictionary dic = new MagicDictionary();
            dic.BuildDict(new string[] { "hello", "leetcode" });
            bool result1 = dic.Search("hello");
            bool result2 = dic.Search("hhllo");
            bool result3 = dic.Search("hell");
            bool result4 = dic.Search("leetcoded");
        }
    }

    public class MagicDictionary
    {
        Trie trie;

        /** Initialize your data structure here. */
        public MagicDictionary()
        {
            trie = new Trie();
        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {
            foreach (var word in dict)
            {
                trie.InsertString(word);
            }
        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            return Helper(word, 0, trie.root, 0);
        }

        bool Helper(string word, int index,Node node, int count)
        {
            if (count > 1)
            {
                return false;
            }
            if(index==word.Length)
            {
                if (count == 1 && node.isEndOfWord == true) return true;
                return false;
            }
            for (int j = 0; j < 26; j++)
            {
                if (node.childs[j] != null)
                {                    
                    bool result;
                    if(word[index]-'a'==j)
                    {
                        result = Helper(word, index + 1, node.childs[j], count);
                    }
                    else
                    {
                        result = Helper(word, index + 1, node.childs[j], count + 1);
                    }                    
                    if (result == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class Node
    {
        public bool isEndOfWord;
        public Node[] childs = new Node[26];        
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
        }        
    }
}
