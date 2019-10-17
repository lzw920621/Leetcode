using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _341_扁平化嵌套列表迭代器
{
    /*
        给定一个嵌套的整型列表。设计一个迭代器，使其能够遍历这个整型列表中的所有整数。

    列表中的项或者为一个整数，或者是另一个列表。

    示例 1:

    输入: [[1,1],2,[1,1]]
    输出: [1,1,2,1,1]
    解释: 通过重复调用 next 直到 hasNext 返回false，next 返回的元素的顺序应该是: [1,1,2,1,1]。

    示例 2:

    输入: [1,[4,[6]]]
    输出: [1,4,6]
    解释: 通过重复调用 next 直到 hasNext 返回false，next 返回的元素的顺序应该是: [1,4,6]。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/flatten-nested-list-iterator
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class NestedIterator
        {
            List<int> list;
            int index = 0;

            public NestedIterator(IList<NestedInteger> nestedList)
            {
                list = new List<int>();
                Helper(nestedList, list);
            }

            void Helper(IList<NestedInteger> nestedList, List<int> list)//把值都取出来放入list里面
            {
                for (int i = 0; i < nestedList.Count; i++)
                {
                    if (nestedList[i].IsInteger())
                    {
                        list.Add(nestedList[i].GetInteger());
                    }
                    else
                    {
                        Helper(nestedList[i].GetList(), list);
                    }
                }
            }

            public bool HasNext()
            {
                return list.Count > index;
            }

            public int Next()
            {
                int temp = list[index];
                index++;
                return temp;
            }
        }
    }

    interface NestedInteger
    {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
}
