using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _169_求众数
{
    /*
    给定一个大小为 n 的数组，找到其中的众数。众数是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。

    你可以假设数组是非空的，并且给定的数组总是存在众数。

    示例 1:

    输入: [3,2,3]
    输出: 3

    示例 2:

    输入: [2,2,1,1,1,2,2]
    输出: 2

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/majority-element
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2 });
        }

        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int n = nums.Length / 2;
            foreach (var item in nums)
            {
                if(dic.ContainsKey(item))
                {
                    dic[item]++;
                    if(dic[item]>n)
                    {
                        return item;
                    }
                }
                else
                {
                    dic.Add(item, 1);
                }
            }
            return nums[0];
        }

        public static int MajorityElement1(int[] nums)
        {
            int cnt = 0;
            int key = nums[0];
            foreach (int x in nums)
            {
                if (cnt == 0)
                {
                    key = x;
                }
                if(key == x)
                {
                    cnt++;
                }
                else
                {
                    cnt--;
                }
            }
            return key;
        }
    }
}
