using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_合并区间
{
    /*
    给出一个区间的集合，请合并所有重叠的区间。

    示例 1:
    输入: [[1,3],[2,6],[8,10],[15,18]]
    输出: [[1,6],[8,10],[15,18]]
    解释: 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].

    示例 2:
    输入: [[1,4],[4,5]]
    输出: [[1,5]]
    解释: 区间 [1,4] 和 [4,5] 可被视为重叠区间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/merge-intervals
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[][] newIntervals = new int[4][] { new int[]{ 1, 3 },
                                                new int[] { 2, 6 },
                                                new int[] { 8, 10 },
                                                new int[]{15,18 }//[[1,3],[2,6],[8,10],[15,18]]
                                                };

            Partition(newIntervals, 0, 3);

            int[][] array=Merge(newIntervals);
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length < 1) return intervals;

            Partition(intervals, 0, intervals.Length - 1);
            List<int[]> list = new List<int[]>();
            int[] array1 = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= array1[1])
                {
                    if (intervals[i][1] > array1[1])
                    {
                        array1[1] = intervals[i][1];
                    }
                }
                else
                {
                    list.Add(array1);
                    array1 = intervals[i];
                }
            }
            list.Add(array1);
            int[][] newArray = new int[list.Count][];
            for (int i = 0; i < list.Count; i++)
            {
                newArray[i] = list[i];
            }
            return newArray;
        }

        public static void Partition(int[][] intervals,int left,int right)
        {
            if (left >= right) return;

            int pivot0 = intervals[left][0];
            int pivot1 = intervals[left][1];
            int l = left, r = right;
            while (l < r)
            {
                while (l < r && intervals[r][0] >= pivot0)
                {
                    r--;
                }
                intervals[l][0] = intervals[r][0];
                intervals[l][1] = intervals[r][1];
                while (l < r && intervals[l][0] <= pivot0)
                {
                    l++;
                }
                intervals[r][0] = intervals[l][0];
                intervals[r][1] = intervals[l][1];
            }
            intervals[l][0] = pivot0;
            intervals[l][1] = pivot1;

            Partition(intervals, left, l - 1);
            Partition(intervals, l + 1, right);
        }
    }
}
