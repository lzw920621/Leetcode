using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _47_全排列II
{
    /*
        给定一个可包含重复数字的序列，返回所有不重复的全排列。

    示例:

    输入: [1,1,2]
    输出:
    [
      [1,1,2],
      [1,2,1],
      [2,1,1]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/permutations-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> list = new Program().PermuteUnique(new int[] { 1, 1, 2,2 });
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(nums.ToList());
            while(GetNext(nums))
            {
                list.Add(nums.ToList());
            }
            return list;
        }

        bool GetNext(int[] nums)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    for (int j = nums.Length - 1; j >= i; j--)
                    {
                        if (nums[j] > nums[i - 1])
                        {
                            Swap(nums, i - 1, j);
                            Reverse(nums, i, nums.Length - 1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        void Swap(int[] nums,int index1,int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
        void Reverse(int[] nums,int start,int end)
        {
            int temp;
            int i = start;
            int j = end;
            while (i < j)
            {
                temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;
                j--;
            }
        }
    }
}
