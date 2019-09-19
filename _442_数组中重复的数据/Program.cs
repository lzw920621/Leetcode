using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _442_数组中重复的数据
{
    /*
        给定一个整数数组 a，其中1 ≤ a[i] ≤ n （n为数组长度）, 其中有些元素出现两次而其他元素出现一次。

    找到所有出现两次的元素。

    你可以不用到任何额外空间并在O(n)时间复杂度内解决这个问题吗？

    示例：

    输入:
    [4,3,2,7,8,2,3,1]

    输出:
    [2,3]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-all-duplicates-in-an-array
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new Program().FindDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            IList<int> list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                while(nums[i]!=i+1 && nums[nums[i]-1]!=nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i]!=i+1)
                {
                    list.Add(nums[i]);
                }
            }
            return list;
        }

        void Swap(int[] nums,int index1,int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
