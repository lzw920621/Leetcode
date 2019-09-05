using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _389_找不同
{
    /*
    给定两个字符串 s 和 t，它们只包含小写字母。
    字符串 t 由字符串 s 随机重排，然后在随机位置添加一个字母。
    请找出在 t 中被添加的字母。

    示例:

    输入：
    s = "abcd"
    t = "abcde"

    输出：
    e

    解释：
    'e' 是那个被添加的字母。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-the-difference
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        //方法一 map
        public char FindTheDifference(string s, string t)
        {
            int[] map = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if(map[t[i]-'a']==0)
                {
                    return t[i];
                }
                map[t[i] - 'a']--;
            }
            return t[0];
        }

        //方法二 差值法
        public char FindTheDifference2(string s, string t)
        {
            int sum = 0;           
            for (int i = 0; i < s.Length; i++)
            {
                sum += t[i];
                sum -= s[i];
            }
            sum += t[t.Length - 1];
            return (char)sum;
        }


        //方法三 异或法
        public char FindTheDifference3(string s, string t)
        {
            int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                num ^= s[i];
                num ^= t[i];
            }
            num ^= t[t.Length - 1];
            return (char)num;
        }

    }
}
