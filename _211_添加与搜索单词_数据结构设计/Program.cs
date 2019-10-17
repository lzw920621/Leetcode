using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _211_添加与搜索单词_数据结构设计
{
    /*
        设计一个支持以下两种操作的数据结构：

    void addWord(word)
    bool search(word)

    search(word) 可以搜索文字或正则表达式字符串，字符串只包含字母 . 或 a-z 。 . 可以表示任何一个字母。

    示例:

    addWord("bad")
    addWord("dad")
    addWord("mad")
    search("pad") -> false
    search("bad") -> true
    search(".ad") -> true
    search("b..") -> true

    说明:

    你可以假设所有单词都是由小写字母 a-z 组成的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/add-and-search-word-data-structure-design
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //使用前缀树
    public class WordDictionary
    {
        Node node;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            node = new Node();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
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
                    tempNode.childs[word[i] - 'a'] = new Node();
                    tempNode = tempNode.childs[word[i] - 'a'];
                }
            }
            tempNode.isEnd = true;//单词结束标志位
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            char[] wordArray = word.ToCharArray();
            return SearchHelper(wordArray, 0, node);
        }

        bool SearchHelper(char[] array,int index,Node node)
        {
            if (index == array.Length)
            {                
                return node.isEnd;
            }
                
            if(array[index]=='.')
            {
                for (int i = 0; i < node.childs.Length; i++)
                {
                    if(node.childs[i]!=null)
                    {
                        if(SearchHelper(array,index+1,node.childs[i])==true)
                        {
                            return true;
                        }
                    }
                }                
            }
            else
            {
                if(node.childs[array[index]-'a']!=null)
                {
                    return SearchHelper(array, index + 1, node.childs[array[index] - 'a']);
                }                
            }
            return false;
        }
    }

    class Node
    {
        public bool isEnd = false;//是否有单词以 此节点 为结尾
        public Node[] childs = new Node[26];
    }
}
