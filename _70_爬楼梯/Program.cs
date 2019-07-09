using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_爬楼梯
{
    /*
    假设你正在爬楼梯。需要 n 阶你才能到达楼顶。

    每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？

    注意：给定 n 是一个正整数。

    示例 1：

    输入： 2
    输出： 2
    解释： 有两种方法可以爬到楼顶。
    1.  1 阶 + 1 阶
    2.  2 阶

    示例 2：

    输入： 3
    输出： 3
    解释： 有三种方法可以爬到楼顶。
    1.  1 阶 + 1 阶 + 1 阶
    2.  1 阶 + 2 阶
    3.  2 阶 + 1 阶

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/climbing-stairs
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = ClimbStairs1(3);
        }

        public static int ClimbStairs(int n)
        {
            if(n==1)
            {
                return 1;
            }
            else if(n==2)
            {
                return 2;
            }
            else
            {
                return ClimbStairs(n - 1) + ClimbStairs(n - 2); //递归方式 效率不高
            }
        }

        public static int ClimbStairs1(int n)
        {
            if(n<1)
            {
                return 0;
            }
            else if(n<3)
            {
                return n;
            }
            else
            {
                int a = 1, b = 2;
                int c=0;
                for (int i = 3; i <=n; i++)             //迭代方式 效率很高
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return c;
            }

        }
    }
}
