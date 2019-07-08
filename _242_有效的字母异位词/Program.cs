using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _242_有效的字母异位词
{
    /*
    给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。

    示例 1:

    输入: s = "anagram", t = "nagaram"
    输出: true

    示例 2:

    输入: s = "rat", t = "car"
    输出: false

    说明:
    你可以假设字符串只包含小写字母。

    进阶:
    如果输入字符串包含 unicode 字符怎么办？你能否调整你的解法来应对这种情况？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-anagram
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            bool b = IsAnagram1("a", "b");
        }

        public static  bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
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
            for (int i = 0; i < t.Length; i++)
            {
                if (dic.ContainsKey(t[i]))
                {
                    dic[t[i]]--;
                    if(dic[t[i]] <0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAnagram1(string s, string t)
        {
            if (s.Length != t.Length) return false;
            int[] array = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

            for (int i = 0; i < s.Length; i++)
            {
                array[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                array[t[i]-'a']--;
                if(array[t[i] - 'a'] <0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
