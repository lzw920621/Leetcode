using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81_搜索旋转排序数组II
{
    /*
    假设按照升序排序的数组在预先未知的某个点上进行了旋转。

    ( 例如，数组 [0,0,1,2,2,5,6] 可能变为 [2,5,6,0,0,1,2] )。

    编写一个函数来判断给定的目标值是否存在于数组中。若存在返回 true，否则返回 false。

    示例 1:

    输入: nums = [2,5,6,0,0,1,2], target = 0
    输出: true

    示例 2:

    输入: nums = [2,5,6,0,0,1,2], target = 3
    输出: false

    进阶:

        这是 搜索旋转排序数组 的延伸题目，本题中的 nums  可能包含重复元素。
        这会影响到程序的时间复杂度吗？会有怎样的影响，为什么？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool exist = Search(new int[] { 1, 3, 1, 1, 1 }, 3);
        }

        public static bool Search(int[] nums, int target)
        {
            return Assist(nums, 0, nums.Length - 1, target);
        }

        static bool Assist(int[] nums,int left,int right,int target)//nums数组可以看成 左右 两个 升序序列
        {
            if (left > right) return false;
            
            while(nums[left]==nums[right])
            {
                if(nums[left]==target)
                {
                    return true;
                }
                left++;
                right--;
                if (left > right) return false;
            }
            
            int mid = (left + right) / 2;
            if (nums[mid] == target) return true;

            
            if (nums[mid] >= nums[left]) //中点在左序列上
            {
                if (target < nums[mid] && target >= nums[left])
                {
                    return Assist(nums, left, mid - 1, target);
                }
                return Assist(nums, mid + 1, right, target);
            }
            else//中点在右序列上
            {
                if(target>nums[mid] && target<=nums[right])
                {
                    return Assist(nums, mid + 1, right, target);
                }
                return Assist(nums, left, mid - 1, target);
            }
            
        }


        public static bool Search2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) return true;
                if (nums[left] == nums[mid] && nums[mid] == nums[right])
                {
                    left++;
                    right--;
                }
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid]) right = mid - 1;
                    else left = mid + 1;
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right]) left = mid + 1;
                    else right = mid - 1;
                }
            }
            return false;
            
        }
    }
}
