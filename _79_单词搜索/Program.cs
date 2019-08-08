using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _79_单词搜索
{
    /*
    给定一个二维网格和一个单词，找出该单词是否存在于网格中。
    单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。
    同一个单元格内的字母不允许被重复使用。

    示例:

    board =
    [
      ['A','B','C','E'],
      ['S','F','C','S'],
      ['A','D','E','E']
    ]

    给定 word = "ABCCED", 返回 true.
    给定 word = "SEE", 返回 true.
    给定 word = "ABCB", 返回 false.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/word-search
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[3][] { new char[] { 'C', 'A', 'A' },
                                           new char[] { 'A', 'A', 'A' },
                                           new char[] { 'B', 'C', 'D' } };
            string word = "AAB";
            bool isTrue = Exist(board, word);

            //int n = sizeof(bool);
        }
        public static bool Exist(char[][] board, string word)
        {           
            if (string.IsNullOrEmpty(word)) return false;
            if (board == null || board[0].Length < 1) return false;
            if (word.Length > board.Length * board[0].Length) return false;

            bool[,] tempArray = new bool[board.Length, board[0].Length];//临时数组 记录已使用的字符位置
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {                              
                    if (GetNext(board, tempArray, i, j, word, 0)) return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="board">包含候选字符的二维网格</param>
        /// <param name="tempArray">临时数组 用来记录已使用过的字符位置</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="word">要匹配的单词</param>
        /// <param name="indexOfCurrentChar">单词中要匹配的字符的索引</param>
        /// <returns></returns>
        static bool GetNext(char[][] board, bool[,] tempArray,int x,int y,string word,int indexOfCurrentChar)//回溯算法
        {
            if(x<0 || x >=board.Length || y<0 || y>= board[0].Length)
            {
                return false;
            }
            if (board[x][y] == word[indexOfCurrentChar] && tempArray[x, y] == false)//和目标字符相同 且未被使用 则查找下一个
            {
                tempArray[x, y] = true;//记录已使用过的字符
                if (indexOfCurrentChar == word.Length - 1) return true;//已经是最后一个字符 说明匹配成功
                if (GetNext(board, tempArray, x-1, y, word, indexOfCurrentChar + 1)) return true;//匹配下一个
                if (GetNext(board, tempArray, x+1, y, word, indexOfCurrentChar + 1)) return true;//匹配下一个
                if (GetNext(board, tempArray, x, y-1, word, indexOfCurrentChar + 1)) return true;//匹配下一个
                if (GetNext(board, tempArray, x, y+1, word, indexOfCurrentChar + 1)) return true;//匹配下一个
                tempArray[x, y] = false;//走到这里说明匹配失败 需要回溯 将记录值重置
            }

            return false;
        }
    }
}
