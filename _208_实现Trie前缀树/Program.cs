using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _208_实现Trie前缀树
{
    /*
        实现一个 Trie (前缀树)，包含 insert, search, 和 startsWith 这三个操作。
    示例:

    Trie trie = new Trie();

    trie.insert("apple");
    trie.search("apple");   // 返回 true
    trie.search("app");     // 返回 false
    trie.startsWith("app"); // 返回 true
    trie.insert("app");   
    trie.search("app");     // 返回 true

    说明:

        你可以假设所有的输入都是由小写字母 a-z 构成的。
        保证所有输入均为非空字符串。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/implement-trie-prefix-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Trie
    {
        Node node;

        /** Initialize your data structure here. */
        public Trie()
        {
            node = new Node();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Node tempNode = node;
            for (int i = 0; i < word.Length; i++)
            {
                if(tempNode.childs[word[i]-'a']!=null)
                {
                    tempNode = tempNode.childs[word[i] - 'a'];
                }
                else
                {
                    tempNode.childs[word[i] - 'a'] = new Node();
                    tempNode = tempNode.childs[word[i] - 'a'];
                }
            }
            tempNode.isEnd = true;//单词结束标志位
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Node tempNode = node;
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
            return tempNode.isEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Node tempNode = node;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (tempNode.childs[prefix[i] - 'a'] != null)
                {
                    tempNode = tempNode.childs[prefix[i] - 'a'];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Node
    {
        public bool isEnd = false;//是否有单词以 此节点 为结尾
        public Node[] childs = new Node[26]; 
    }
}
