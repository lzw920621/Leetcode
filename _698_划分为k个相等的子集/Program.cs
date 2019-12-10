using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _698_划分为k个相等的子集
{
    /*
        给定一个整数数组  nums 和一个正整数 k，找出是否有可能把这个数组分成 k 个非空子集，其总和都相等。

    示例 1：

    输入： nums = [4, 3, 2, 3, 5, 2, 1], k = 4
    输出： True
    说明： 有可能将其分成 4 个子集（5），（1,4），（2,3），（2,3）等于总和。
    
    注意:
        1 <= k <= len(nums) <= 16
        0 < nums[i] < 10000

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/partition-to-k-equal-sum-subsets
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            bool result = new Program().CanPartitionKSubsets(new int[] { 4, 3, 2, 3, 5, 2, 1 }, 4);
        }

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = nums.Sum();
            if (sum % k > 0) return false;
            Array.Sort(nums);
            Array.Reverse(nums);            
            int avg = sum / k;
            if (nums[0] > avg) return false;

            bool[] assistArray = new bool[nums.Length];

            return Helper(nums, assistArray, 0,avg,k,0);
            
        }

        bool Helper(int[] nums, bool[] assistArray, int subSum,int target,int k,int startIndex)
        {
            if (k==0) return true;
            if(subSum==target)
            {
                return Helper(nums, assistArray, 0, target, k-1, 0);
            }
            if (subSum > target) return false;
            
            for (int i = startIndex; i < nums.Length; i++)
            {                
                if(assistArray[i]==false)
                {                    
                    assistArray[i] = true;
                    if(Helper(nums, assistArray, subSum + nums[i], target, k, startIndex + 1))
                    {
                        return true;
                    }
                    assistArray[i] = false;
                }
            }

            return false;
        }

       
    }
}
