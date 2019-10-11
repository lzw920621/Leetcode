using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _131_分割回文串
{
    /*
        给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。

    返回 s 所有可能的分割方案。

    示例:

    输入: "aab"
    输出:
    [
      ["aa","b"],
      ["a","a","b"]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/palindrome-partitioning
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> list = new Program().Partition2("cbbbcc");
        }

        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> list = new List<IList<string>>();
            if (s.Length<1) return list;
            Helper(s, new List<string>(), list);
            return list;
        }

        void Helper(string s, List<string> tempList, IList<IList<string>> list)
        {
            if (s.Length < 1) return;
            if(s.Length==1)
            {
                tempList.Add(s);
                list.Add(tempList);
                return;
            }
            List<string> tempList2 = new List<string>(tempList);
            tempList2.Add(s.Substring(0, 1));
            Helper(s.Substring(1, s.Length - 1), tempList2, list);
            for (int i = 1; i < s.Length; i++)
            {
                string tempStr = s.Substring(0, i + 1);
                if(CheckPalindrome(tempStr))
                {
                    List<string> tempList3 = new List<string>(tempList);
                    tempList3.Add(tempStr);
                    if(i==s.Length-1)
                    {
                        list.Add(tempList3);
                        return;
                    }
                    else
                    {
                        Helper(s.Substring(i + 1, s.Length - i - 1), tempList3, list);
                    }
                }
            }
        }

        bool CheckPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while(left<right)
            {
                if(s[left]!=s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }


        public IList<IList<string>> Partition2(string s)
        {
            IList<IList<string>> list = new List<IList<string>>();
            Backtrace(s, new List<string>(), list);
            return list;
        }

        void Backtrace(string s, List<string> tempList, IList<IList<string>> list)
        {
            if (s == null || s.Length == 0)
            {
                list.Add(new List<string>(tempList));
                return;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                string tempStr = s.Substring(0, i);
                if (CheckPalindrome(tempStr))
                {
                    tempList.Add(tempStr);
                    if(i==s.Length)
                    {
                        Backtrace(null, tempList, list);
                    }
                    else
                    {
                        Backtrace(s.Substring(i, s.Length - i), tempList, list);
                    }
                    tempList.RemoveAt(tempList.Count-1);//回溯
                }
            }
        }
    }
}
