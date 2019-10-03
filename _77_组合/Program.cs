using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _77_组合
{
    /*
        给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
    示例:

    输入: n = 4, k = 2
    输出:
    [
      [2,4],
      [3,4],
      [2,3],
      [1,2],
      [1,3],
      [1,4],
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/combinations
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = new Program().Combine(4, 2);
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (n < k || k == 0) return list;
            int[] array = Enumerable.Range(1, n).ToArray();
            Assist(array, 0, k, new List<int>(), list);
            return list;
        }

        void Assist(int[] array, int start, int count, List<int> templist, IList<IList<int>> list)
        {
            if (count == 0)
            {
                list.Add(templist);
                return;
            }
            for (int i = start; i < array.Length - count + 1; i++)
            {
                List<int> tempList2 = CopyList(templist);
                tempList2.Add(array[i]);
                Assist(array, i + 1, count - 1, tempList2, list);
            }
        }

        public List<int> CopyList(List<int> list)
        {
            List<int> newList = new List<int>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }
    }
}
