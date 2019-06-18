using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_三数之和
{
    /*
      给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？
      找出所有满足条件且不重复的三元组。
    */
    class Program
    {
        static void Main(string[] args)
        {
            //[-1, 0, 1, 2, -1, -4]
            List<List<int>> list = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });            
         }

        public static List<List<int>> ThreeSum(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < nums.Length-2;i++)
            {
                for (int j = i+1; j < nums.Length-1; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        if(nums[i]+nums[j]+nums[k]==0)
                        {
                            list.Add(new List<int> { nums[i], nums[j], nums[k] });
                        }
                    }
                }
            }


            return list;
        }
    }
}
