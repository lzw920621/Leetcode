using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_正则表达式匹配
{
    /*
        给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。

    '.' 匹配任意单个字符
    '*' 匹配零个或多个前面的那一个元素

    所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。

    说明:

        s 可能为空，且只包含从 a-z 的小写字母。
        p 可能为空，且只包含从 a-z 的小写字母，以及字符 . 和 *。

    示例 1:

    输入:
    s = "aa"
    p = "a"
    输出: false
    解释: "a" 无法匹配 "aa" 整个字符串。

    示例 2:

    输入:
    s = "aa"
    p = "a*"
    输出: true
    解释: 因为 '*' 代表可以匹配零个或多个前面的那一个元素, 在这里前面的元素就是 'a'。因此，字符串 "aa" 可被视为 'a' 重复了一次。

    示例 3:

    输入:
    s = "ab"
    p = ".*"
    输出: true
    解释: ".*" 表示可匹配零个或多个（'*'）任意字符（'.'）。

    示例 4:

    输入:
    s = "aab"
    p = "c*a*b"
    输出: true
    解释: 因为 '*' 表示零个或多个，这里 'c' 为 0 个, 'a' 被重复一次。因此可以匹配字符串 "aab"。

    示例 5:

    输入:
    s = "mississippi"
    p = "mis*is*p*."
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/regular-expression-matching
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool isMatch = new Program().IsMatch("ab", ".*");
        }

        public bool IsMatch(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0) return true;

            bool[,] dp = new bool[s.Length+1, p.Length+1];
            dp[0, 0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                dp[i, 0] = false;
            }

            for (int j = 2; j <= p.Length; j++)
            {
                if (p[j-1] == '*' && dp[0, j - 2] == true)
                {
                    dp[0, j] = true;
                }              
            }
                        
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if( (p[j - 1]=='.') || (p[j - 1] == s[i - 1]) )
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if(p[j-1]=='*')
                    {
                        if( s[i-1]!=p[j-2] && p[j - 2] != '.' )//*前的字符和s[i-1]不匹配 *只能匹配
                        {
                            dp[i, j] = dp[i, j - 2];
                        }
                        else 
                        {
                            if(dp[i-1,j] || dp[i, j - 2] || dp[i,j-1])
                            {
                                dp[i, j] = true;
                            }
                        }
                    }                   
                }
            }
            return dp[s.Length, p.Length];
        }
    }
}
