using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _85_最大矩形
{
    /*
        给定一个仅包含 0 和 1 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。

    示例:

    输入:
    [
      ["1","0","1","0","0"],
      ["1","0","1","1","1"],
      ["1","1","1","1","1"],
      ["1","0","0","1","0"]
    ]
    输出: 6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximal-rectangle
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length < 1) return 0;
            int[][] newMatrix = new int[matrix.Length][];
            newMatrix[0] = new int[matrix[0].Length];
            for (int i = 0; i < matrix[0].Length; i++)
            {
                if(matrix[0][i]=='0')
                {
                    newMatrix[0][i] = 0;
                }
                else
                {
                    newMatrix[0][i] = 1;
                }
            }
            for (int i = 1; i < newMatrix.Length; i++)
            {
                newMatrix[i] = new int[matrix[i].Length];
                for (int j = 0; j < newMatrix[i].Length; j++)
                {
                    if(matrix[i][j]=='0')
                    {
                        newMatrix[i][j] = 0;
                    }
                    else
                    {
                        newMatrix[i][j] = newMatrix[i - 1][j] + 1;
                    }
                }
            }
            int maxArea = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int[] tempArray = newMatrix[i];
                maxArea = Math.Max(maxArea, LargestRectangleArea(tempArray));
            }
            return maxArea;
        }

        public static int LargestRectangleArea(int[] heights)
        {
            int[] arrayL = new int[heights.Length];//前一个更小元素的索引
            int[] arrayR = new int[heights.Length];//后一个更小元素的索引

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    arrayL[i] = stack.Peek();
                }
                else
                {
                    arrayL[i] = -1;
                }
                stack.Push(i);
            }
            stack.Clear();
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    arrayR[i] = stack.Peek();
                }
                else
                {
                    arrayR[i] = heights.Length;
                }
                stack.Push(i);
            }

            int max = 0;
            int temp;
            for (int i = 0; i < heights.Length; i++)
            {
                temp = (arrayR[i] - arrayL[i] - 1) * heights[i];
                max = Math.Max(max, temp);
            }
            return max;
        }
    }
}
