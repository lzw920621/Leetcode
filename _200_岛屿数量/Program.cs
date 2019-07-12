using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200_岛屿数量
{
    /*
    给定一个由 '1'（陆地）和 '0'（水）组成的的二维网格，计算岛屿的数量。一个岛被水包围，并且它是通过水平方向或垂直方向上相邻的陆地连接而成的。你可以假设网格的四个边均被水包围。

    示例 1:

    输入:
    11110
    11010
    11000
    00000

    输出: 1

    示例 2:

    输入:
    11000
    11000
    00100
    00011

    输出: 3

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/number-of-islands
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            //[['1','1','0','0','0'],['1','1','0','0','0'],['0','0','1','0','0'],['0','0','0','1','1']]

            int num = NumIslands(new char[][]
            {
                new char[]{'1','1','0','0','0' },
                new char[]{ '1','1','0','0','0' },
                new char[]{ '0','0','1','0','0' },
                new char[]{ '0', '0', '0', '1', '1' }
               
            });
        }

        public static int NumIslands(char[][] grid)
        {
            if (grid.Length == 0) return 0;
           
            int numOfIslands = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {                    
                    if(grid[i][j]=='1')
                    {
                        numOfIslands++;
                        MarkIsland(i, j, grid);
                    }
                }
            }
            return numOfIslands;
        }
        
        public static void MarkIsland(int x,int y, char[][] grid)
        {
            if (x < 0 || y < 0 || x >= grid.Length || y >= grid[x].Length) return;

            if(grid[x][y]=='1')
            {
                grid[x][y] = '0';
                MarkIsland(x - 1, y, grid);
                MarkIsland(x + 1, y, grid);
                MarkIsland(x, y - 1, grid);
                MarkIsland(x, y + 1, grid);
            }
            return;
        }
    }
}
