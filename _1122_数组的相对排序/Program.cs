using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1122_数组的相对排序
{
    /*
    对 arr1 中的元素进行排序，使 arr1 中项的相对顺序和 arr2 中的相对顺序相同。未在 arr2 中出现过的元素需要按照升序放在 arr1 的末尾。
    
    示例：

    输入：arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
    输出：[2,2,2,1,4,3,3,9,6,7,19]
    
    提示：

        arr1.length, arr2.length <= 1000
        0 <= arr1[i], arr2[i] <= 1000
        arr2 中的元素 arr2[i] 各不相同
        arr2 中的每个元素 arr2[i] 都出现在 arr1 中

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/relative-sort-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            int[] arr2 = new int[] { 2, 1, 4, 3, 9, 6 };

            int[] array = RelativeSortArray(arr1, arr2);

        }

        public static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] array = new int[arr1.Length];
            int tempIndex = arr1.Length - 1;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in arr2)
            {
                dic.Add(item, 0);
            }
            foreach (var item in arr1)
            {
                if(dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    array[tempIndex] = item;
                    tempIndex--;
                }
            }
            int tempIndex2 = 0;
            foreach (var keyPair in dic)
            {
                for (int i = 0; i < keyPair.Value; i++)
                {
                    array[tempIndex2] = keyPair.Key;
                    tempIndex2++;
                }
            }
            Partition(array, tempIndex2, array.Length - 1);
            return array;
        }

        static void Partition(int[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot = array[left];
            int l = left, r = right;
            while (l < r)
            {
                while (l < r && array[r] >= pivot)
                {
                    r--;
                }
                array[l] = array[r];
                while (l < r && array[l] <= pivot)
                {
                    l++;
                }
                array[r] = array[l];
            }
            array[l] = pivot;

            Partition(array, left, l - 1);
            Partition(array, l + 1, right);
        }
    }
}
