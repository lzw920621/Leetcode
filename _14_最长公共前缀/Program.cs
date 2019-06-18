using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_最长公共前缀
{
    /*
    编写一个函数来查找字符串数组中的最长公共前缀。

    如果不存在公共前缀，返回空字符串 ""。

    示例 1:

    输入: ["flower","flow","flight"]
    输出: "fl"

    示例 2:

    输入: ["dog","racecar","car"]
    输出: ""
    解释: 输入不存在公共前缀。

    说明:

    所有输入只包含小写字母 a-z 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-common-prefix
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[] { "abcde", "abcrf", "abc" };
            string commonPrefix = LongestCommonPrefix(array);
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            //char current;
            for (int j = 0; j < strs[0].Length; j++)
            {
                //current = strs[0][j];
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i].Length < j + 1 || strs[0][j] != strs[i][j])
                    {
                        return strs[0].Substring(0, j);
                    }
                }
            }
            return strs[0];
        }
    }
}
