﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _260_只出现一次的数字
{
    /*
    给定一个整数数组 nums，其中恰好有两个元素只出现一次，其余所有元素均出现两次。 找出只出现一次的那两个元素。

    示例 :

    输入: [1,2,1,3,2,5]
    输出: [3,5]

    注意：

        结果输出的顺序并不重要，对于上面的例子， [5, 3] 也是正确答案。
        你的算法应该具有线性时间复杂度。你能否仅使用常数空间复杂度来实现？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/single-number-iii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = SingleNumber(new int[] { 1, 2, 1, 3, 2, 5 });
        }

        public static int[] SingleNumber(int[] nums)
        {
            int a = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                a = a ^ nums[i];
            }
            int b = 1 ;
            int c = a & b;
            while(c==0)
            {
                b = b << 1;
                c = a & b;
            }
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            foreach (var item in nums)
            {
                if((c&item)==0)
                {
                    list1.Add(item);
                }
                else
                {
                    list2.Add(item);
                }
            }
            int num1 = list1[0];
            int num2 = list2[0];
            for (int i = 1; i < list1.Count; i++)
            {
                num1 = num1 ^ list1[i];
            }
            for (int i = 1; i < list2.Count; i++)
            {
                num2 = num2 ^ list2[i];
            }
            return new int[] { num1, num2 };
        }

        //public static int XOR(IEnumerable<int> list)
        //{

        //}

        public static int[] SingleNumber1(int[] nums)
        {
            /*
             * 数组中，有两个只出现了一次的数字，其余都出现了两次，找到这俩数字
             * 思路：
             *  1.若数组中，只有一个只出现了一次的数组，那么直接异或就好了
             *  2.那现在出现了两次，异或的结果是两个数的异或结果
             *  3.若能把数组分开，两个只出现一次的数字也能分开，那么问题就好解决了
             *  4.异或，本身表示的是“区别”
             *  5.基于上面的分析，可以依据区别来将数字分组，那么此种方式就一定能将两个数字分开
             *  
             * 时间复杂度：O(n)，对数字的有限遍历次数
             * 空间复杂度：O(1)，使用的额外空间稳定
             */

            //推导：依据题目的描述，数组的元素数量一定是大于2的

            //异或得到结果
            int r1 = 0;
            foreach (var numItem in nums)
                r1 ^= numItem;

            //得到要分组的位
            int p1 = 1;
            int sumTemp = p1 & r1;
            while (sumTemp != p1)
            {
                p1 = p1 << 1;
                sumTemp = p1 & r1;
            }

            //分组
            int forReturnNum1 = 0;
            int forReturnNum2 = 0;
            foreach (var numItem in nums)
            {
                if ((numItem & p1) == 0)
                    forReturnNum1 ^= numItem;
                else
                    forReturnNum2 ^= numItem;
            }

            //分别异或，得到结果值
            return new int[] { forReturnNum1, forReturnNum2 };
        }
    }
}
