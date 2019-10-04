using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_组合总和II
{
    /*
        给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
    candidates 中的每个数字在每个组合中只能使用一次。

    说明：

        所有数字（包括目标数）都是正整数。
        解集不能包含重复的组合。 

    示例 1:

    输入: candidates = [10,1,2,7,6,1,5], target = 8,
    所求解集为:
    [
      [1, 7],
      [1, 2, 5],
      [2, 6],
      [1, 1, 6]
    ]

    示例 2:

    输入: candidates = [2,5,2,1,2], target = 5,
    所求解集为:
    [
      [1,2,2],
      [5]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/combination-sum-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = new Program().CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> list = new List<IList<int>>();
            Helper(candidates, 0, target, new List<int>(), list);

            return list;
        }
        void Helper(int[] candidates,int index,int target,IList<int> tempList, IList<IList<int>> list)
        {
            if(target == 0)
            {
                //for (int i = 0; i < list.Count; i++)//去重 效率不高
                //{
                //    if(list[i].SequenceEqual(tempList)==true)
                //    {
                //        return;
                //    }
                //}
                list.Add(tempList);
                return;
            }
            if (index>=candidates.Length || target < candidates[index]) return;
            for (int i = index; i < candidates.Length; i++)
            {
                if(i>index && candidates[i]==candidates[i-1])//去重 当前选出来的数等于当前层前一个分支选出来的数
                {
                    continue;
                }
                //拷贝一份 不影响下次递归
                IList<int> tempList2 = new List<int>(tempList);
                tempList2.Add(candidates[i]);
                Helper(candidates, i + 1, target - candidates[i], tempList2, list);
            }           
        }
    }
}
