using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _283_移动0
{
    /*
    给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。

    示例:

    输入: [0,1,0,3,12]
    输出: [1,3,12,0,0]

    说明:

        必须在原数组上操作，不能拷贝额外的数组。
        尽量减少操作次数。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/move-zeroes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 4, 2, 4, 0, 0, 3, 0, 5, 1, 0};
            MoveZeroes(nums);
        }

        public static  void MoveZeroes(int[] nums)
        {
            int j;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    j = i + 1;
                    while (j < nums.Length && nums[j] == 0)//寻找最近的非零值
                    {
                        j++;
                    }
                    if (j < nums.Length)//交换位置
                    {
                        nums[i] = nums[j];
                        nums[j] = 0;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void MoveZeroes1(int[] nums)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)//从左往右寻找非零值 从索引0依次往后放置
            {
                if (nums[i] != 0)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            while (k < nums.Length)
            {
                nums[k] = 0;
                k++;
            }
        }
    }
}
