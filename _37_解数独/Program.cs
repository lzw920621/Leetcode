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
    struct Point
    {
        public int rowIndex;
        public int colomnIndex;
        public Point(int x,int y)
        {
            rowIndex = x;
            colomnIndex = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[9][] {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' },
            };

            new Program().SolveSudoku(board);
        }

        public void SolveSudoku(char[][] board)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(board[i][j]=='.')
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }

            BackTrace(board, points, 0);
        }
        //回溯算法
        bool BackTrace(char[][] board, List<Point> points, int index)
        {
            if(index==points.Count)
            {
                return true;
            }

            int blockRowIndex = points[index].rowIndex / 3 * 3;
            int blockColomnIndex = points[index].colomnIndex / 3 * 3;

            for (int k = 1; k < 10; k++)
            {            
                char tempChar= (char)(k + '0');
                if (IsRowValid(board, points[index].rowIndex,tempChar) && IsColomnValid(board, points[index].colomnIndex,tempChar) && IsBoxValid(board, blockRowIndex, blockColomnIndex,tempChar))
                {
                    board[points[index].rowIndex][points[index].colomnIndex] = tempChar;
                    if (BackTrace(board, points, index + 1)==true)
                    {
                        return true;                        
                    }
                    else
                    {
                        board[points[index].rowIndex][points[index].colomnIndex] = '.';
                    }                    
                }               
            }
            return false;
        }

        bool IsRowValid(char[][] board, int rowIndex,char value)
        {
            for (int i = 0; i < 9; i++)
            {                
                if (board[rowIndex][i] == value) return false;
            }
            return true;
        }

        bool IsColomnValid(char[][] board, int colomnIndex, char value)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][colomnIndex] == value) return false;
            }
            return true;
        }

        bool IsBoxValid(char[][] board, int rowIndex, int colomnIndex, char value)
        {           
            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colomnIndex; j < colomnIndex + 3; j++)
                {
                    if (board[i][j] == value) return false;
                }
            }
            return true;
        }
    }
}
