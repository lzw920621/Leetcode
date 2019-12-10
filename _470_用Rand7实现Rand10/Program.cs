using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _470_用Rand7实现Rand10
{
    /*
        已有方法 rand7 可生成 1 到 7 范围内的均匀随机整数，试写一个方法 rand10 生成 1 到 10 范围内的均匀随机整数。
    不要使用系统的 Math.random() 方法。
    

    示例 1:

    输入: 1
    输出: [7]

    示例 2:

    输入: 2
    输出: [8,4]

    示例 3:

    输入: 3
    输出: [8,1,10]

 

    提示:

        rand7 已定义。
        传入参数: n 表示 rand10 的调用次数。

 

    进阶:

        rand7()调用次数的 期望值 是多少 ?
        你能否尽量少调用 rand7() ?

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/implement-rand10-using-rand7
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }        
    }

    public class Solution : SolBase
    {
        public int Rand10()
        {
            int a = Rand7();
            int b = Rand7();
            if ((a > 4 && b < 4) || (a<4 && b>4)) return Rand10();
            return (a + b) % 10 + 1;
        }
        public int Rand10_()
        {
            int i = 7;
            // 1~6 50% 偶数
            while (i > 6)
            {
                i = Rand7();
            }
            int j = 6;
            // 1~5 20% 分布
            while (j > 5)
            {
                j = Rand7();
            }
            return (i % 2 == 0) ? j + 5 : j;
        }
    }

    public class SolBase
    {
        public int Rand7()
        {
            throw new NotImplementedException();
        }
    }
}
