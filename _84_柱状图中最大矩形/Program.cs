using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _84_柱状图中最大矩形
{
    /*
    给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
    求在该柱状图中，能够勾勒出来的矩形的最大面积。
    以上是柱状图的示例，其中每个柱子的宽度为 1，给定的高度为 [2,1,5,6,2,3]。
    图中阴影部分为所能勾勒出的最大矩形面积，其面积为 10 个单位。

    示例:

    输入: [2,1,5,6,2,3]
    输出: 10

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/largest-rectangle-in-histogram
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */

    class Program
    {
        static void Main(string[] args)
        {
            int area = LargestRectangleArea2(new int[] { 1,1 });
        }

        public static int LargestRectangleArea1(int[] heights)//暴力法
        {
            int max = 0;
            int low;
            for (int i = 0; i < heights.Length; i++)
            {
                low = heights[i];
                for (int j = i; j < heights.Length; j++)
                {
                    if (heights[j] < low)
                    {
                        low = heights[j];
                    }
                    max = Math.Max(max, low * (j - i + 1));
                }
            }
            return max;
        }

        //
        public static int LargestRectangleArea(int[] heights)
        {
            if (heights.Length < 1) return 0;
            int max = 0;
            
            int tempWigth;
            int index;
            int lastHeight = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if(lastHeight==heights[i])
                {
                    continue;
                }
                lastHeight = heights[i];

                tempWigth = 1;                
                index = i;
                while(index>=0)
                {
                    index--;
                    if(index>=0 && heights[index]>= heights[i])
                    {
                        tempWigth++;
                    }
                    else
                    {
                        break;
                    }
                }
                index = i;
                while(index<heights.Length)
                {
                    index++;
                    if(index<heights.Length && heights[index]>= heights[i])
                    {
                        tempWigth++;
                    }
                    else
                    {
                        break;
                    }
                }

                max = Math.Max(max, heights[i] * tempWigth);
            }

            return max;
        }


        public static int LargestRectangleArea2(int[] heights)
        {
            int[] arrayL = new int[heights.Length];//前一个更小元素的索引
            int[] arrayR = new int[heights.Length];//后一个更小元素的索引

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while(stack.Count>0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                if(stack.Count>0)
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
            for (int i = heights.Length-1; i >=0; i--)
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
                temp = ( arrayR[i] - arrayL[i] -1 ) * heights[i];
                max = Math.Max(max, temp);
            }
            return max;
        }


    }
}
