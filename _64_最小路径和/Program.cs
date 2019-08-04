using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_最小路径和
{
    /*
    给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
    说明：每次只能向下或者向右移动一步。

    示例:

    输入:
    [
      [1,3,1],
      [1,5,1],
      [4,2,1]
    ]
    输出: 7
    解释: 因为路径 1→3→1→1→1 的总和最小。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-path-sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
            int sum = MinPathSum(grid);
        }

        public static int MinPathSum(int[][] grid)
        {
            //return MinPathSum_Assist(grid, 0, 0, 0);
            int[][] assistArray = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                assistArray[i] = new int[grid[i].Length]; 
            }
            return MinPathSum2(grid, 0, 0, assistArray);
        }

        public int MinPathSum_Assist(int[][] grid,int x1,int y1,int temp)
        {
            if(x1<grid.Length-1)
            {
                if(y1<grid[0].Length-1)
                {
                    temp = temp + grid[x1][y1];
                    int sum1 = MinPathSum_Assist(grid, x1 + 1, y1, temp);
                    int sum2 = MinPathSum_Assist(grid, x1, y1 + 1, temp);
                    return Math.Min(sum1, sum2);
                }
                else//y1==grid[0].Length-1  已到达最后一列
                {
                    return temp + SumColoum(grid, y1, x1);
                }
            }
            else//x1==grid.Length-1 已到达最后一行
            {
                return temp + SumRow(grid, x1, y1);
            }
        }

        public static int SumRow(int[][] grid,int rowIndex,int startY)
        {
            int sum = 0;
            for (int i = startY; i < grid[rowIndex].Length; i++)
            {
                sum += grid[rowIndex][i];
            }
            return sum;
        }

        public static int SumColoum(int[][] grid, int columIndex, int startX)
        {
            int sum = 0;
            for (int i = startX; i < grid.Length; i++)
            {
                sum += grid[i][columIndex];
            }
            return sum;
        }

        //方法2
        public static int MinPathSum2(int[][] grid, int x1, int y1,int[][] assistArray)
        {
            if (x1 < grid.Length - 1)//未到达最后一行
            {
                if (y1 < grid[0].Length - 1)//未到达最后一列
                {
                    if (assistArray[x1][y1] > 0)//辅助数组assistArray中已有最小路径值
                    {
                        return assistArray[x1][y1];
                    }
                    else
                    {
                        int sum1 = grid[x1][y1] + MinPathSum2(grid, x1 + 1, y1, assistArray);
                        int sum2 = grid[x1][y1] + MinPathSum2(grid, x1, y1 + 1, assistArray);
                        int sum = Math.Min(sum1, sum2);
                        assistArray[x1][y1] = sum;
                        return sum;
                    }
                }
                else//y1==grid[0].Length-1  已到达最后一列
                {
                    if(assistArray[x1][y1]>0)
                    {
                        return assistArray[x1][y1];
                    }
                    else
                    {
                        int sum = SumColoum(grid, y1, x1);
                        assistArray[x1][y1] = sum;
                        return sum;
                    }
                }
            }
            else//x1==grid.Length-1 已到达最后一行
            {
                if (assistArray[x1][y1] > 0)
                {
                    return assistArray[x1][y1];
                }
                else
                {
                    int sum = SumRow(grid, x1, y1);
                    assistArray[x1][y1] = sum;
                    return sum;
                }
            }

            
        }

        
    }
}
