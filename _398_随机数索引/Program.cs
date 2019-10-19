using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _398_随机数索引
{
    /*
        给定一个可能含有重复元素的整数数组，要求随机输出给定的数字的索引。 您可以假设给定的数字一定存在于数组中。

    注意：
    数组大小可能非常大。 使用太多额外空间的解决方案将不会通过测试。

    示例:

    int[] nums = new int[] {1,2,3,3,3};
    Solution solution = new Solution(nums);

    // pick(3) 应该返回索引 2,3 或者 4。每个索引的返回概率应该相等。
    solution.pick(3);

    // pick(1) 应该返回 0。因为只有nums[0]等于1。
    solution.pick(1);

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/random-pick-index
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        Dictionary<int, List<int>> dic;
        Random rd = new Random();
        public Solution(int[] nums)
        {
            dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]].Add(i);
                }
                else
                {
                    dic[nums[i]] = new List<int> { i };
                }
            }
        }

        public int Pick(int target)
        {
            int count = dic[target].Count;
            return dic[target][rd.Next(0, count)];
        }
    }

    public class Solution2
    {

        int[] nums;

        public Solution2(int[] nums)
        {
            this.nums = nums;
        }

        public int Pick(int target)
        {
            int n = 0;
            int choice = -1;
            var rand = new Random();
            for (var i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != target) continue;

                ++n;
                if (rand.Next(n) == 0) choice = i;
            }

            return choice;
        }
    }
}
