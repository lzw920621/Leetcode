using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_寻找两个有序数组的中位数
{
    /*
    给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。
    请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。
    你可以假设 nums1 和 nums2 不会同时为空。

    示例 1:
    nums1 = [1, 3]
    nums2 = [2]

    则中位数是 2.0

    示例 2:
    nums1 = [1, 2]
    nums2 = [3, 4]

    则中位数是 (2 + 3)/2 = 2.5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/median-of-two-sorted-arrays
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        // 合并为一个数组 再找中位数 时间复杂度O(m+n)
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {           
            int[] nums3 = new int[nums1.Length + nums2.Length];
            int index = 0;
            int i = 0;
            int j = 0;
            while(i<nums1.Length && j<nums2.Length)
            {
                if(nums1[i]<=nums2[j])
                {
                    nums3[index] = nums1[i];
                    i++;
                    index++;
                }
                else
                {
                    nums3[index] = nums2[j];
                    j++;
                    index++;
                }
            }
            while(i<nums1.Length)
            {
                nums3[index] = nums1[i];
                i++;
                index++;
            }
            while(j<nums2.Length)
            {
                nums3[index] = nums2[j];
                j++;
                index++;
            }

            if(nums3.Length%2==1)//长度为奇数
            {
                return nums3[nums3.Length / 2];
            }
            else
            {
                return (nums3[nums3.Length / 2] + nums3[nums3.Length / 2 - 1]) / 2.0;
            }
        }

        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            //TODO
        }
    }
}
