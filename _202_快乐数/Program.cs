using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202_快乐数
{
    /*
    编写一个算法来判断一个数是不是“快乐数”。
    一个“快乐数”定义为：对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和，
    然后重复这个过程直到这个数变为 1，也可能是无限循环但始终变不到 1。如果可以变为 1，那么这个数就是快乐数。

    示例: 

    输入: 19
    输出: true
    解释: 
    12 + 92 = 82
    82 + 22 = 68
    62 + 82 = 100
    12 + 02 + 02 = 1

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/happy-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            bool isHappy = IsHappy(7);
        }

        public static bool IsHappy(int n)
        {
            if (n == 1) return true;
            HashSet<int> set = new HashSet<int>();
            set.Add(n);
            while(n>1)
            {
                n = GetSumOfSquare(n);
                if(n==1)
                {
                    return true;
                }
                if(set.Add(n)==false)
                {
                    return false;
                }
            }
            return false;
        }

        public static int GetSumOfSquare(int n)//求整数n各位数的平方和
        {
            int sum = 0;
            while(n>0)
            {                
                sum += (int)Math.Pow(n % 10, 2);
                n = n / 10;
            }
            return sum;
        }
    }
}
