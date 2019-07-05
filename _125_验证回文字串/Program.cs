using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _125_验证回文字串
{
    /*
    给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。

    说明：本题中，我们将空字符串定义为有效的回文串。

    示例 1:

    输入: "A man, a plan, a canal: Panama"
    输出: true

    示例 2:

    输入: "race a car"
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-palindrome
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool IsPalindrome(string s)
        {
            if(s==null||s=="")
            {
                return true;
            }
            s = s.ToLower();
            List<char> list = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]>=48 && s[i]<=57)//数字
                {
                    list.Add(s[i]);
                }                
                else if(s[i] >= 97 && s[i] <= 122)//小写字母
                {
                    list.Add(s[i]);
                }
            }

            if(list.Count>0)
            {
                for (int i = 0; i < list.Count/2; i++)
                {
                    if (list[i] != list[list.Count - 1 - i])
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
