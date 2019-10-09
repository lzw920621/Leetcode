using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _91_解码方法
{
    /*
        一条包含字母 A-Z 的消息通过以下方式进行了编码：

    'A' -> 1
    'B' -> 2
    ...
    'Z' -> 26

    给定一个只包含数字的非空字符串，请计算解码方法的总数。

    示例 1:

    输入: "12"
    输出: 2
    解释: 它可以解码为 "AB"（1 2）或者 "L"（12）。

    示例 2:

    输入: "226"
    输出: 3
    解释: 它可以解码为 "BZ" (2 26), "VF" (22 6), 或者 "BBF" (2 2 6) 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/decode-ways
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = new Program().NumDecodings2("301");
        }

        public int NumDecodings(string s)
        {
            int count = 0;
            Assist(s, 0, ref count);
            return count;
        }

        void Assist(string s,int index,ref int count)
        {
            if(index==s.Length)
            {
                count++;
                return;
            }
            if (s[index] == '0') return;
            Assist(s, index + 1, ref count);
            if(index+1<s.Length && (s[index]-'0')*10+s[index+1]-'0'<27)
            {
                Assist(s, index + 2, ref count);
            }
        }

        //方法2 动态规划
        public int NumDecodings2(string s)
        {
            if (s[0] == '0') return 0;
            if (s.Length == 1) return 1;

            int[] dp = new int[s.Length];
            dp[0] = 1;

            if(s[0] != '0' && (s[0] - '0') * 10 + s[1] - '0'<27)
            {
                if(s[1]=='0')
                {
                    dp[1] = 1;
                }
                else
                {
                    dp[1] = 2;
                }
            }
            else
            {
                if(s[1]=='0')
                {
                    dp[1] = 0;
                }
                else
                {
                    dp[1] = 1;
                }                
            }

            for (int i = 2; i < s.Length; i++)
            {
                if (s[i-1] != '0' && (s[i-1] - '0') * 10 + s[i] - '0' < 27)
                {
                    if(s[i]=='0')
                    {
                        dp[i] = dp[i - 2];
                    }
                    else
                    {
                        dp[i] = dp[i - 1] + dp[i - 2];
                    }                    
                }
                else
                {
                    if (s[i] == '0')
                    {
                        dp[i] = 0;
                    }
                    else
                    {
                        dp[i] = dp[i - 1];
                    }                     
                }
            }
            return dp[s.Length - 1];
        }
    }
}
