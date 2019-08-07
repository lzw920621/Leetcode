﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _384_打乱数组
{
    /*
    打乱一个没有重复元素的数组。
    示例:

    // 以数字集合 1, 2 和 3 初始化数组。
    int[] nums = {1,2,3};
    Solution solution = new Solution(nums);

    // 打乱数组 [1,2,3] 并返回结果。任何 [1,2,3]的排列返回的概率应该相同。
    solution.shuffle();

    // 重设数组到它的初始状态[1,2,3]。
    solution.reset();

    // 随机返回数组[1,2,3]打乱后的结果。
    solution.shuffle();

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/shuffle-an-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution(new int[] { 1, 2, 3 });
            int[] newArray = solution.Shuffle();
            int[] nums = solution.Reset();
        }
    }
    public class Solution
    {
        private int[] nums;
        public Solution(int[] nums)
        {
            this.nums = nums;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return this.nums;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            if (nums == null || nums.Length < 1) return nums;
            int[] newArray = new int[nums.Length];
            nums.CopyTo(newArray, 0);
            Random rd = new Random();
            for (int i = nums.Length; i >0; i--)
            {
                Swap(newArray, i-1, rd.Next(0, i));
            }
            return newArray;
        }

        static void Swap(int[] array,int index1,int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }

}
