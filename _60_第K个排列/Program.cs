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
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    for (int j = array.Length - 1; j >= i; j--)
                    {
                        if (array[j] > array[i - 1])
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
        void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        void Reverse(int[] array, int left, int right)
        {
            int temp;
            while (left < right)
            {
                temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }


        public string GetPermutation2(int n, int k)
        {
            /*
            用数学的方法来解, 因为数字都是从1开始的连续自然数, 排列出现的次序可以推
            算出来, 对于n=4, k=15 找到k=15排列的过程:
        
            1 + 对2,3,4的全排列 (3!个)         
            2 + 对1,3,4的全排列 (3!个)         3, 1 + 对2,4的全排列(2!个)
            3 + 对1,2,4的全排列 (3!个)-------> 3, 2 + 对1,4的全排列(2!个)-------> 3, 2, 1 + 对4的全排列(1!个)-------> 3214
            4 + 对1,2,3的全排列 (3!个)         3, 4 + 对1,2的全排列(2!个)         3, 2, 4 + 对1的全排列(1!个)
        
            确定第一位:
                k = 14(从0开始计数)
                index = k / (n-1)! = 2, 说明第15个数的第一位是3 
                更新k
                k = k - index*(n-1)! = 2
            确定第二位:
                k = 2
                index = k / (n-2)! = 1, 说明第15个数的第二位是2
                更新k
                k = k - index*(n-2)! = 0
            确定第三位:
                k = 0
                index = k / (n-3)! = 0, 说明第15个数的第三位是1
                更新k
                k = k - index*(n-3)! = 0
            确定第四位:
                k = 0
                index = k / (n-4)! = 0, 说明第15个数的第四位是4
            最终确定n=4时第15个数为3214 
            */

            StringBuilder sb = new StringBuilder();
            // 候选数字
            List<char> candidates = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            // 分母的阶乘数
            int[] factorials = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            
            k -= 1;
            for (int i = n - 1; i >= 0; --i)
            {
                // 计算候选数字的index
                int index = k / factorials[i];
                sb.Append(candidates[index]);
                candidates.RemoveAt(index);
                k -= index * factorials[i];
            }
            return sb.ToString();
        }
    }
}
