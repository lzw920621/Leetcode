﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220_存在重复元素III
{
    /*
        给定一个整数数组，判断数组中是否有两个不同的索引 i 和 j，使得 nums [i] 和 nums [j] 的差的绝对值最大为 t，
    并且 i 和 j 之间的差的绝对值最大为 ķ。

    示例 1:

    输入: nums = [1,2,3,1], k = 3, t = 0
    输出: true

    示例 2:

    输入: nums = [1,0,1,1], k = 1, t = 2
    输出: true

    示例 3:

    输入: nums = [1,5,9,1,5,9], k = 2, t = 3
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/contains-duplicate-iii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
            bool result = new Program().ContainsNearbyAlmostDuplicate2(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3);
            
        }

        //穷举法 超时
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length && j<=i+k; j++)
                {
                    if(Math.Abs(nums[i]-nums[j])<=t)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsNearbyAlmostDuplicate2(int[] nums, int k, int t)
        {
            
        }

        
    }
}
