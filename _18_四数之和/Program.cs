using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_四数之和
{
    /*
    给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。

    注意：
    答案中不可以包含重复的四元组。

    示例：
    给定数组 nums = [1, 0, -1, 0, -2, 2]，和 target = 0。

    满足要求的四元组集合为：
    [
      [-1,  0, 0, 1],
      [-2, -1, 1, 2],
      [-2,  0, 0, 2]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/4sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            
            int left, right;
            int newTarget;
            for (int i = 0; i < nums.Length-3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;//去重
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;

                for (int j = i+1; j < nums.Length-2; j++)
                {
                    if (j - i > 1 && nums[j] == nums[j - 1]) continue;//去重
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target) break;

                    newTarget = target - nums[i] - nums[j];
                    left = j + 1;
                    right = nums.Length - 1;
                    while(left<right)
                    {
                        int temp = nums[left] + nums[right];
                        if(temp>newTarget)
                        {
                            right--;
                        }
                        else if(temp<newTarget)
                        {
                            left++;
                        }
                        else
                        {
                            List<int> tempList = new List<int> { nums[i], nums[j], nums[left], nums[right] };
                            if (list.Count == 0 || !Enumerable.SequenceEqual(tempList, list.Last()))
                            {
                                list.Add(tempList);
                            }
                            left++;
                            right--;
                        }
                    }
                }
            }

            return list;
        }


        
    }
}
