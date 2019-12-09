using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _212_单词搜索II
{
    /*
        给定一个二维网格 board 和一个字典中的单词列表 words，找出所有同时在二维网格和字典中出现的单词。
    单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。
    同一个单元格内的字母在一个单词中不允许被重复使用。

    示例:

    输入: 
    words = ["oath","pea","eat","rain"] and board =
    [
      ['o','a','a','n'],
      ['e','t','a','e'],
      ['i','h','k','r'],
      ['i','f','l','v']
    ]

    输出: ["eat","oath"]

    说明:
    你可以假设所有输入都由小写字母 a-z 组成。

    提示:

        你需要优化回溯算法以通过更大数据量的测试。你能否早点停止回溯？
        如果当前单词不存在于所有单词的前缀中，则可以立即停止回溯。什么样的数据结构可以有效地执行这样的操作？散列表是否可行？为什么？ 
        前缀树如何？如果你想学习如何实现一个基本的前缀树，请先查看这个问题： 实现Trie（前缀树）。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/word-search-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[4][]
            {
                new char[]{ 'o', 'a', 'a', 'n' },
                new char[]{ 'e', 't', 'a', 'e' },
                new char[]{ 'i', 'h', 'k', 'r' },
                new char[]{ 'i', 'f', 'l', 'v' }
            };
            string[] words = new string[] { "oath", "pea", "eat", "rain" };
            IList<string> list = new Program().FindWords(board, words);
            
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            IList<string> list = new List<string>();

            if (board.Length < 1 || words.Length < 1) return list;

            Trie trie = new Trie();
            foreach (var word in words)
            {
                trie.Insert(word);
            }

            bool[,] assistArray = new bool[board.Length, board[0].Length];
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Helper(board, assistArray, i, j, trie.node, sb, list);
                }
            }

            return list.Distinct().ToList();
        }

        void Helper(char[][] board, bool[,] assistArray,int x,int y,Node node, StringBuilder sb,IList<string> list)
        {
            if (assistArray[x, y] == true) return;
            if (node == null || node.childs[board[x][y] - 'a']==null) return;
            
            sb.Append(board[x][y]);
            if(node.childs[board[x][y] - 'a'].isEnd==true)
            {
                list.Add(sb.ToString());
            }

            assistArray[x, y] = true;
            Node currentNode = node.childs[board[x][y] - 'a'];
            if(x-1>=0)
            {
                Helper(board, assistArray, x - 1, y, currentNode, sb, list);
            }
            if(x+1<board.Length)
            {
                Helper(board, assistArray, x + 1, y, currentNode, sb, list);
            }
            if(y-1>=0)
            {
                Helper(board, assistArray, x, y - 1, currentNode, sb, list);
            }
            if(y+1<board[x].Length)
            {
                Helper(board, assistArray, x, y + 1, currentNode, sb, list);
            }
            
            assistArray[x, y] = false;
            sb.Remove(sb.Length - 1, 1);
        }
    }

    public class Trie
    {
        public Node node;

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

    public class Node
    {
        public bool isEnd = false;//是否有单词以 此节点 为结尾
        public Node[] childs = new Node[26];
    }
}
