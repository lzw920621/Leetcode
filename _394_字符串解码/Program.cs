using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _394_字符串解码
{
    /*
    给定一个经过编码的字符串，返回它解码后的字符串。
    编码规则为: k[encoded_string]，表示其中方括号内部的 encoded_string 正好重复 k 次。注意 k 保证为正整数。
    你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。
    此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 k ，例如不会出现像 3a 或 2[4] 的输入。

    示例:

    s = "3[a]2[bc]", 返回 "aaabcbc".
    s = "3[a2[c]]", 返回 "accaccacc".
    s = "2[abc]3[cd]ef", 返回 "abcabccdcdcdef".

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/decode-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string newStr = DecodeString("2[abc]3[cd]ef");
        }

        public static string DecodeString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]>47 && s[i]<58)//s[i] 是数字0-9
                {
                    int count = s[i] - '0';//要重复的次数
                    while (s[i+1] > 47 && s[i+1] < 58)//下个字母仍然是数字
                    {
                        i++;
                        count = count * 10 + s[i] - '0';
                    }
                    
                    int count2 = 1;// [的个数
                    int j = i + 2;
                    for (; j < s.Length; j++)
                    {
                        if(s[j]==']')
                        {
                            count2--;
                            if(count2==0)
                            {
                                break;//找到与[ 相匹配的 ] 的位置 j
                            }
                        }
                        else if(s[j]=='[')
                        {
                            count2++;
                        }
                    }
                    string subString = s.Substring(i + 2, j - i - 2);
                    string tempStr = DecodeString(subString);
                    while (count>0)
                    {
                        sb.Append(tempStr);
                        count--;
                    }
                    i = j;
                }
                else
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
    }
}
