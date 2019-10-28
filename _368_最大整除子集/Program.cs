using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _368_最大整除子集
{
    /*
        给出一个由无重复的正整数组成的集合，找出其中最大的整除子集，子集中任意一对 (Si，Sj) 
    都要满足：Si % Sj = 0 或 Sj % Si = 0。如果有多个目标子集，返回其中任何一个均可。
    
    示例 1:

    输入: [1,2,3]
    输出: [1,2] (当然, [1,3] 也正确)

    示例 2:

    输入: [1,2,4,8]
    输出: [1,2,4,8]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/largest-divisible-subset
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new Program().LargestDivisibleSubset(new int[] { 2, 3, 4, 9, 8 });
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums.Length < 1) return new List<int>();
            Array.Sort(nums);
            int count = 1;
            List<int> list = new List<int> { nums[0] };
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            dic[0] = new List<int> { nums[0] };
            
            for (int i = 1; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(i))
                {
                    dic[i] = new List<int> { nums[i] };
                }
                for (int j = 0; j < i; j++)
                {            
                    if (nums[i]%nums[j]==0)
                    {
                        if (dic[j].Count + 1 > dic[i].Count)
                        {
                            dic[i] = new List<int>(dic[j]);
                            dic[i].Add(nums[i]);
                        }

                        if (dic[i].Count>count)
                        {
                            count = dic[i].Count;
                            list = new List<int>(dic[i]);
                        }
                    }
                    
                }
            }

            return list;
        }


    }
}
