using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _78_子集
{
    /*
    给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。

    说明：解集不能包含重复的子集。

    示例:

    输入: nums = [1,2,3]
    输出:
    [
      [3],
      /[1],
      [2],
      /[1,2,3],
      [1,3],
      [2,3],
      /[1,2],
      []
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/subsets
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> newList = Subsets(new int[] { 1, 2, 3 });
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {            
            IList<IList<int>> set = new List<IList<int>>();
            if (nums.Length < 1)
            {
                return set;
            }
            else
            {                
                set.Add(new List<int>());//添加空集

                List<int> firstSubSet = new List<int>();
                firstSubSet.Add(nums[0]);

                set.Add(firstSubSet);//添加集合 {nums[0]}
                for (int i = 1; i < nums.Length; i++)
                {
                    Assist(set,nums[i]);//将新元素nums[i]添加到set中
                }
                return set;
            }
        }

        public static void Assist(IList<IList<int>> set,int num)
        {
            int count = set.Count;
            for (int i = 0; i < count; i++)
            {
                IList<int> tempList = new List<int>(set[i]);
                tempList.Add(num);
                set.Add(tempList);                
            }            
        }



        public IList<IList<int>> Subsets2(int[] nums)
        {
            IList<IList<int>> set = new List<IList<int>>();
            if (nums.Length < 1)
            {
                return set;
            }

            set.Add(new List<int>());//添加空集
            Helper(nums, 0, new List<int>(), set);
            return set;
        }

        void Helper(int[] nums,int index,List<int> tempList, IList<IList<int>> set)
        {
            for (int i = index; i < nums.Length; i++)
            {
                List<int> tempList2 = new List<int>(tempList);
                tempList2.Add(nums[i]);
                set.Add(tempList2);
                Helper(nums, i + 1, tempList2, set);
            }
        }
    }
}
