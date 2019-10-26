using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _229_求众数II
{
    /*
        给定一个大小为 n 的数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。
    说明: 要求算法的时间复杂度为 O(n)，空间复杂度为 O(1)。

    示例 1:

    输入: [3,2,3]
    输出: [3]

    示例 2:

    输入: [1,1,1,3,3,2,2,2]
    输出: [1,2]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/majority-element-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = MajorityElement(new int[] { 1 });
        }

        //方法1 哈希表 空间复杂度O(n) 时间复杂度O(n)
        public  static IList<int> MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> list = new List<int>();
            
            int count = nums.Length / 3;
            for (int i = 0; i < nums.Length; i++)
            {
                if(dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;                    
                }
                else
                {
                    dic[nums[i]] = 1;                    
                }
            }
            return dic.Where(keyPair => keyPair.Value > count).Select(keyPair => keyPair.Key).ToList();
        }


        //方法2 摩尔投票法
        public static IList<int> MajorityElement2(int[] nums)
        {
            List<int> res = new List<int>();
            if (nums == null || nums.Length == 0)
                return res;
            //初始化：定义两个候选人及其对应的票数
            int candidateA = nums[0];
            int candidateB = nums[0];
            int countA = 0;
            int countB = 0;
            //遍历数组
            foreach (var num in nums)
            {
                if (num == candidateA)
                {
                    countA++;//投A
                    continue;
                }
                if (num == candidateB)
                {
                    countB++;//投B
                    continue;
                }

                //此时当前值和AB都不等，检查是否有票数减为0的情况，如果为0，则更新候选人
                if (countA == 0)
                {
                    candidateA = num;
                    countA++;
                    continue;
                }
                if (countB == 0)
                {
                    candidateB = num;
                    countB++;
                    continue;
                }
                //若此时两个候选人的票数都不为0，且当前元素不投AB，那么A,B对应的票数都要--;
                countA--;
                countB--;
            }

            //上一轮遍历找出了两个候选人，但是这两个候选人是否均满足票数大于N/3仍然没法确定，需要重新遍历，确定票数
            countA = 0;
            countB = 0;
            foreach (var num in nums)
            {
                if (num == candidateA)
                    countA++;
                else if (num == candidateB)
                    countB++;
            }
            if (countA > nums.Length / 3)
                res.Add(candidateA);
            if (countB > nums.Length / 3)
                res.Add(candidateB);
            return res;
        }
    }
}
