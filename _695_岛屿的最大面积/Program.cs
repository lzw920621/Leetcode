using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _695_岛屿的最大面积
{
    /*
    给定一个包含了一些 0 和 1的非空二维数组 grid , 一个 岛屿 是由四个方向 (水平或垂直) 的 1 (代表土地) 构成的组合。
    你可以假设二维矩阵的四个边缘都被水包围着。
    找到给定的二维数组中最大的岛屿面积。(如果没有岛屿，则返回面积为0。)

    示例 1:

    [[0,0,1,0,0,0,0,1,0,0,0,0,0],
     [0,0,0,0,0,0,0,1,1,1,0,0,0],
     [0,1,1,0,1,0,0,0,0,0,0,0,0],
     [0,1,0,0,1,1,0,0,1,0,1,0,0],
     [0,1,0,0,1,1,0,0,1,1,1,0,0],
     [0,0,0,0,0,0,0,0,0,0,1,0,0],
     [0,0,0,0,0,0,0,1,1,1,0,0,0],
     [0,0,0,0,0,0,0,1,1,0,0,0,0]]

    对于上面这个给定矩阵应返回 6。注意答案不应该是11，因为岛屿只能包含水平或垂直的四个方向的‘1’。

    示例 2:

    [[0,0,0,0,0,0,0,0]]

    对于上面这个给定的矩阵, 返回 0。

    注意: 给定的矩阵grid 的长度和宽度都不超过 50。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/max-area-of-island
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[2][] { new int[] { 0, 1 }, new int[] { 1, 1 } };
            int max = MaxAreaOfIsland(grid);
        }

        public static int MaxAreaOfIsland(int[][] grid)
        {
            int max = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j]==1)
                    {
                        max = Math.Max(max, GetArea(grid, i, j));
                    }                    
                }
            }
            return max;
        }

        public static int GetArea(int[][] grid,int x,int y)
        {            
            grid[x][y] = 0;
            int num = 1;
            if(x-1>=0 && grid[x-1][y]==1)
            {
                num += GetArea(grid, x - 1, y);
            }
            if(x+1<grid.Length && grid[x+1][y]==1)
            {
                num += GetArea(grid, x + 1, y);
            }
            if(y-1>=0 && grid[x][y-1]==1)
            {
                num += GetArea(grid, x, y - 1);
            }
            if(y+1<grid[x].Length && grid[x][y+1]==1)
            {
                num += GetArea(grid, x, y + 1);
            }            
            return num;
        }
    }
}
