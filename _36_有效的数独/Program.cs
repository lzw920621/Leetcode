using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_有效的数独
{
    /*
        判断一个 9x9 的数独是否有效。只需要根据以下规则，验证已经填入的数字是否有效即可。

        数字 1-9 在每一行只能出现一次。
        数字 1-9 在每一列只能出现一次。
        数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。

    上图是一个部分填充的有效的数独。

    数独部分空格内已填入了数字，空白格用 '.' 表示。

    示例 1:

    输入:
    [
      ["5","3",".",".","7",".",".",".","."],
      ["6",".",".","1","9","5",".",".","."],
      [".","9","8",".",".",".",".","6","."],
      ["8",".",".",".","6",".",".",".","3"],
      ["4",".",".","8",".","3",".",".","1"],
      ["7",".",".",".","2",".",".",".","6"],
      [".","6",".",".",".",".","2","8","."],
      [".",".",".","4","1","9",".",".","5"],
      [".",".",".",".","8",".",".","7","9"]
    ]
    输出: true

    示例 2:

    输入:
    [
      ["8","3",".",".","7",".",".",".","."],
      ["6",".",".","1","9","5",".",".","."],
      [".","9","8",".",".",".",".","6","."],
      ["8",".",".",".","6",".",".",".","3"],
      ["4",".",".","8",".","3",".",".","1"],
      ["7",".",".",".","2",".",".",".","6"],
      [".","6",".",".",".",".","2","8","."],
      [".",".",".","4","1","9",".",".","5"],
      [".",".",".",".","8",".",".","7","9"]
    ]
    输出: false
    解释: 除了第一行的第一个数字从 5 改为 8 以外，空格内其他数字均与 示例1 相同。
         但由于位于左上角的 3x3 宫内有两个 8 存在, 因此这个数独是无效的。

    说明:

        一个有效的数独（部分已被填充）不一定是可解的。
        只需要根据以上规则，验证已经填入的数字是否有效即可。
        给定数独序列只包含数字 1-9 和字符 '.' 。
        给定数独永远是 9x9 形式的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-sudoku
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。



    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!IsRowValid(board, i) || !IsColomnValid(board, i)) return false;
            }
            for (int i = 0; i < 9; i+=3)
            {
                for (int j = 0; j < 9; j+=3)
                {
                    if (!IsBoxValid(board, i, j)) return false;                   
                }
            }
            return true;
        }

        bool IsRowValid(char[][] board,int rowIndex)
        {
            int[] map = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if(board[rowIndex][i]>='1')
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
            for (int i = rowIndex; i < rowIndex+3; i++)
            {
                for (int j = colomnIndex; j < colomnIndex+3; j++)
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


        public bool IsValidSudoku2(char[][] board)
        {
            // 记录某行，某位数字是否已经被摆放
            bool[][] row = new bool[9][];
            // 记录某列，某位数字是否已经被摆放
            bool[][] col = new bool[9][];
            // 记录某 3x3 宫格内，某位数字是否已经被摆放
            bool[][] block = new bool[9][];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        int num = board[i][j] - '1';
                        int blockIndex = i / 3 * 3 + j / 3;
                        if (row[i][num] || col[j][num] || block[blockIndex][num])
                        {
                            return false;
                        }
                        else
                        {
                            row[i][num] = true;
                            col[j][num] = true;
                            block[blockIndex][num] = true;
                        }
                    }
                }
            }
            return true;
        }
    }
}
