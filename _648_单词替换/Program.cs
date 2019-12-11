using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _648_单词替换
{
    /*
        在英语中，我们有一个叫做 词根(root)的概念，它可以跟着其他一些词组成另一个较长的单词——我们称这个词为 继承词(successor)。例如，词根an，跟随着单词 other(其他)，可以形成新的单词 another(另一个)。

    现在，给定一个由许多词根组成的词典和一个句子。你需要将句子中的所有继承词用词根替换掉。如果继承词有许多可以形成它的词根，则用最短的词根替换它。

    你需要输出替换之后的句子。

    示例 1:

    输入: dict(词典) = ["cat", "bat", "rat"]
    sentence(句子) = "the cattle was rattled by the battery"
    输出: "the cat was rat by the bat"

    注:

        输入只包含小写字母。
        1 <= 字典单词数 <=1000
        1 <=  句中词语数 <= 1000
        1 <= 词根长度 <= 100
        1 <= 句中词语长度 <= 1000

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/replace-words
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string ReplaceWords(IList<string> dict, string sentence)
        {
            Trie trie = new Trie();
            foreach (var word in dict)
            {
                trie.InsertString(word);
            }

            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                string temp = trie.GetPrefix(words[i]);
                if (temp!=null)
                {
                    words[i] = temp;
                }
            }
            return string.Join(" ", words);
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
                if(temp.childs[str[i]-'a']==null)
                {
                    temp.childs[str[i] - 'a'] = new Node();                    
                }
                temp = temp.childs[str[i] - 'a'];
            }
            temp.isEndOfWord = true;
            temp.str = str;
        }

        public string GetPrefix(string str)
        {
            Node temp = root;
            for (int i = 0; i < str.Length; i++)
            {
                if(temp.childs[str[i]-'a']==null)
                {
                    return null;
                }
                else
                {
                    temp = temp.childs[str[i] - 'a'];
                    if(temp.isEndOfWord)
                    {
                        return temp.str;
                    }
                }
            }
            return null;
        }
    }
}
