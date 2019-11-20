using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _779_第K个语法符号
{
    /*
        在第一行我们写上一个 0。接下来的每一行，将前一行中的0替换为01，1替换为10。
    给定行数 N 和序数 K，返回第 N 行中第 K个字符。（K从1开始）


    例子:

    输入: N = 1, K = 1
    输出: 0

    输入: N = 2, K = 1
    输出: 0

    输入: N = 2, K = 2
    输出: 1

    输入: N = 4, K = 5
    输出: 1

    解释:
    第一行: 0
    第二行: 01
    第三行: 0110
    第四行: 01101001

    注意：
        N 的范围 [1, 30].
        K 的范围 [1, 2^(N-1)].

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/k-th-symbol-in-grammar
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int KthGrammar(int N, int K)
        {
            if(N==1)
            {
                return 0;
            }
            else
            {
                int temp = KthGrammar(N - 1, (K-1) / 2 + 1);
                if(temp==0)
                {
                    if(K % 2==1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else//temp=1
                {
                    if (K % 2 == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
