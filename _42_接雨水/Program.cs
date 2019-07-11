using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_接雨水
{
    /*
    给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。

    上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 感谢 Marcos 贡献此图。

    示例:

    输入: [0,1,0,2,1,0,1,3,2,1,2,1]
    输出: 6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/trapping-rain-water
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = Trap1(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }

        public static int Trap(int[] height)
        {
            if (height.Length <= 2) return 0;
            int sumArray = height.Sum();//sumArray表示柱子高度之和
            int heightest1 = int.MinValue;
            int heightest1_Index=0;
            int heightest2 = int.MinValue;
            int heightest2_Index=0;
            for (int i = 0; i < height.Length; i++)//寻找 从左往右 的最大值 以及 索引
            {
                if(height[i]>heightest1)
                {
                    heightest1_Index = i;
                    heightest1 = height[i];
                }                
            }
            for (int i = height.Length-1; i >=0; i--)//寻找 从右往左 的最大值 以及 索引
            {
                if (height[i] > heightest2)
                {
                    heightest2_Index = i;
                    heightest2 = height[i];
                }
            }
            int temp1=0;
            int temp1_Index = 0;
            int sum1=0;
            for (int i = 0; i <= heightest1_Index; i++)
            {
                if(height[i]>temp1)
                {
                    sum1 += (i - temp1_Index) * temp1;
                    temp1 = height[i];
                    temp1_Index = i;
                }
            }
            int temp2 = 0;
            int temp2_Index = height.Length - 1;
            int sum2 = 0;
            for (int i = height.Length-1; i>=heightest2_Index; i--)
            {
                if(height[i]>temp2)
                {
                    sum2 += (temp2_Index-i) * temp2;
                    temp2 = height[i];
                    temp2_Index = i;
                }
            }

            return sum1 + sum2 + (heightest2_Index - heightest1_Index + 1) * heightest1 - sumArray;
        }

        public static int Trap1(int[] height)
        {
            if (height.Length <= 2) return 0;
            int sumArray = height.Sum();//sumArray表示柱子高度之和
            int heightest1 = int.MinValue;
            int heightest1_Index = 0;
            //int heightest2 = int.MinValue;
            int heightest2_Index = 0;
            for (int i = 0; i < height.Length; i++)//寻找 从左往右 的最大值 以及 索引
            {
                if (height[i] > heightest1)
                {
                    heightest1_Index = i;
                    heightest1 = height[i];
                }
            }
            for (int i = height.Length - 1; i >= 0; i--)//寻找 从右往左 的最大值 以及 索引
            {
                if (height[i] == heightest1)
                {
                    heightest2_Index = i;
                    break;
                }
            }
            int temp1 =0;            
            int sum1 = 0;
            for (int i = 0; i < heightest1_Index; i++)
            {
                if (height[i] > temp1)
                {
                    temp1 = height[i];                                       
                }
                sum1 += temp1;
            }
            int temp2 = 0;
            int sum2 = 0;
            for (int i = height.Length - 1; i > heightest2_Index; i--)
            {
                if (height[i] > temp2)
                {                    
                    temp2 = height[i];
                }
                sum2 += temp2;
            }

            return sum1 + sum2 + (heightest2_Index - heightest1_Index + 1) * heightest1 - sumArray;
        }
    }
}
