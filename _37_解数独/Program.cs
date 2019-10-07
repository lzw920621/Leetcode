using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _37_解数独
{
    /*
        编写一个程序，通过已填充的空格来解决数独问题。

    一个数独的解法需遵循如下规则：

        数字 1-9 在每一行只能出现一次。
        数字 1-9 在每一列只能出现一次。
        数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。

    空白格用 '.' 表示。

    一个数独。

    答案被标成红色。

    Note:

        给定的数独序列只包含数字 1-9 和字符 '.' 。
        你可以假设给定的数独只有唯一解。
        给定数独永远是 9x9 形式的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sudoku-solver
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void SolveSudoku(char[][] board)
        {
            BackTrace(board, 0);
        }

        bool BackTrace(char[][] board,int index)
        {
            if(index==81)
            {
                return true;
            }

            int rowIndex = index / 9;
            int colomnIndex = index % 9;

            if(board[rowIndex][colomnIndex]>='1')
            {
                return BackTrace(board, index + 1);
            }
            else
            {
                int blockRowIndex = rowIndex / 3;
                int blockColomnIndex = colomnIndex / 3;

                for (int k = 1; k < 10; k++)
                {
                    board[rowIndex][colomnIndex] = (char)(k + '0');
                    if(!IsRowValid(board,rowIndex) || !IsColomnValid(board,colomnIndex) || !IsBoxValid(board,blockRowIndex,blockColomnIndex))
                    {
                        board[rowIndex][colomnIndex] = '.';
                    }
                    else
                    {
                        if(!BackTrace(board,index+1))
                        {
                            board[rowIndex][colomnIndex] = '.';
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            

        }

        bool IsRowValid(char[][] board, int rowIndex)
        {
            int[] map = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (board[rowIndex][i] >= '1')
                {
                    map[board[rowIndex][i] - '1']++;
                    if (map[board[rowIndex][i] - '1'] > 1) return false;
                }
            }
            return true;
        }

        bool IsColomnValid(char[][] board, int colomnIndex)
        {
            int[] map = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (board[i][colomnIndex] >= '1')
                {
                    map[board[i][colomnIndex] - '1']++;
                    if (map[board[i][colomnIndex] - '1'] > 1) return false;
                }
            }
            return true;
        }

        bool IsBoxValid(char[][] board, int rowIndex, int colomnIndex)
        {
            int[] map = new int[9];
            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colomnIndex; j < colomnIndex + 3; j++)
                {
                    if (board[i][j] >= '1')
                    {
                        map[board[i][j] - '1']++;
                        if (map[board[i][j] - '1'] > 1) return false;
                    }
                }
            }
            return true;
        }
    }
}
