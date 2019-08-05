using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_在排序数组中查找元素的第一个和最后一个位置
{
    /*
    给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
    你的算法时间复杂度必须是 O(log n) 级别。
    如果数组中不存在目标值，返回 [-1, -1]。

    示例 1:

    输入: nums = [5,7,7,8,8,10], target = 8
    输出: [3,4]

    示例 2:

    输入: nums = [5,7,7,8,8,10], target = 6
    输出: [-1,-1]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length<1) return new int[] { -1, -1 };
            int firstIndex=-1, lastIndex=-1;
            //起始位置
            if(nums[0]==target)
            {
                firstIndex = 0;
            }
            else
            {
                if(SearchFirst(nums,target,1,nums.Length-1,ref firstIndex)==false)//没有找到目标数的开始位置(数组中不存在目标数)
                {
                    return new int[] { -1, -1 };
                }                
            }
            if (firstIndex == nums.Length - 1 || nums[firstIndex + 1] > target)//目标数在数组中只出现一次
            {
                return new int[] { firstIndex, firstIndex };
            }

            //结束位置
            if (nums[nums.Length-1]==target)
            {
                lastIndex = nums.Length - 1;
            }
            else
            {
                SearchLast(nums, target, firstIndex + 1, nums.Length - 2, ref lastIndex);//查找目标数的结束位置
            }

            return new int[] { firstIndex, lastIndex };
        }
        public bool SearchFirst(int[] nums,int target,int left,int right,ref int index)
        {
            if (left > right) return false;
            int mid = (left + right) / 2;
            if(nums[mid]==target && nums[mid-1]<target)//找到的数是第一个目标数
            {
                index = mid;
                return true;
            }
            else if(nums[mid]>target)
            {
                return SearchFirst(nums, target, left, mid - 1, ref index);
            }
            else if(nums[mid]<target)
            {
                return SearchFirst(nums, target, mid + 1, right, ref index);
            }
            else//nums[mid]==target nums[mid-1]=target找到的不是第一个目标数的位置
            {
                return SearchFirst(nums, target, left, mid - 1, ref index);
            }
        }

        public bool SearchLast(int[] nums,int target,int left,int right,ref int index)
        {
            if (left > right) return false;
            int mid = (left + right) / 2;
            if (nums[mid] == target && nums[mid+1]>target)//找到的数是目标数的结束位置
            {
                index = mid;
                return true;
            }
            else if (nums[mid] > target)
            {
                return SearchLast(nums, target, left, mid - 1, ref index);
            }
            else if(nums[mid]<target)
            {
                return SearchLast(nums, target, mid + 1, right, ref index);
            }
            else//找到的不是目标数的结束位置
            {
                return SearchLast(nums, target, mid + 1, right, ref index);
            }
        }
    }
}
