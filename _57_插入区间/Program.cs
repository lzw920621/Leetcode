using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57_插入区间
{
    /*
        给出一个无重叠的 ，按照区间起始端点排序的区间列表。
    在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。

    示例 1:

    输入: intervals = [[1,3],[6,9]], newInterval = [2,5]
    输出: [[1,5],[6,9]]

    示例 2:

    输入: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    输出: [[1,2],[3,10],[12,16]]
    解释: 这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/insert-interval
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> List = new List<int[]>();

            bool flag = false;//newInerval是否已插入
            for (int i = 0; i < intervals.Length; i++)
            {
                if(!flag)
                {
                    if (newInterval[0] > intervals[i][1])
                    {
                        List.Add(intervals[i]);
                    }
                    else if (newInterval[1] < intervals[i][0])
                    {
                        List.Add(newInterval);
                        List.Add(intervals[i]);
                        flag = true;
                    }
                    else//intervals[i]区间和 tempArray有重叠
                    {
                        newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                        newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                    }
                }
                else
                {
                    List.Add(intervals[i]);
                }
                
            }
            if(flag==false)
            {
                List.Add(newInterval);
            }

            return List.ToArray();
        }
    }
}
