using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _796_旋转字符串
{
    /*
        给定两个字符串, A 和 B。
    A 的旋转操作就是将 A 最左边的字符移动到最右边。 例如, 若 A = 'abcde'，在移动一次之后结果就是'bcdea' 。如果在若干次旋转操作之后，A 能变成B，那么返回True。

    示例 1:
    输入: A = 'abcde', B = 'cdeab'
    输出: true

    示例 2:
    输入: A = 'abcde', B = 'abced'
    输出: false

    注意：

        A 和 B 长度不超过 100。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/rotate-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length) return false;
            if (A == B) return true;
            string str = A + A;
            for (int i = 0; i <= A.Length; i++)
            {
                if(str[i]==B[0])
                {
                    for (int j = 1; j < B.Length; j++)
                    {
                        if(B[j]==str[i+j])
                        {
                            if(j==B.Length-1)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
