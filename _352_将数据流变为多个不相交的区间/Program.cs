using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _352_将数据流变为多个不相交的区间
{
    /*
        给定一个非负整数的数据流输入 a1，a2，…，an，…，将到目前为止看到的数字总结为不相交的区间列表。
    例如，假设数据流中的整数为 1，3，7，2，6，…，每次的总结为：

    [1, 1]
    [1, 1], [3, 3]
    [1, 1], [3, 3], [7, 7]
    [1, 3], [7, 7]
    [1, 3], [6, 7]

 
    进阶：
    如果有很多合并，并且与数据流的大小相比，不相交区间的数量很小，该怎么办?

    提示：
    特别感谢 @yunhong 提供了本问题和其测试用例。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class SummaryRanges
    {
        SortedSet<int> set;
        
        /** Initialize your data structure here. */
        public SummaryRanges()
        {
            set = new SortedSet<int>();
        }

        public void AddNum(int val)
        {
            set.Add(val);
        }

        public int[][] GetIntervals()
        {
            List<int[]> list = new List<int[]>();
            int start = 0;
            int pre = 0;
            int index = 0;
            foreach (var num in set)
            {
                if(index==0)
                {
                    start = num;
                    pre = num;
                    index++;
                    continue;
                }
                if(num==pre+1)
                {
                    pre++;
                }
                else//item!=pre+1
                {                    
                    list.Add(new int[] { start, pre });
                    start = num;
                    pre = num;
                }

                index++;
            }
            list.Add(new int[] { start, pre });
            return list.ToArray();
        }
    }

    
}
