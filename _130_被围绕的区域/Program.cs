using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _130_被围绕的区域
{
    /*
    给定一个二维的矩阵，包含 'X' 和 'O'（字母 O）。
    找到所有被 'X' 围绕的区域，并将这些区域里所有的 'O' 用 'X' 填充。

    示例:

    X X X X
    X O O X
    X X O X
    X O X X

    运行你的函数后，矩阵变为：

    X X X X
    X X X X
    X X X X
    X O X X

    解释:

    被围绕的区间不会存在于边界上，换句话说，任何边界上的 'O' 都不会被填充为 'X'
    任何不在边界上，或不与边界上的 'O' 相连的 'O' 最终都会被填充为 'X'。
    如果两个元素在水平或垂直方向相邻，则称它们是“相连”的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/surrounded-regions
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[2][] 
            {
                //new char[] { 'X', 'X', 'X', 'X' } ,
                //new char[] { 'X', 'O', 'O', 'X' } ,
                //new char[] { 'X', 'X', 'O', 'X' } ,
                //new char[] { 'X', 'O', 'X', 'X' }
                new char[] { 'O', 'O' },
                new char[] { 'O', 'O' }
            };
            Solve(board);
        }

        public static void Solve(char[][] board)
        {
            if (board.Length < 1 || board[0].Length < 1) return;

            bool[,] assist = new bool[board.Length, board[0].Length];

            for (int i = 0; i < board.Length; i++)
            {
                if(board[i][0]=='O')
                {
                    SetNeigbour(board, i, 0,assist);
                }
                if(board[i][board[i].Length-1]=='O')
                {
                    SetNeigbour(board, i, board[i].Length - 1,assist);
                }
            }
            for (int j = 1; j < board[0].Length-1; j++)
            {
                if(board[0][j]=='O')
                {
                    SetNeigbour(board, 0, j, assist);
                }
                if(board[board.Length-1][j]=='O')
                {
                    SetNeigbour(board, board.Length - 1, j, assist);
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j]=='O' && assist[i,j]==false)
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }

        static void SetNeigbour(char[][] board,int x,int y,bool[,] assist)
        {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[x].Length)
            {
                return;
            }
            if(board[x][y]=='X' || assist[x,y]==true)
            {
                return;
            }
            else
            {
                assist[x, y] = true;

                SetNeigbour(board, x - 1, y, assist);
                SetNeigbour(board, x + 1, y, assist);
                SetNeigbour(board, x, y - 1, assist);
                SetNeigbour(board, x, y + 1, assist);
            }
        }
    }
}
