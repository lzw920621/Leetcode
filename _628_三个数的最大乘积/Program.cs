﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _628_三个数的最大乘积
{
    /*
    给定一个整型数组，在数组中找出由三个数组成的最大乘积，并输出这个乘积

    示例 1:
    输入: [1,2,3]
    输出: 6

    示例 2:
    输入: [1,2,3,4]
    输出: 24

    注意:
        给定的整型数组长度范围是[3,104]，数组中所有的元素范围是[-1000, 1000]。
        输入的数组中任意三个数的乘积不会超出32位有符号整数的范围。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-product-of-three-numbers
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            if(nums[1]<0)
            {
                int num1 = nums[0] * nums[1] * nums[nums.Length - 1];
                int num2 = nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
                return num1 > num2 ? num1 : num2;
            }
            else
            {
                return nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3];
            }
        }
    }
}
