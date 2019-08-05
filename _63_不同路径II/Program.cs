using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _63_不同路径II
{
    /*
    一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。
    机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
    现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
    网格中的障碍物和空位置分别用 1 和 0 来表示。

    说明：m 和 n 的值均不超过 100。

    示例 1:

    输入:
    [
      [0,0,0],
      [0,1,0],
      [0,0,0]
    ]
    输出: 2
    解释:
    3x3 网格的正中间有一个障碍物。
    从左上角到右下角一共有 2 条不同的路径：
    1. 向右 -> 向右 -> 向下 -> 向下
    2. 向下 -> 向下 -> 向右 -> 向右

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/unique-paths-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            ////左上角或右下角有障碍物,则没有可到达的路径
            if (obstacleGrid[0][0] == 1 || obstacleGrid[obstacleGrid.Length-1][obstacleGrid[0].Length-1]==1) return 0;

            int[,] assistArray = new int[obstacleGrid.Length,obstacleGrid[0].Length];//辅助数组,记录每个格点的最短路径            
            assistArray[0,0] = 1;
            for (int i = 1; i < obstacleGrid[0].Length; i++)//第一行
            {
                if(obstacleGrid[0][i]==1 || assistArray[0,i-1]==0)
                {
                    assistArray[0,i] = 0;
                }
                else
                {
                    assistArray[0,i] = 1;
                }                
            }
            for (int i = 1; i < obstacleGrid.Length; i++)//第一列
            {
                if(obstacleGrid[i][0]==1 || assistArray[i-1,0]==0)
                {
                    assistArray[i,0] = 0;
                }
                else
                {
                    assistArray[i,0] = 1;
                }
            }
            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                for (int j = 1; j < obstacleGrid[i].Length; j++)
                {
                    if(obstacleGrid[i][j]==1)
                    {
                        assistArray[i,j] = 0;
                    }
                    else
                    {
                        assistArray[i,j] = assistArray[i - 1,j] + assistArray[i,j - 1];
                    }                   
                }
            }
            return assistArray[obstacleGrid.Length - 1, obstacleGrid[0].Length - 1];
        }
    }
}
