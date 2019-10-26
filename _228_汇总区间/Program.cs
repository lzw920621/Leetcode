using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _228_汇总区间
{
    /*
        给定一个无重复元素的有序整数数组，返回数组区间范围的汇总。
    示例 1:

    输入: [0,1,2,4,5,7]
    输出: ["0->2","4->5","7"]
    解释: 0,1,2 可组成一个连续的区间; 4,5 可组成一个连续的区间。

    示例 2:

    输入: [0,2,3,4,6,8,9]
    输出: ["0","2->4","6","8->9"]
    解释: 2,3,4 可组成一个连续的区间; 8,9 可组成一个连续的区间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/summary-ranges
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> list = new List<string>();
            if (nums.Length < 1) return list;

            int left = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if(nums[i]!=nums[i-1]+1)
                {
                    if (nums[i - 1] == left)
                    {
                        list.Add(left + "");
                    }
                    else
                    {
                        list.Add(left + "->" + nums[i - 1]);
                    }
                    left = nums[i];
                }                
            }
            if(nums[nums.Length-1]==left)
            {
                list.Add(left + "");
            }
            else
            {
                list.Add(left + "->" + nums[nums.Length - 1]);
            }
            return list;
        }
    }
}
