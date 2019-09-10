using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _41_缺失的第一个正数
{
    /*
    给定一个未排序的整数数组，找出其中没有出现的最小的正整数。

    示例 1:

    输入: [1,2,0]
    输出: 3

    示例 2:

    输入: [3,4,-1,1]
    输出: 2

    示例 3:

    输入: [7,8,9,11,12]
    输出: 1

    说明:

    你的算法的时间复杂度应为O(n)，并且只能使用常数级别的空间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/first-missing-positive
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = FirstMissingPositive(new int[] { 3, 4, -1, 1 });
        }

        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length < 1) return 1;

            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] > 0 && nums[i] <= nums.Length && nums[nums[i] - 1] != nums[i])
                {
                    temp = nums[nums[i]-1];
                    nums[nums[i]-1] = nums[i];
                    nums[i] = temp;
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i+1)
                {
                    return i+1;
                }
            }

            return nums.Length + 1;
        }
    }
}
