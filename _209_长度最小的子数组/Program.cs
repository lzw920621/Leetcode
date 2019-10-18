using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _209_长度最小的子数组
{
    /*
        给定一个含有 n 个正整数的数组和一个正整数 s ，找出该数组中满足其和 ≥ s 的长度最小的连续子数组。如果不存在符合条件的连续子数组，返回 0。

    示例: 

    输入: s = 7, nums = [2,3,1,2,4,3]
    输出: 2
    解释: 子数组 [4,3] 是该条件下的长度最小的连续子数组。

    进阶:

    如果你已经完成了O(n) 时间复杂度的解法, 请尝试 O(n log n) 时间复杂度的解法。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-size-subarray-sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 3, 1, 2, 4, 3 };
            int length = MinSubArrayLen(7, array);
        }

        public static int MinSubArrayLen(int s, int[] nums)
        {
            if (nums.Length < 1) return 0;
            int left = 0;
            int right = 0;
            int length = int.MaxValue;
            int sum = nums[left];
            while(right<nums.Length)
            {
                if(sum<s)
                {
                    right++;
                    if(right<nums.Length)
                    {
                        sum += nums[right];
                    }                    
                }
                else //sum>=s
                {
                    length = Math.Min(length, right - left + 1);
                    sum -= nums[left];
                    left++;
                }
                if (left > right) break;
            }
            return length != int.MaxValue ? length : 0;
        }
    }
}
