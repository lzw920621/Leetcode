﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _796_所有可能的路径
{
    /*
        给一个有 n 个结点的有向无环图，找到所有从 0 到 n-1 的路径并输出（不要求按顺序）
    二维数组的第 i 个数组中的单元都表示有向图中 i 号结点所能到达的下一些结点（译者注：有向图是有方向的，即规定了a→b你就不能从b→a）
    空就是没有下一个结点了。

    示例:
    输入: [[1,2], [3], [3], []] 
    输出: [[0,1,3],[0,2,3]] 
    解释: 图是这样的:
    0--->1
    |    |
    v    v
    2--->3
    这有两条路: 0 -> 1 -> 3 和 0 -> 2 -> 3.

    提示:

        结点的数量会在范围 [2, 15] 内。
        你可以把路径以任意顺序输出，但在路径内的结点的顺序必须保证。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/all-paths-from-source-to-target
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (graph.Length < 1) return list;

            Helper(graph, 0, list, new List<int>());
            return list;
        }

        void Helper(int[][] graph,int index, IList<IList<int>> list,List<int> tempList)
        {
            if(index==graph.Length-1)
            {
                tempList.Add(index);
                list.Add(new List<int>(tempList));
                tempList.RemoveAt(tempList.Count - 1);
                return;
            }

            tempList.Add(index);
            for (int i = 0; i < graph[index].Length; i++)
            {
                Helper(graph, graph[index][i], list, tempList);
            }
            tempList.RemoveAt(tempList.Count - 1);
        }
    }
}
