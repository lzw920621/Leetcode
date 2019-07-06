using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _219_存在重复元素II
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if(nums==null||nums.Length<=1)
            {
                return false;
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if(dic.ContainsKey(nums[i]))
                {
                    if(i-dic[nums[i]]<=k)
                    {
                        return true;
                    }
                    else
                    {
                        dic[nums[i]] = i;
                    }
                }
                else
                {
                    dic.Add(nums[i], i);
                }
            }
            return false;
        }
    }
}
