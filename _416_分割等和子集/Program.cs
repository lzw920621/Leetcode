﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _416_分割等和子集
{
    /*
        给定一个只包含正整数的非空数组。是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。

    注意:
        每个数组中的元素不会超过 100
        数组的大小不会超过 200

    示例 1:

    输入: [1, 5, 11, 5]
    输出: true

    解释: 数组可以分割成 [1, 5, 5] 和 [11].
    
    示例 2:

    输入: [1, 2, 3, 5]
    输出: false

    解释: 数组不能分割成两个元素和相等的子集.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/partition-equal-subset-sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool result = new Program().CanPartition(new int[] { 1, 2, 3, 5, 1, 2, 3, 3 });
        }

        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum % 2 == 1) return false;//总和为奇数 false
            int target = sum / 2;

            Array.Sort(nums);
            Array.Reverse(nums);
            return Helper(nums, 1, target - nums[0]);
        }

        bool Helper(int[] nums,int index,int target)
        {
            if (target == 0) return true;
            if (index>=nums.Length || target < 0) return false;

            for (int i = index; i < nums.Length; i++)
            {
                if(target>=nums[i])
                {
                    if(Helper(nums,i+1,target-nums[i])==true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
