using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_盛水最多的容器
{
    /*
    给定 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

    说明：你不能倾斜容器，且 n 的值至少为 2。

    图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。

 

    示例:

    输入: [1,8,6,2,5,4,8,3,7]
    输出: 49

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/container-with-most-water
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int area = MaxArea(new int[] { 5, 2, 12, 1, 5, 3, 4, 11, 9, 4});
        }

        public static int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int max = int.MinValue;
            
            while (left < right)
            {
                int temp = GetArea(height, left, right);
                
                if(height[left]<height[right])
                {
                    left++;                    
                }
                else
                {
                    right--;
                }
                
                max = Math.Max(max,temp);
            }
            return max;
        }
        public static int GetArea(int[] height,int left,int right)
        {
            return (height[left] > height[right]) ? (right - left) * height[right] : (right - left) * height[left];
        }
       
    }
}
