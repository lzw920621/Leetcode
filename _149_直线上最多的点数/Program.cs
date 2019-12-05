using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _149_直线上最多的点数
{
    /*
        给定一个二维平面，平面上有 n 个点，求最多有多少个点在同一条直线上。

    示例 1:

    输入: [[1,1],[2,2],[3,3]]
    输出: 3
    解释:
    ^
    |
    |        o
    |     o
    |  o  
    +------------->
    0  1  2  3  4

    示例 2:

    输入: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
    输出: 4
    解释:
    ^
    |
    |  o
    |     o        o
    |        o
    |  o        o
    +------------------->
    0  1  2  3  4  5  6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/max-points-on-a-line
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxPoints(int[][] points)
        {
            int maxCount = 0;
            Dictionary<Point, int> dic = new Dictionary<Point, int>();
            foreach (var point in points)
            {
                Point tempPoint = new Point(point[0], point[1]);
                if(dic.ContainsKey(tempPoint))
                {
                    dic[tempPoint]++;
                }
                else
                {
                    dic[tempPoint] = 1;
                }
                maxCount = Math.Max(maxCount, dic[tempPoint]);
            }
            
            foreach (var point1 in dic.Keys)
            {
                foreach (var point2 in dic.Keys)
                {
                    if(point1.x==point2.x && point1.y==point2.y)
                    {
                        continue;
                    }
                    else
                    {
                        int tempCount = 0;
                        long diff_X = point1.x - point2.x;
                        long diff_Y = point1.y - point2.y;
                        foreach (var point in dic.Keys)
                        {
                            int tempDiff_X = point.x - point1.x;
                            int tempDiff_Y = point.y - point1.y;
                            if (tempDiff_X * diff_Y == tempDiff_Y * diff_X)
                            {
                                tempCount += dic[point];
                            }
                        }
                        maxCount = Math.Max(maxCount, tempCount);
                    }
                }
            }
            return maxCount;
        }
        struct Point
        {
            public int x;
            public int y;
            public Point(int x,int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
