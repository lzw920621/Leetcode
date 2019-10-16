using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _665_非递减数列
{
    /*
        给定一个长度为 n 的整数数组，你的任务是判断在最多改变 1 个元素的情况下，该数组能否变成一个非递减数列。
    我们是这样定义一个非递减数列的： 对于数组中所有的 i (1 <= i < n)，满足 array[i] <= array[i + 1]。

    示例 1:

    输入: [4,2,3]
    输出: True
    解释: 你可以通过把第一个4变成1来使得它成为一个非递减数列。

    示例 2:

    输入: [4,2,1]
    输出: False
    解释: 你不能在只改变一个元素的情况下将其变为非递减数列。

    说明:  n 的范围为 [1, 10,000]。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/non-decreasing-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public bool CheckPossibility(int[] nums)
        {
            int count = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    count++;
                    if (count > 1) return false;
                    //nums[i - 1] > nums[i]的情况下有两种选择 1将nums[i-1]变小 2.将nums[i]变大
                    int temp = nums[i - 1];
                    nums[i - 1] = nums[i];//尝试将 nums[i-1]变小
                    if (i - 2 >= 0)
                    {
                        if (nums[i - 2] > nums[i - 1])//说明nums[i - 1]变小不可行 会破坏前面的一致性
                        {
                            nums[i - 1] = temp;//恢复nums[i - 1]原值
                            nums[i] = nums[i - 1];//将nums[i]变大
                        }
                    }
                }
            }
            return count <= 1;
        }
    }
}
