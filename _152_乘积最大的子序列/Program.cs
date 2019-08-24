using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _152_乘积最大的子序列
{
    /*
    给定一个整数数组 nums ，找出一个序列中乘积最大的连续子序列（该序列至少包含一个数）。
    示例 1:

    输入: [2,3,-2,4]
    输出: 6
    解释: 子数组 [2,3] 有最大乘积 6。

    示例 2:

    输入: [-2,0,-1]
    输出: 0
    解释: 结果不能为 2, 因为 [-2,-1] 不是子数组。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-product-subarray
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int MaxProduct(int[] nums)//同时记录最大值和最小值
        {
            int max = nums[0], min = nums[0], res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    int tmp = max;
                    max = min;
                    min = tmp;
                }
                max = Math.Max(nums[i], max * nums[i]);
                min = Math.Min(nums[i], min * nums[i]);
                res = Math.Max(max, res);
            }
            return res;
            
        }
    }
}
