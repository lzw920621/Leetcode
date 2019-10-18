using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _216_组合总和III
{
    /*
        找出所有相加之和为 n 的 k 个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。

    说明：
        所有数字都是正整数。
        解集不能包含重复的组合。 

    示例 1:

    输入: k = 3, n = 7
    输出: [[1,2,4]]

    示例 2:

    输入: k = 3, n = 9
    输出: [[1,2,6], [1,3,5], [2,3,4]]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/combination-sum-iii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = new Program().CombinationSum3(3, 7);
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Helper(k, n, 1,new List<int>(), list);
            return list;
        }
        void Helper(int k,int target,int index,List<int> tempList, IList<IList<int>> list)
        {
            if(target == 0 && k==0)
            {
                list.Add(tempList);
                return;
            }
           
            for (int i = index; i < 10; i++)
            {
                if(target>=i)
                {
                    List<int> tempList2 = new List<int>(tempList);
                    tempList2.Add(i);
                    Helper(k-1, target - i, i + 1, tempList2, list);
                }
            }
        }


        public IList<IList<int>> CombinationSum3_1(int k, int n)
        {
            List<IList<int>> res = new List<IList<int>>();
            int[] seed = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            backtracking(seed, k, n, n, 0, new List<int>(), res);
            return res;
        }

        private void backtracking(int[] nums, int count, int target, int total, int start, List<int> path, List<IList<int>> res)
        {
            //Exist case
            if (count == 0 && path.Sum() == total)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                if (target >= nums[i])
                {
                    path.Add(nums[i]);
                    backtracking(nums, count - 1, target - nums[i], total, i + 1, path, res);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
