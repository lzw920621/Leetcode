using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _540_有序数组中的单一元素
{
    /*
        给定一个只包含整数的有序数组，每个元素都会出现两次，唯有一个数只会出现一次，找出这个数。
    示例 1:
    输入: [1,1,2,3,3,4,4,8,8]
    输出: 2

    示例 2:
    输入: [3,3,7,7,10,11,11]
    输出: 10

    注意: 您的方案应该在 O(log n)时间复杂度和 O(1)空间复杂度中运行。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/single-element-in-a-sorted-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = new Program().SingleNonDuplicate(new int[] { 3, 3, 7, 7, 10, 11, 11 });
        }

        public int SingleNonDuplicate(int[] nums)
        {
            return Assist(nums, 0, nums.Length - 1);
        }

        public int Assist(int[] nums,int left,int right)
        {
            int mid = left + (right - left) / 2;
            if (mid == 0 || mid == nums.Length - 1) return nums[mid];
            if (nums[mid] != nums[mid - 1] && nums[mid] != nums[mid + 1])
            {
                return nums[mid];
            }
            else if (nums[mid] != nums[mid - 1])
            {
                if(mid % 2 == 1)//mid是奇数
                {
                    return Assist(nums, left, mid - 1);
                }
                else//mid是偶数  说明mid之前都是出现两次的数
                {
                    return Assist(nums, mid+2, right);
                }
            }
            else
            {
                if (mid % 2 == 1)//mid是奇数 说明mid之前都是出现两次的数
                {
                    return Assist(nums, mid + 1, right);
                }
                else
                {
                    return Assist(nums, left, mid - 2);
                }
            }
        }
    }
}
