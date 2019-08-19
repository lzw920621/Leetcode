using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_搜索旋转排序数组
{
    /*
    假设按照升序排序的数组在预先未知的某个点上进行了旋转。
    ( 例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] )。
    搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
    你可以假设数组中不存在重复的元素。
    你的算法时间复杂度必须是 O(log n) 级别。

    示例 1:

    输入: nums = [4,5,6,7,0,1,2], target = 0
    输出: 4

    示例 2:

    输入: nums = [4,5,6,7,0,1,2], target = 3
    输出: -1

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = Search(new int[] { 3,1 }, 1);
        }

        public static int Search(int[] nums, int target)
        {
            return FindTarget(nums, 0, nums.Length - 1, target);
        }

        public static int FindTarget(int[] nums,int left,int right,int target) //4,5,6,7,0,1,2
        {
            if (left > right) return -1;

            int mid = (left + right) / 2;
            if (nums[mid] == target) return mid;
            
            if (nums[mid]>nums[left])//left->mid是有序的
            {
                if(target<nums[mid])
                {
                    if(target<nums[left])
                    {
                        return FindTarget(nums, mid + 1, right, target);
                    }
                    else   //nums[left]<target<nums[mid]
                    {
                        return FindTarget(nums, left, mid - 1, target);
                    }
                }
                else   //target>nums[mid]
                {
                    return FindTarget(nums, mid+1, right, target);
                }
            }
            else// mid->right有序
            {
                if (target > nums[right])
                {
                    return FindTarget(nums, left, mid - 1, target);
              
                }
                else   
                {
                    if (target < nums[mid])
                    {
                        return FindTarget(nums, left, mid - 1, target);
                    }
                    else
                    {
                        return FindTarget(nums, mid + 1, right, target);
                    }
                }
            }
        }
    }
}
