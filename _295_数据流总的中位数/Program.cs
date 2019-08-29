using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _295_数据流中的中位数
{
    /*
    中位数是有序列表中间的数。如果列表长度是偶数，中位数则是中间两个数的平均值。

    例如，

    [2,3,4] 的中位数是 3
    [2,3] 的中位数是 (2 + 3) / 2 = 2.5

    设计一个支持以下两种操作的数据结构：

        void addNum(int num) - 从数据流中添加一个整数到数据结构中。
        double findMedian() - 返回目前所有元素的中位数。

    示例：

    addNum(1)
    addNum(2)
    findMedian() -> 1.5
    addNum(3) 
    findMedian() -> 2

    进阶:

        如果数据流中所有整数都在 0 到 100 范围内，你将如何优化你的算法？
        如果数据流中 99% 的整数都在 0 到 100 范围内，你将如何优化你的算法？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-median-from-data-stream
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            MedianFinder medianFinder = new MedianFinder();
            medianFinder.AddNum(1);
            medianFinder.AddNum(2);
            double num1=medianFinder.FindMedian();
            medianFinder.AddNum(3);
            double num2 = medianFinder.FindMedian();

            medianFinder.AddNum(2);
            double num3 = medianFinder.FindMedian();
        }
    }

    public class MedianFinder
    {
        List<int> list = new List<int>();
        
        public MedianFinder()
        {
            
        }

        public void AddNum(int num)
        {
            if (list.Count == 0)
            {
                list.Add(num);
                return;
            }
            if (num <= list[0])
            {
                list.Insert(0, num);//小于list的第一个元素,则将其插到首位
                return;
            }
            if (num >= list[list.Count - 1])
            {
                list.Add(num);//大于list的最后一个元素,则将其添加到末尾
                return;
            }
            InsertIntoList(list, num,0,list.Count-1);
        }

        public double FindMedian()
        {                        
            if((list.Count&1)==1)//奇数
            {
                return list[list.Count / 2];
            }
            else
            {
                return (list[list.Count / 2] + list[list.Count / 2 - 1]) / 2.0;
            }
        }

        static void InsertIntoList(List<int> list,int num,int left,int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            if(num>=list[mid])
            {
                if(num<=list[mid+1])
                {
                    list.Insert(mid + 1, num);
                }
                else
                {
                    InsertIntoList(list, num, mid + 1, right);
                }
            }
            else
            {
                if (num >= list[mid - 1])
                {
                    list.Insert(mid, num);
                }
                else
                {
                    InsertIntoList(list, num, left, mid - 1);
                }
            }
        }
    }
}
