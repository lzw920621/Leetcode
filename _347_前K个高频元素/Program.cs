using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _347_前K个高频元素
{
    /*
    给定一个非空的整数数组，返回其中出现频率前 k 高的元素。

    示例 1:

    输入: nums = [1,1,1,2,2,3], k = 2
    输出: [1,2]

    示例 2:

    输入: nums = [1], k = 1
    输出: [1]

    说明：

        你可以假设给定的 k 总是合理的，且 1 ≤ k ≤ 数组中不相同的元素的个数。
        你的算法的时间复杂度必须优于 O(n log n) , n 是数组的大小。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/top-k-frequent-elements
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = TopKFrequent(new int[] { 1},1);
        }

        public static IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if(dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            foreach (var item in dic)
            {
                list.Add(item);
            }

            TopK(list, 0, list.Count - 1, k);

            List<int> newList = new List<int>();
            for (int i = 0; i < k; i++)
            {
                newList.Add(list[i].Key);
            }
            return newList;
        }

        public static void TopK(List<KeyValuePair<int, int>> list, int low, int high, int k)//利用 快速排序 的思路来实现 时间复杂度O(n)
        {
            if (low >= high) return;
            int left = low;
            int right = high;
            int mid = list[low].Value;
            KeyValuePair<int, int> pivot = list[low];
            while (left < right)
            {
                while (left < right && list[right].Value <= mid)
                {
                    right--;
                }
                if (left < right)
                {
                    list[left] = list[right];
                    left++;
                }
                while (left < right && list[left].Value >= mid)
                {
                    left++;
                }
                if (left < right)
                {
                    list[right] = list[left];
                    right--;
                }
            }
            list[left] = pivot;
            if (left > k)
            {
                TopK(list, low, left - 1, k);
            }
            else if (left < k)
            {
                TopK(list, left + 1, high, k);
            }
        }



        public static IList<int> TopKFrequent2(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (dic.ContainsKey(item))
                {
                    dic[item]++;
                }
                else
                {
                    dic.Add(item, 1);
                }
            }

            List<int>[] array = new List<int>[nums.Length + 1];
            foreach (var item in dic)
            {
                if(array[item.Value]==null)
                {
                    array[item.Value] = new List<int>();                   
                }
                array[item.Value].Add(item.Key);
            }
            IList<int> list = new List<int>();
            int count = 0;
            for (int i = array.Length-1; i >=0; i--)
            {
                if(array[i]!=null)
                {
                    for (int j = 0; j < array[i].Count; j++)
                    {
                        list.Add(array[i][j]);
                        count++;
                        if (count == k) return list;
                    }
                }
            }
            return list;
        }
    }
}
