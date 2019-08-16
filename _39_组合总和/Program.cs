using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _39_组合总和
{
    /*
    给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
    candidates 中的数字可以无限制重复被选取。
    说明：
        所有数字（包括 target）都是正整数。
        解集不能包含重复的组合。 

    示例 1:

    输入: candidates = [2,3,6,7], target = 7,
    所求解集为:
    [
      [7],
      [2,2,3]
    ]

    示例 2:

    输入: candidates = [2,3,5], target = 8,
    所求解集为:
    [
      [2,2,2,2],
      [2,3,3],
      [3,5]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/combination-sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = CombinationSum(new int[] { 2, 3, 5 }, 8);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);//先排序
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> tempList = new List<int>();
            Assist(candidates, target, 0, list, tempList);

            return list;
        }

        public static void Assist(int[] candidates, int target, int index, IList<IList<int>> list1, IList<int> tempList)
        {
            if (target == 0)
            {
                list1.Add(tempList);
                return;
            }
            if (target < candidates[0]) return;

            for (int i = index; i < candidates.Length && candidates[i] <= target; i++)
            {
                //拷贝一份 不影响下次递归
                IList<int> list = new List<int>(tempList);
                list.Add(candidates[i]);
                //递归运算，将i传递至下一次运算是为了避免结果重复。
                Assist(candidates, target - candidates[i], i,list1,list);
            }
        }

    }
}
