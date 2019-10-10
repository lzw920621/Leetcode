using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _87_扰乱字符串
{
    /*
        给定一个字符串 s1，我们可以把它递归地分割成两个非空子字符串，从而将其表示为二叉树。
    下图是字符串 s1 = "great" 的一种可能的表示形式。

        great
       /    \
      gr    eat
     / \    /  \
    g   r  e   at
               / \
              a   t

    在扰乱这个字符串的过程中，我们可以挑选任何一个非叶节点，然后交换它的两个子节点。

    例如，如果我们挑选非叶节点 "gr" ，交换它的两个子节点，将会产生扰乱字符串 "rgeat" 。

        rgeat
       /    \
      rg    eat
     / \    /  \
    r   g  e   at
               / \
              a   t

    我们将 "rgeat” 称作 "great" 的一个扰乱字符串。

    同样地，如果我们继续交换节点 "eat" 和 "at" 的子节点，将会产生另一个新的扰乱字符串 "rgtae" 。

        rgtae
       /    \
      rg    tae
     / \    /  \
    r   g  ta  e
           / \
          t   a

    我们将 "rgtae” 称作 "great" 的一个扰乱字符串。

    给出两个长度相等的字符串 s1 和 s2，判断 s2 是否是 s1 的扰乱字符串。

    示例 1:

    输入: s1 = "great", s2 = "rgeat"
    输出: true

    示例 2:

    输入: s1 = "abcde", s2 = "caebd"
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/scramble-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            bool result = new Program().IsScramble("great","rgtae");
        }
        //string s1, s2;
        public bool IsScramble(string s1, string s2)
        {
            if (s1 == s2) return true;
            if (s1.Length != s2.Length) return false;

            //判断两个字符串每个字母出现的次数是否一致
            int[] letters = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                letters[s1[i] - 'a']++;
                letters[s2[i] - 'a']--;
            }
            //如果两个字符串的字母出现不一致直接返回 false
            for (int i = 0; i < 26; i++)
            {
                if (letters[i] != 0)
                {
                    return false;
                }
            }

            for (int i = 1; i < s1.Length; i++)
            {
                string s11 = s1.Substring(0, i);
                string s12 = s1.Substring(i, s1.Length - i);
                string s21 = s2.Substring(0, i);
                string s22 = s2.Substring(i, s2.Length - i);
                if (IsScramble(s11, s21) && IsScramble(s12, s22)) return true;
                string s2_1 = s2.Substring(s2.Length - i, i);
                string s2_2 = s2.Substring(0, s2.Length - i);
                if (IsScramble(s11, s2_1) && IsScramble(s12, s2_2)) return true;
            }
            return false;
        }

       
    }
}
