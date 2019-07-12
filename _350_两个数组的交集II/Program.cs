﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _350_两个数组的交集II
{
    /*
    给定两个数组，编写一个函数来计算它们的交集。

    示例 1:

    输入: nums1 = [1,2,2,1], nums2 = [2,2]
    输出: [2,2]

    示例 2:

    输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
    输出: [4,9]

    说明：

        输出结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致。
        我们可以不考虑输出结果的顺序。

    进阶:

        如果给定的数组已经排好序呢？你将如何优化你的算法？
        如果 nums1 的大小比 nums2 小很多，哪种方法更优？
        如果 nums2 的元素存储在磁盘上，磁盘内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/intersection-of-two-arrays-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Intersect(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 });
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length < 1 || nums2.Length < 1) return new int[0];

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if(dic.ContainsKey(nums1[i]))
                {
                    dic[nums1[i]]++;
                }
                else
                {
                    dic.Add(nums1[i], 1);
                }
            }

            List<int> list = new List<int>();
            for (int i = 0; i < nums2.Length; i++)
            {
                if(dic.ContainsKey(nums2[i]) && dic[nums2[i]]>0)
                {
                    list.Add(nums2[i]);
                    dic[nums2[i]]--;
                }
            }
            return list.ToArray();
        }
    }
}
