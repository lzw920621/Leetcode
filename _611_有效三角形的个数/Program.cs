using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _611_有效三角形的个数
{
    /*
        给定一个包含非负整数的数组，你的任务是统计其中可以组成三角形三条边的三元组个数。

    示例 1:

    输入: [2,2,3,4]
    输出: 3
    解释:
    有效的组合是: 
    2,3,4 (使用第一个 2)
    2,3,4 (使用第二个 2)
    2,2,3

    注意:

        数组长度不超过1000。
        数组里整数的范围为 [0, 1000]。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-triangle-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = new Program().TriangleNumber2(new int[] { 24, 3, 82, 22, 35, 84, 19 });
        }
        //方法1 暴力法
        public int TriangleNumber(int[] nums)
        {
            int count = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    int temp = nums[i] + nums[j];
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        if(nums[k]<temp)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return count;
        }

        //对方法1进行改进 第三边用二分查找
        public int TriangleNumber2(int[] nums)
        {
            int count = 0;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length-2; i++)
            {
                for (int j = i + 1; j < nums.Length-1; j++)
                {
                    int temp = nums[i] + nums[j];
                    int lowBoundIndex = BinarySearch(nums, j + 1, nums.Length - 1, temp);
                    if(lowBoundIndex!=-1)
                    {
                        count += lowBoundIndex - j;
                    }                    
                }
            }
            return count;
        }

        int BinarySearch(int[] nums,int leftIndex,int rightIndex,int upBound)
        {
            if (nums[leftIndex] >= upBound) return -1;
            while(leftIndex<rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;
                if(nums[midIndex]>=upBound)
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    if(nums[midIndex+1]>=upBound)
                    {
                        return midIndex;
                    }
                    leftIndex = midIndex + 1;
                }
            }
            return leftIndex;
        }
        //方法3 双指针
        public int TriangleNumber3(int[] nums)
        {
            Array.Sort(nums);
            var result = 0;
            for (var i = nums.Length - 1; i > 1; i--)
            {
                var r = i - 1;
                var l = 0;
                while (l < r)
                {
                    if (nums[l] + nums[r] > nums[i])//nums[i]为最长边
                    {
                        result += r - l;
                        r--;
                    }
                    else
                    {
                        l++;
                    }
                }
            }
            return result;
        }
    }
}
