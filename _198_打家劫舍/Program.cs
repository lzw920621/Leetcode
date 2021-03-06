﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _198_打家劫舍
{
    /*
    你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。

    给定一个代表每个房屋存放金额的非负整数数组，计算你在不触动警报装置的情况下，能够偷窃到的最高金额。

    示例 1:

    输入: [1,2,3,1]
    输出: 4
    解释: 偷窃 1 号房屋 (金额 = 1) ，然后偷窃 3 号房屋 (金额 = 3)。
         偷窃到的最高金额 = 1 + 3 = 4 。

    示例 2:

    输入: [2,7,9,3,1]
    输出: 12
    解释: 偷窃 1 号房屋 (金额 = 2), 偷窃 3 号房屋 (金额 = 9)，接着偷窃 5 号房屋 (金额 = 1)。
         偷窃到的最高金额 = 2 + 9 + 1 = 12 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/house-robber
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = Rob(new int[] { 1, 2, 3, 1 });
        }

        public static int Rob(int[] nums)//迭代法
        {
            if (nums.Length == 0) return 0;

            if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 2)
            {
                return nums[0] > nums[1] ? nums[0] : nums[1];
            }

            int[] tempArray = new int[nums.Length];
            tempArray[0] = nums[0];
            tempArray[1] = nums[0] > nums[1] ? nums[0] : nums[1];
            for (int i = 2; i < nums.Length; i++)
            {
                tempArray[i] = Math.Max(tempArray[i - 1], tempArray[i - 2] + nums[i]);
            }
            return tempArray[nums.Length - 1];
        }


        public static int Rob_(int[] nums,int n)//递归法
        {
            if(n==0)
            {
                return 0;
            }
            else if(n==1)
            {
                return nums[0];
            }
            else if(n==2)
            {
                return (nums[0] > nums[1]) ? nums[0] : nums[1];
            }
            else
            {
                int num1 = Rob_(nums, n - 1);
                int num2 = Rob_(nums, n - 2) + nums[n - 1];
                return num1 > num2 ? num1 : num2;
            }
        }

        
    }
}
