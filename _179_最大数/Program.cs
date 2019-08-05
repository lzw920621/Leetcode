using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _179_最大数
{
    /*
    给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
    示例 1:

    输入: [10,2]
    输出: 210

    示例 2:

    输入: [3,30,34,5,9]
    输出: 9534330

    说明: 输出结果可能非常大，所以你需要返回一个字符串而不是整数。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/largest-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 10, 2};
            string str = LargestNumber(nums);
        }

        public static string LargestNumber(int[] nums)
        {
            string[] numsArray = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                numsArray[i] = nums[i].ToString();
            }
            SortStringArray(numsArray, 0, numsArray.Length - 1);
            StringBuilder sb = new StringBuilder();
            foreach (var item in numsArray)
            {
                sb.Append(item);
            }
            string num = sb.ToString();
            int indexOfNotZero=-1;//第一个非0数的索引
            for (int i = 0; i < num.Length; i++)
            {
                if(num[i]>'0')
                {
                    indexOfNotZero = i;
                    break;
                }
            }
            if(indexOfNotZero==-1)
            {
                return "0";
            }
            else
            {
                return num.Substring(indexOfNotZero);
            }            
        }

        //字符串排序(快速排序) 降序
        public static void SortStringArray(string[] numsArray,int left,int right)
        {
            if (left >= right) return;

            string pivot = numsArray[left];
            int l = left, r = right;
            while (l < r)
            {
                while (l < r && AStringIsBiggerOrEqualThanBString(pivot , numsArray[r]))
                {
                    r--;
                }
                numsArray[l] = numsArray[r];
                while (l < r && AStringIsBiggerOrEqualThanBString(numsArray[l] , pivot))
                {
                    l++;
                }
                numsArray[r] = numsArray[l];
            }
            numsArray[l] = pivot;

            SortStringArray(numsArray, left, l - 1);
            SortStringArray(numsArray, l + 1, right);
        }
        //比较规则:字符串从左到右的字母 依次比较 大的排前面
        public static bool AStringIsBiggerOrEqualThanBString(string A,string B)
        {
            int tempLength = Math.Min(A.Length, B.Length);
            for (int i = 0; i < tempLength; i++)
            {
                if (A[i] > B[i])
                {
                    return true;
                }
                else if(A[i] < B[i])
                {
                    return false;
                }
            }
            //到这里说明 两个字符串 前tempLength位 数值相同
            if(A.Length>B.Length)
            {
                return AStringIsBiggerOrEqualThanBString(A.Substring(tempLength), B);
            }
            else if(A.Length<B.Length)
            {
                return AStringIsBiggerOrEqualThanBString(A, B.Substring(tempLength));
            }
            else//a.length==b.length
            {
                return true;
            }
        }
    }
}
