using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _215_数组中的第k个最大的元素
{
    /*
    在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。

    示例 1:

    输入: [3,2,1,5,6,4] 和 k = 2
    输出: 5

    示例 2:

    输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
    输出: 4

    说明:

    你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/kth-largest-element-in-an-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int FindKthLargest(int[] nums, int k)
        {
            int[] topK = TopK_1(nums, k);
            return topK[0];
        }

        public static int[] TopK_1(int[] data, int k)//利用 最小堆 的思路来实现
        {
            int[] topK_Array = new int[k];//建一个长度为k的数组 以此作为最小堆
            for (int i = 0; i < topK_Array.Length; i++)
            {
                topK_Array[i] = int.MinValue;
            }

            foreach (var item in data)
            {
                if (item > topK_Array[0])//topK_Array[0] 是最小堆的根元素(堆中最小的元素) 
                {
                    topK_Array[0] = item;//item大于堆顶元素时,将堆顶元素的值更换为item
                    MinHeapify(topK_Array, 0);//堆顶元素发生变化 调整最小堆
                }
            }
            return topK_Array;
        }
        /// <summary>
        /// 调整最小堆
        /// </summary>
        /// <param name="array">待调整的数组</param>
        /// <param name="currentIndex">待调整元素在数组中的位置</param>
        static void MinHeapify(int[] array, int currentIndex)
        {
            int leftIndex = 2 * currentIndex + 1;    //左子节点在数组中的位置
            int rightIndex = 2 * currentIndex + 2;   //右子节点在数组中的位置
            int SmallIndex = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最小值的位置

            if (leftIndex < array.Length && array[leftIndex] < array[SmallIndex])  //与左子节点进行比较
            {
                SmallIndex = leftIndex;
            }
            if (rightIndex < array.Length && array[rightIndex] < array[SmallIndex]) //与右子节点进行比较
            {
                SmallIndex = rightIndex;
            }
            if (currentIndex != SmallIndex)  //如果 currentIndex != SmallIndex 则表明 SmallIndex 发生变化（即：左右子节点中有小于根节点的情况）
            {
                Swap(array, currentIndex, SmallIndex);    //将左右节点中的小者与根节点进行交换（即：实现局部小顶堆）
                MinHeapify(array, SmallIndex); //以上次调整动作的small位置（为此次调整的根节点位置），进行递归调整
            }
        }
        static void Swap(int[] array, int indexA, int indexB)
        {
            int temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }
    }
}
