using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字符串中第一个唯一字符
{
    /*
    给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。

    案例:

    s = "leetcode"
    返回 0.

    s = "loveleetcode",
    返回 2.

 

    注意事项：您可以假定该字符串只包含小写字母。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/first-unique-character-in-a-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if(dic.ContainsKey(s[i]))
                {
                    dic[s[i]]++;
                }
                else
                {
                    dic.Add(s[i], 1);
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if(dic[s[i]]==1)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FirstUniqChar1(string s)
        {
            var nums = new int[26];
            foreach (var ch in s)
            {
                var key = ch - 'a';
                nums[key]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                var key = s[i] - 'a';
                if (nums[key] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
