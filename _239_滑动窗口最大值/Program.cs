using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_滑动窗口最大值
{
    /*
        给定一个数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。
    你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位。
    返回滑动窗口中的最大值。


    示例:

    输入: nums = [1,3,-1,-3,5,3,6,7], 和 k = 3
    输出: [3,3,5,5,6,7] 
    解释: 

      滑动窗口的位置                最大值
    ---------------               -----
    [1  3  -1] -3  5  3  6  7       3
     1 [3  -1  -3] 5  3  6  7       3
     1  3 [-1  -3  5] 3  6  7       5
     1  3  -1 [-3  5  3] 6  7       5
     1  3  -1  -3 [5  3  6] 7       6
     1  3  -1  -3  5 [3  6  7]      7

 

    提示：

    你可以假设 k 总是有效的，在输入数组不为空的情况下，1 ≤ k ≤ 输入数组的大小。

 

    进阶：

    你能在线性时间复杂度内解决此题吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sliding-window-maximum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new Program().MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length < 1 || k == 0) return new int[] { };

            List<int> list = new List<int>();
            List<Item> listTemp = new List<Item>();
            int indexOfLeft = 0;

            for (int i = 0; i < k; i++)
            {
                while(listTemp.Count-1>=indexOfLeft && nums[i]>listTemp[listTemp.Count-1].val)
                {
                    listTemp.RemoveAt(listTemp.Count - 1);
                }
                listTemp.Add(new Item(i, nums[i]));
            }
            list.Add(listTemp[indexOfLeft].val);

            for (int i = k; i < nums.Length; i++)
            {
                if(listTemp[indexOfLeft].index==i-k)
                {
                    indexOfLeft++;
                }
                while (listTemp.Count - 1 >= indexOfLeft && nums[i] > listTemp[listTemp.Count - 1].val)
                {
                    listTemp.RemoveAt(listTemp.Count - 1);
                }
                listTemp.Add(new Item(i, nums[i]));
                list.Add(listTemp[indexOfLeft].val);
            }

            return list.ToArray();
        }

        struct Item
        {
            public int index;
            public int val;
            public Item(int index,int val)
            {
                this.index = index;
                this.val = val;
            }
        }

    }
}
