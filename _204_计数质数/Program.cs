using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _204_计数质数
{
    /*
    统计所有小于非负整数 n 的质数的数量。

    示例:

    输入: 10
    输出: 4
    解释: 小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/count-primes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = CountPrimes2(499979);
        }

        public static int CountPrimes(int n)
        {
            List<int> primes = new List<int>();
            int count = 0;
            bool isPrime;
            for (int i = 2; i <n; i++)
            {
                isPrime = true;
                for (int j = 0; j < primes.Count; j++)
                {
                    if(i%primes[j]==0)//不是质数
                    {
                        isPrime = false;
                        break;
                    }
                }
                if(isPrime)
                {
                    primes.Add(i);
                    count++;
                }
            }
            return count;
        }

        public static int CountPrimes1(int n)
        {
            if (n < 3) return 0;
            int[] primes = new int[n];            
            primes[0] = 2;
            int count = 1;
            bool isPrime;
            for (int i = 3; i < n;)
            {
                isPrime = true;
                for (int j = 0; j < count; j++)
                {
                    if (i % primes[j] == 0)//不是质数
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes[count]=i;
                    count++;
                }

                i += 2;
            }
            return count;
        }

        public static int CountPrimes2(int n)//埃拉托斯特尼筛法
        {            
            int[] nums = new int[n];//这个辅助数组 1表示是质数 0表示非质数
            for (int i = 2; i < nums.Length; i++)
            {
                nums[i] = 1;
            }

            for (int i = 2; i * i < nums.Length; i++)//为什么 约束条件是 i*i<n? 因为i*i之前的数都被筛过了
            {
                if (nums[i] == 1)//i是质数
                {
                    for (int j = i * i; j < nums.Length; j += i)//筛掉i的倍数
                    {
                        nums[j] = 0;
                    }
                }
            }
            int sum = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
       
    }
}
