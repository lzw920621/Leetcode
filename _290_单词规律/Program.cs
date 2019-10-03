using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _290_单词规律
{
    /*
        给定一种规律 pattern 和一个字符串 str ，判断 str 是否遵循相同的规律。
    这里的 遵循 指完全匹配，例如， pattern 里的每个字母和字符串 str 中的每个非空单词之间存在着双向连接的对应规律。

    示例1:
    输入: pattern = "abba", str = "dog cat cat dog"
    输出: true

    示例 2:
    输入:pattern = "abba", str = "dog cat cat fish"
    输出: false

    示例 3:
    输入: pattern = "aaaa", str = "dog cat cat dog"
    输出: false

    示例 4:
    输入: pattern = "abba", str = "dog dog dog dog"
    输出: false

    说明:
    你可以假设 pattern 只包含小写字母， str 包含了由单个空格分隔的小写字母。    

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/word-pattern
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool WordPattern(string pattern, string str)
        {
            string[] strArray = str.Split(' ');
            if (strArray.Length != pattern.Length) return false;
            Dictionary<char, string> dic1 = new Dictionary<char, string>();
            Dictionary<string, char> dic2 = new Dictionary<string, char>();
            for (int i = 0; i < pattern.Length; i++)
            {
                if(dic1.ContainsKey(pattern[i]))
                {
                    if(dic1[pattern[i]]!=strArray[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dic1[pattern[i]] = strArray[i];
                }
            }
            for (int i = 0; i < strArray.Length; i++)
            {
                if(dic2.ContainsKey(strArray[i]))
                {
                    if(dic2[strArray[i]]!=pattern[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dic2[strArray[i]] = pattern[i];
                }
            }

            return true;
        }
    }
}
