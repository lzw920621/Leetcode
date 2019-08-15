using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _503_下一个更大的元素II
{
    /*
    给定一个循环数组（最后一个元素的下一个元素是数组的第一个元素），输出每个元素的下一个更大元素。
    数字 x 的下一个更大的元素是按数组遍历顺序，这个数字之后的第一个比它更大的数，这意味着你应该循环地搜索它的下一个更大的数。
    如果不存在，则输出 -1。

    示例 1:
    输入: [1,2,1]
    输出: [2,-1,2]
    解释: 第一个 1 的下一个更大的数是 2；
    数字 2 找不到下一个更大的数； 
    第二个 1 的下一个最大的数需要循环搜索，结果也是 2。

    注意: 输入数组的长度不会超过 10000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/next-greater-element-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 1 };
            int[] nums2 = NextGreaterElements(nums);
        }

        public static int[] NextGreaterElements(int[] nums)
        {
            int[] nums2 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if(nums[j]>nums[i])
                    {
                        nums2[i] = nums[j];
                        goto GetOut;
                    }
                }
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        nums2[i] = nums[j];
                        goto GetOut;
                    }
                }
                nums2[i] = -1;
            GetOut:;
            }
            return nums2;
        }

        public static int[] NextGreaterElements2(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = nums.Length*2-1; i >=0; i--)
            {
                int j = i % nums.Length;
                while (stack.Count > 0 && stack.Peek() <= nums[j])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    dic[j] = stack.Peek();
                }
                else
                {
                    dic[j] = -1;
                }
                stack.Push(nums[j]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = dic[i];
            }
            return nums;
        }

    }
}
