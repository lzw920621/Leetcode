using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _485_最大连续1的个数
{
    /*
    给定一个二进制数组， 计算其中最大连续1的个数。

    示例 1:
    输入: [1,1,0,1,1,1]
    输出: 3
    解释: 开头的两位和最后的三位都是连续1，所以最大连续1的个数是 3.

    注意：
        输入的数组只包含 0 和1。
        输入数组的长度是正整数，且不超过 10,000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/max-consecutive-ones
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int max = 0;
            int temp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i]==0)
                {
                    temp = 0;
                }
                else
                {
                    temp++;
                    max = Math.Max(max, temp);
                }
            }
            return max;
        }
    }
}
