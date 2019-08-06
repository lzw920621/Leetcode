using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _852_山脉数组的顶峰索引
{
    /*
    我们把符合下列属性的数组 A 称作山脉：
    A.length >= 3
    存在 0 < i < A.length - 1 使得A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1]

    给定一个确定为山脉的数组，返回任何满足 A[0] < A[1] < ... A[i-1] < A[i] > A[i+1] > ... > A[A.length - 1] 的 i 的值。
    
    示例 1：

    输入：[0,1,0]
    输出：1

    示例 2：

    输入：[0,2,1,0]
    输出：1
    
    提示：
        3 <= A.length <= 10000
        0 <= A[i] <= 10^6
        A 是如上定义的山脉

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/peak-index-in-a-mountain-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int PeakIndexInMountainArray(int[] A)
        {
            return FindeIndex(A, 0, A.Length - 1);
        }
        public int FindeIndex(int[] A,int left,int right)//二分查找
        {
            if (left > right) return -1;
            int mid = (left + right) / 2;
            if(A[mid]>A[mid-1])
            {
                if(A[mid]>A[mid+1])//找到顶峰索引
                {
                    return mid;
                }
                else//左山腰
                {
                    return FindeIndex(A, mid + 1, right);
                }
            }
            else  //A[mid]<=A[mid-1] 右山腰
            {
                return FindeIndex(A, left, mid - 1);
            }
        }
    }
}
