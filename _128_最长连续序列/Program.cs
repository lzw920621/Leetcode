using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _128_最长连续序列
{
    /*
        给定一个未排序的整数数组，找出最长连续序列的长度。
    要求算法的时间复杂度为 O(n)。

    示例:

    输入: [100, 4, 200, 1, 3, 2]
    输出: 4
    解释: 最长连续序列是 [1, 2, 3, 4]。它的长度为 4。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-consecutive-sequence
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int LongestConsecutive(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();//key对应数组总的元素,value对应该元素所在的连续序列的长度
            int maxLength = 0;
            int left, right;
            foreach (var item in nums)
            {
                left = 0;
                right = 0;
                if (!dic.ContainsKey(item))//这个可以确保left和right不会有重叠部分
                {
                    if (dic.ContainsKey(item - 1))
                    {
                        left = dic[item - 1];
                    }
                    if(dic.ContainsKey(item+1))
                    {
                        right = dic[item + 1];
                    }

                    int tempLength = left + right + 1;
                    if (tempLength > maxLength) maxLength = tempLength;
                    dic[item] = tempLength;
                    dic[item - left] = tempLength;
                    dic[item + right] = tempLength;
                }                
            }
            return maxLength;
        }

        public int LongestConsecutive2(int[] nums)
        {
            var dic = new Dictionary<int, KeyValuePair<int, int>>();
            var maxLength = 0;//最大长度
            var head = 0;
            var tail = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    if (dic.ContainsKey(nums[i] - 1))//前一个数值存在于dic中
                    {
                        head = dic[nums[i] - 1].Key;
                    }
                    else
                    {
                        head = nums[i];
                    }

                    if (dic.ContainsKey(nums[i] + 1))//后一个数值存在于dic中
                    {
                        tail = dic[nums[i] + 1].Value;
                    }
                    else
                    {
                        tail = nums[i];
                    }

                    if (head != nums[i])//如果当前值不是所在区间的头
                    {
                        dic[head] = new KeyValuePair<int, int>(head, tail);
                    }

                    if (tail != nums[i])//如果当前值不是所在区间的尾
                    {
                        dic[tail] = new KeyValuePair<int, int>(head, tail);
                    }

                    if (tail - head + 1 > maxLength)
                    {
                        maxLength = tail - head + 1;//更新最大长度
                    }

                    dic.Add(nums[i], new KeyValuePair<int, int>(head, tail));
                }
            }

            return maxLength;            
        }
    }
}
