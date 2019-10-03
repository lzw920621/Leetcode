using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _46_全排列
{
    /*
    给定一个没有重复数字的序列，返回其所有可能的全排列。

    示例:

    输入: [1,2,3]
    输出:
    [
      [1,2,3],
      [1,3,2],
      [2,1,3],
      [2,3,1],
      [3,1,2],
      [3,2,1]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/permutations
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = Permute(new int[] { 1, 2, 3 });
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> set = new List<IList<int>>();
            if (nums.Length < 1)
            {
                return set;
            }
            else
            {
                List<int> firstSubSet = new List<int>();
                firstSubSet.Add(nums[0]);

                set.Add(firstSubSet);

                for (int i = 1; i < nums.Length; i++)
                {
                    Assist(set, nums[i]);
                }
                return set;
            }
        }

        public static void Assist(IList<IList<int>> set, int num)
        {
            int count = set.Count;
            
            for (int i = 0; i < count; i++)
            {
                int length = set[i].Count + 1;
                for (int j = 0; j < length; j++)
                {
                    IList<int> tempList = CopyList(set[i]);
                    tempList.Insert(j, num);
                    set.Add(tempList);
                }
            }

            for (int i = 0; i < count; i++)
            {
                set.RemoveAt(0);
            }
        }
        
        public static IList<int> CopyList(IList<int> list)
        {
            IList<int> newList = new List<int>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }


        public IList<IList<int>> Permute2(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Array.Sort(nums);
            list.Add(nums.ToList());
            while(GetNext(nums))
            {
                list.Add(nums.ToList());
            }
            return list;
        }

        bool GetNext(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    for (int j = array.Length - 1; j >= i; j--)
                    {
                        if (array[j] > array[i - 1])
                        {
                            Swap(array, i - 1, j);
                            Reverse(array, i, array.Length - 1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        void Reverse(int[] array, int left, int right)
        {
            int temp;
            while (left < right)
            {
                temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
    }
}
