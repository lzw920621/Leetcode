using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_最接近的三数之和
{
    /*
    给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。

    例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.

    与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2).

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/3sum-closest
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 2, 1, -4 };
            int sum = ThreeSumClosest(nums, 1);
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int dif = int.MaxValue;
            int sum = nums[0] + nums[1] + nums[2];
            int index1;
            int index2;
            for (int i = 0; i < nums.Length-2; i++)
            {
                index1 = i + 1;
                index2 = nums.Length - 1;
                while(index1<index2)
                {
                    int tempSum = nums[i] + nums[index1] + nums[index2];
                    if(tempSum>target)
                    {
                        if (Math.Abs(tempSum - target) < dif)
                        {
                            sum = tempSum;
                            dif = Math.Abs(tempSum - target);
                            //if (dif == 0) return sum;
                        }

                        index2--;
                    }
                    else if(tempSum<target)
                    {
                        if (Math.Abs(tempSum - target) < dif)
                        {
                            sum = tempSum;
                            dif = Math.Abs(tempSum - target);
                            //if (dif == 0) return sum;
                        }

                        index1++;
                    }
                    else//tempSum==target
                    {
                        return target;
                    }                    
                }
            }
            return sum;
        }
    }
}
