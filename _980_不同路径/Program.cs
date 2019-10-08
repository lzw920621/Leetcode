using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _980_不同路径
{
        /*
        在二维网格 grid 上，有 4 种类型的方格：

        1 表示起始方格。且只有一个起始方格。
        2 表示结束方格，且只有一个结束方格。
        0 表示我们可以走过的空方格。
        -1 表示我们无法跨越的障碍。

    返回在四个方向（上、下、左、右）上行走时，从起始方格到结束方格的不同路径的数目，每一个无障碍方格都要通过一次。

 

    示例 1：

    输入：[[1,0,0,0],[0,0,0,0],[0,0,2,-1]]
    输出：2
    解释：我们有以下两条路径：
    1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2)
    2. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2)

    示例 2：

    输入：[[1,0,0,0],[0,0,0,0],[0,0,0,2]]
    输出：4
    解释：我们有以下四条路径： 
    1. (0,0),(0,1),(0,2),(0,3),(1,3),(1,2),(1,1),(1,0),(2,0),(2,1),(2,2),(2,3)
    2. (0,0),(0,1),(1,1),(1,0),(2,0),(2,1),(2,2),(1,2),(0,2),(0,3),(1,3),(2,3)
    3. (0,0),(1,0),(2,0),(2,1),(2,2),(1,2),(1,1),(0,1),(0,2),(0,3),(1,3),(2,3)
    4. (0,0),(1,0),(2,0),(2,1),(1,1),(0,1),(0,2),(0,3),(1,3),(1,2),(2,2),(2,3)

    示例 3：

    输入：[[0,1],[2,0]]
    输出：0
    解释：
    没有一条路能完全穿过每一个空的方格一次。
    请注意，起始和结束方格可以位于网格中的任意位置。

 

    提示：

        1 <= grid.length * grid[0].length <= 20

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/unique-paths-iii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。



    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int UniquePathsIII(int[][] grid)
        {
            int currentX=0, currentY=0;
            int countleft = grid.Length * grid[0].Length - 2;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if(grid[i][j]==1)
                    {
                        currentX = i;
                        currentY = j;
                    }
                    if(grid[i][j]==-1)
                    {
                        countleft--;
                    }
                }
            }
            int allWays = 0;
            Backtrace(grid, currentX, currentY, countleft, ref allWays);
            return allWays;
        }

        void Backtrace(int[][] grid,int currentX,int currentY,int countLeft,ref int allWays)
        {
            if(countLeft==0 && grid[currentX][currentY]==2)//到达终点且通过所有格子
            {
                allWays++;
                return;
            }
            if(countLeft>0)
            {
                if(currentX-1>=0 && grid[currentX-1][currentY]==0)
                {
                    grid[currentX - 1][currentY] = 3;//表示该网格已经走过
                    Backtrace(grid, currentX - 1, currentY, countLeft - 1, ref allWays);
                    grid[currentX - 1][currentY] = 0;//回溯
                }
                if(currentX+1<grid.Length && grid[currentX+1][currentY]==0)
                {
                    grid[currentX + 1][currentY] = 3;
                    Backtrace(grid, currentX + 1, currentY, countLeft - 1, ref allWays);
                    grid[currentX + 1][currentY] = 0;
                }
                if(currentY-1>=0 && grid[currentX][currentY-1]==0)
                {
                    grid[currentX][currentY - 1] = 3;
                    Backtrace(grid, currentX, currentY - 1, countLeft - 1, ref allWays);
                    grid[currentX][currentY - 1] = 0;
                }
                if(currentY+1<grid[0].Length && grid[currentX][currentY+1]==0)
                {
                    grid[currentX][currentY + 1] = 3;
                    Backtrace(grid, currentX, currentY + 1, countLeft - 1, ref allWays);
                    grid[currentX][currentY + 1] = 0;
                }
            }
            else//countLeft==0//已经走完所有非终点的格子 查看相邻格子是否有终点
            {
                if (currentX - 1 >= 0 && grid[currentX - 1][currentY] == 2)
                {
                    allWays++;
                    return;
                }
                if (currentX + 1 < grid.Length && grid[currentX + 1][currentY] == 2)
                {
                    allWays++;
                    return;
                }
                if (currentY - 1 >= 0 && grid[currentX][currentY - 1] == 2)
                {
                    allWays++;
                    return;
                }
                if (currentY + 1 < grid[0].Length && grid[currentX][currentY + 1] == 2)
                {
                    allWays++;
                    return;
                }
            }
        }
    }
}
