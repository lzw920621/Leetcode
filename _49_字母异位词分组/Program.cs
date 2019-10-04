using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49_字母异位词分组
{
    /*
        给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。

    示例:

    输入: ["eat", "tea", "tan", "ate", "nat", "bat"],
    输出:
    [
      ["ate","eat","tea"],
      ["nat","tan"],
      ["bat"]
    ]

    说明：

        所有输入均为小写字母。
        不考虑答案输出的顺序。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/group-anagrams
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> list = new List<IList<string>>();
            if (strs.Length < 1) return list;

            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                string tempStr = new string(charArray);
                if(dic.ContainsKey(tempStr))
                {
                    dic[tempStr].Add(strs[i]);
                }
                else
                {
                    dic[tempStr] = new List<string>() { strs[i] };                   
                }
            }
            foreach (var keyPair in dic)
            {
                list.Add(keyPair.Value);
            }
            return list;
        }
    }
}
