using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _373_查找和最小的K对数字
{
    /*
        给定两个以升序排列的整形数组 nums1 和 nums2, 以及一个整数 k。
    定义一对值 (u,v)，其中第一个元素来自 nums1，第二个元素来自 nums2。
    找到和最小的 k 对数字 (u1,v1), (u2,v2) ... (uk,vk)。

    示例 1:

    输入: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
    输出: [1,2],[1,4],[1,6]
    解释: 返回序列中的前 3 对数：
         [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]

    示例 2:

    输入: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
    输出: [1,1],[1,1]
    解释: 返回序列中的前 2 对数：
         [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]

    示例 3:

    输入: nums1 = [1,2], nums2 = [3], k = 3 
    输出: [1,3],[2,3]
    解释: 也可能序列中所有的数对都被返回:[1,3],[2,3]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-k-pairs-with-smallest-sums
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (nums1.Length == 0 || nums2.Length == 0)
            {
                return list;
            }

            k = Math.Min(k, nums1.Length * nums2.Length);
            int[] steps = new int[nums1.Length];//用一个数组来记录num1中每个元素在nums2中走了多远
            for (int i = 0; i < k; i++)//搜索k轮,每轮找一个最小的数
            {
                int min = int.MaxValue;
                int minStepIndex = 0;
                for (int j = 0; j < steps.Length; j++)
                {
                    if (steps[j] < nums2.Length && nums2[steps[j]] + nums1[j] < min)
                    {
                        min = nums2[steps[j]] + nums1[j];
                        minStepIndex = j;//记录和最小的step索引
                    }
                }
                list.Add(new List<int> { nums1[minStepIndex], nums2[steps[minStepIndex]] });//添加这一轮筛选中最小的数
                steps[minStepIndex]++;//对应的step往前走一步
            }
            return list;
        }
    }
}
