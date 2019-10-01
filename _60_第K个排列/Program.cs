using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60_第K个排列
{
    /*
        给出集合 [1,2,3,…,n]，其所有元素共有 n! 种排列。
    按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：

        "123"
        "132"
        "213"
        "231"
        "312"
        "321"

    给定 n 和 k，返回第 k 个排列。

    说明：

        给定 n 的范围是 [1, 9]。
        给定 k 的范围是[1,  n!]。

    示例 1:

    输入: n = 3, k = 3
    输出: "213"

    示例 2:

    输入: n = 4, k = 9
    输出: "2314"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/permutation-sequence
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string GetPermutation(int n, int k)
        {
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }
            for (int i = 1; i < k; i++)
            {
                GetNext(array);
            }
            string s = "";
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i];
            }
            return s;
        }
        bool GetNext(int[] array)
        {
            for (int i = array.Length-1; i >0; i--)
            {
                if(array[i]>array[i-1])
                {
                    for (int j = array.Length - 1; j >= i; j--)
                    {
                        if(array[j]> array[i - 1])
                        {
                            Swap(array, i - 1, j);
                            Reverse(array, i, array.Length - 1);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        void Swap(int[] array,int i,int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        void Reverse(int[] array,int left,int right)
        {
            int temp;
            while(left<right)
            {
                temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }
    }
}
