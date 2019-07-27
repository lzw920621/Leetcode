using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _189_旋转数组
{
    /*
    给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。

    示例 1:

    输入: [1,2,3,4,5,6,7] 和 k = 3
    输出: [5,6,7,1,2,3,4]
    解释:
    向右旋转 1 步: [7,1,2,3,4,5,6]
    向右旋转 2 步: [6,7,1,2,3,4,5]
    向右旋转 3 步: [5,6,7,1,2,3,4]

    示例 2:

    输入: [-1,-100,3,99] 和 k = 2
    输出: [3,99,-1,-100]
    解释: 
    向右旋转 1 步: [99,-1,-100,3]
    向右旋转 2 步: [3,99,-1,-100]

    说明:

        尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
        要求使用空间复杂度为 O(1) 的 原地 算法。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/rotate-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(array, 3);
        }

        public static void Rotate(int[] nums, int k)
        {
            int temp;
            k = k % (nums.Length);
            int k1 = nums.Length - k;
            if(k>k1)     //左移k1位;
            {
                for (int i = 0; i < k1; i++)
                {
                    temp = nums[0];
                    for (int j = 0; j <nums.Length; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[nums.Length-1] = temp;
                }
            }
            else         //右移k位
            {
                for (int i = 0; i < k; i++)
                {
                    temp = nums[nums.Length - 1];
                    for (int j = nums.Length - 1; j > 0; j--)
                    {
                        nums[j] = nums[j - 1];
                    }
                    nums[0] = temp;
                }
            }
            //TODO
        }

        
    }
}
