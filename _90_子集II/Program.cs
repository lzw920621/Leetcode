using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _90_子集II
{
    /*
        给定一个可能包含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
    说明：解集不能包含重复的子集。

    示例:

    输入: [1,2,2]
    输出:
    [
      [2],
      [1],
      [1,2,2],
      [2,2],
      [1,2],
      []
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/subsets-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> set = new List<IList<int>>();
            if (nums.Length < 1)
            {
                return set;
            }

            Array.Sort(nums);
            set.Add(new List<int>());//添加空集
            Helper(nums, 0, new List<int>(), set);
            return set;
        }

        void Helper(int[] nums, int index, List<int> tempList, IList<IList<int>> set)
        {
            for (int i = index; i < nums.Length; i++)
            {
                if(i>index && nums[i]==nums[i-1])
                {
                    continue;
                }
                List<int> tempList2 = new List<int>(tempList);
                tempList2.Add(nums[i]);
                set.Add(tempList2);
                Helper(nums, i + 1, tempList2, set);
            }
        }

        
    }
}
