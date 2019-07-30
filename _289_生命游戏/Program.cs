using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _289_生命游戏
{
    /*
    根据百度百科，生命游戏，简称为生命，是英国数学家约翰·何顿·康威在1970年发明的细胞自动机。

    给定一个包含 m × n 个格子的面板，每一个格子都可以看成是一个细胞。每个细胞具有一个初始状态 live（1）即为活细胞， 或 dead（0）即为死细胞。每个细胞与其八个相邻位置（水平，垂直，对角线）的细胞都遵循以下四条生存定律：

        如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡；
        如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活；
        如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
        如果死细胞周围正好有三个活细胞，则该位置死细胞复活；

    根据当前状态，写一个函数来计算面板上细胞的下一个（一次更新后的）状态。下一个状态是通过将上述规则同时应用于当前状态下的每个细胞所形成的，其中细胞的出生和死亡是同时发生的。

    示例:

    输入: 
    [
      [0,1,0],
      [0,0,1],
      [1,1,1],
      [0,0,0]
    ]
    输出: 
    [
      [0,0,0],
      [1,0,1],
      [0,1,1],
      [0,1,0]
    ]

    进阶:

        你可以使用原地算法解决本题吗？请注意，面板上所有格子需要同时被更新：你不能先更新某些格子，然后使用它们的更新后的值再更新其他格子。
        本题中，我们使用二维数组来表示面板。原则上，面板是无限的，但当活细胞侵占了面板边界时会造成问题。你将如何解决这些问题？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/game-of-life
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid1 = new int[][]{
                                             new int[] { 0, 1, 0 },
                                             new int[] { 0, 0, 1 },
                                             new int[] { 1, 1, 1 },
                                             new int[] { 0, 0, 0 }
                                        };            
            GameOfLife(grid1);
        }
        public static void GameOfLife(int[][] board)//2表示下一次死亡 3表示下一次复活
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    int numOfLivingCell = GetAdjacentLiveCell(board, i, j);//相邻活细胞数量
                    if (board[i][j]==0)//当前细胞是 死亡状态
                    {
                        if (numOfLivingCell == 3)//死细胞周围有3个活细胞 则该细胞下一次复活
                        {
                            board[i][j] = 3;//3表示下次复活状态
                        }
                    }
                    else if(board[i][j]==1)//当前细胞是 存活状态
                    {
                        if(numOfLivingCell!=2 && numOfLivingCell!=3)//周围活细胞少于 两个 或 多于3个 则该细胞下一次死亡
                        {
                            board[i][j] = 2;//2表示下次死亡状态
                        }                        
                    }
                }
            }
            //刷新下一次的状态
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    switch(board[i][j])
                    {
                        case 2:board[i][j] = 0;break;
                        case 3:board[i][j] = 1;break;
                    }
                }
            }
        }

        public static int GetAdjacentLiveCell(int[][] board,int x,int y)//获取相邻活细胞的数量
        {
            int numOfLivingCell = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;//跳过(x,y)

                    int x1 = x + i;
                    int y1 = y + j;
                    if(x1>-1 && x1<board.Length && y1>-1 && y1<board[x1].Length)
                    {
                        if(board[x1][y1]==1 || board[x1][y1] == 2)
                        {
                            numOfLivingCell++;
                        }
                    }
                }
            }
            return numOfLivingCell;
        }
    }
}
