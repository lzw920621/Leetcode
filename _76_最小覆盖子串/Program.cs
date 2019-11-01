using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _76_最小覆盖子串
{
    /*
        给你一个字符串 S、一个字符串 T，请在字符串 S 里面找出：包含 T 所有字母的最小子串。
    示例：

    输入: S = "ADOBECODEBANC", T = "ABC"
    输出: "BANC"

    说明：
        如果 S 中不存这样的子串，则返回空字符串 ""。
        如果 S 中存在这样的子串，我们保证它是唯一的答案。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-window-substring
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Program().MinWindow("ADOBECODEBANC", "ABC");
        }

        //滑动窗口法
        public string MinWindow(string s, string t)
        {
            if (s.Length < t.Length) return "";
            
            int minLength = int.MaxValue;
            string str = "";
            int left = 0, right = t.Length-1;

            int[] mapT = new int[58];
            for (int i = 0; i < t.Length; i++)
            {
                mapT[t[i] - 'A']++;
            }
            int[] mapTemp = new int[58];
            for (int i = 0; i <= right; i++)
            {
                mapTemp[s[i] - 'A']++;
            }

            while(right<s.Length)
            {
                if(IsContain(mapTemp,mapT)==false)
                {
                    if(right+1<s.Length)
                    {
                        right++;
                        mapTemp[s[right] - 'A']++;
                    }    
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if(right-left+1<minLength)
                    {
                        minLength = right - left + 1;
                        str = s.Substring(left, minLength);
                    }
                    mapTemp[s[left] - 'A']--;
                    left++;
                }
            }
            return str;
        }

        bool IsContain(int[] mapTemp,int[] mapT)
        {
            for (int i = 0; i < mapT.Length; i++)
            {
                if(mapT[i]>mapTemp[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
