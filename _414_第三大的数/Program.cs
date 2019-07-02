using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _414_第三大的数
{
    /*
    给定一个非空数组，返回此数组中第三大的数。如果不存在，则返回数组中最大的数。要求算法时间复杂度必须是O(n)。

    示例 1:

    输入: [3, 2, 1]

    输出: 1

    解释: 第三大的数是 1.

    示例 2:

    输入: [1, 2]

    输出: 2

    解释: 第三大的数不存在, 所以返回最大的数 2 .

    示例 3:

    输入: [2, 2, 3, 1]

    输出: 1

    解释: 注意，要求返回第三大的数，是指第三大且唯一出现的数。
    存在两个值为2的数，它们都排第二。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/third-maximum-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {

        }
        public int ThirdMax(int[] nums)
        {
            int?[] tempArray = new int?[3];
            tempArray[0] = nums[0];
            tempArray[1] = null;
            tempArray[2] = null;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > tempArray[0])
                {
                    tempArray[2] = tempArray[1];
                    tempArray[1] = tempArray[0];
                    tempArray[0] = nums[i];
                }
                else if (nums[i] == tempArray[0])
                {
                    continue;
                }
                else if ((tempArray[1].HasValue == false) || nums[i] > tempArray[1])
                {
                    tempArray[2] = tempArray[1];
                    tempArray[1] = nums[i];
                }
                else if (nums[i] == tempArray[1])
                {
                    continue;
                }
                else if ((tempArray[2].HasValue == false) || nums[i] > tempArray[2])
                {
                    tempArray[2] = nums[i];
                }
            }
            return tempArray[2].HasValue ? tempArray[2].Value : tempArray[0].Value;
        }
    }
}
