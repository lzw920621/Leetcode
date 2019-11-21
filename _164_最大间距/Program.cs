using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _164_最大间距
{
    /*
        给定一个无序的数组，找出数组在排序之后，相邻元素之间最大的差值。
    如果数组元素个数小于 2，则返回 0。

    示例 1:

    输入: [3,6,9,1]
    输出: 3
    解释: 排序后的数组是 [1,3,6,9], 其中相邻元素 (3,6) 和 (6,9) 之间都存在最大差值 3。

    示例 2:

    输入: [10]
    输出: 0
    解释: 数组元素个数小于 2，因此返回 0。

    说明:

        你可以假设数组中所有元素都是非负整数，且数值在 32 位有符号整数范围内。
        请尝试在线性时间复杂度和空间复杂度的条件下解决此问题。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-gap
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int maxGap = new Program().MaximumGap(new int[] { 10 });
        }

        public int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)//寻找最大和最小值
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }
            int gap = Math.Max(1, (max - min) / (nums.Length - 1));//桶的大小
            //初始化桶
            List<int>[] buckets = new List<int>[(max - min) / gap + 1];
            
            //记录每个桶中的元素最大值与最小值
            foreach (var num in nums)
            {
                int index = (num - min) / gap;
                if (buckets[index] == null)
                {
                    buckets[index] = new List<int>();
                    buckets[index].Add(num);
                    buckets[index].Add(num);
                }
                
                buckets[index][0] = Math.Min(buckets[index][0], num);//最小值
                buckets[index][1] = Math.Max(buckets[index][1], num);//最大值
            }
            int maxDiff = 0;
            int preMin = min;
            
            foreach (var bucket in buckets)
            {
                if(bucket!=null)
                {
                    maxDiff = Math.Max(maxDiff, bucket[0] - preMin);
                    preMin = bucket[1];
                }
            }
            return maxDiff;
        }

        public int MaximumGap2(int[] nums)
        {
            if (nums.Length < 2) return 0;
            int min = nums[0], max = nums[0];
            for (int i = 0; i < nums.Length; i++)//寻找最大和最小值
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }
            int gap = Math.Max(1, (max - min) / (nums.Length - 1));//桶的大小
            //初始化桶
            int[][] buckets = new int[(max - min) / gap + 1][];

            //记录每个桶中的元素最大值与最小值
            foreach (var num in nums)
            {
                int index = (num - min) / gap;
                if (buckets[index] == null)
                {
                    buckets[index] = new int[2];
                    buckets[index][0] = num;
                    buckets[index][1] = num;
                    continue;
                }

                buckets[index][0] = Math.Min(buckets[index][0], num);//最小值
                buckets[index][1] = Math.Max(buckets[index][1], num);//最大值
            }
            int maxDiff = 0;
            int preMin = min;

            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    maxDiff = Math.Max(maxDiff, bucket[0] - preMin);
                    preMin = bucket[1];
                }
            }
            return maxDiff;
        }
    }
}
