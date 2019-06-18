using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _821_字符间最短的距离
{
    /*
    给定一个字符串 S 和一个字符 C。返回一个代表字符串 S 中每个字符到字符串 S 中的字符 C 的最短距离的数组。

    示例 1:

    输入: S = "loveleetcode", C = 'e'
    输出: [3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0]

    说明:

    字符串 S 的长度范围为 [1, 10000]。
    C 是一个单字符，且保证是字符串 S 里的字符。
    S 和 C 中的所有字母均为小写字母。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/shortest-distance-to-a-character
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ShortestToChar("loveleetcode", 'e');
        }

        public static int[] ShortestToChar(string S, char C)
        {
            int[] array = new int[S.Length];
            List<int> list = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (C == S[i])
                {
                    list.Add(i);
                }
            }            
            for (int i = 0; i < S.Length; i++)
            {
                array[i] = int.MaxValue;
                for (int j = 0; j < list.Count; j++)
                {
                    array[i] = Math.Min(array[i], Math.Abs(i-list[j]));
                }
            }
            return array;
        }
    }
}
