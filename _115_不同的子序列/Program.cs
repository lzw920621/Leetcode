using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _115_不同的子序列
{
    /*
        给定一个字符串 S 和一个字符串 T，计算在 S 的子序列中 T 出现的个数。
    一个字符串的一个子序列是指，通过删除一些（也可以不删除）字符且不干扰剩余字符相对位置所组成的新字符串。
    （例如，"ACE" 是 "ABCDE" 的一个子序列，而 "AEC" 不是）

    示例 1:

    输入: S = "rabbbit", T = "rabbit"
    输出: 3
    解释:

    如下图所示, 有 3 种可以从 S 中得到 "rabbit" 的方案。
    (上箭头符号 ^ 表示选取的字母)

    rabbbit
    ^^^^ ^^
    rabbbit
    ^^ ^^^^
    rabbbit
    ^^^ ^^^

    示例 2:

    输入: S = "babgbag", T = "bag"
    输出: 5
    解释:

    如下图所示, 有 5 种可以从 S 中得到 "bag" 的方案。 
    (上箭头符号 ^ 表示选取的字母)

    babgbag
    ^^ ^
    babgbag
    ^^    ^
    babgbag
    ^    ^^
    babgbag
      ^  ^^
    babgbag
        ^^^

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/distinct-subsequences
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = NumDistinct("babgbag", "bag");
        }

        public static int NumDistinct(string s, string t)
        {
            if (s.Length < 1) return 0;
            int[,] dp = new int[s.Length, t.Length];
            if(s[0]==t[0])
            {
                dp[0, 0] = 1;
            }
            for (int i = 1; i < s.Length; i++)
            {
                if(s[i]==t[0])
                {
                    dp[i, 0] = dp[i - 1, 0] + 1;
                }
                else
                {
                    dp[i, 0] = dp[i - 1, 0];
                }
            }
            
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 1; j < t.Length; j++)
                {
                    if(s[i]==t[j])
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[s.Length - 1, t.Length - 1];
        }
    }
}
