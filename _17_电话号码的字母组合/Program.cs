using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_电话号码的字母组合
{
    /*
    给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。
    给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。

    示例:
    输入："23"
    输出：["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

    说明:
    尽管上面的答案是按字典序排列的，但是你可以任意选择答案输出的顺序。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/letter-combinations-of-a-phone-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

        2: a b c
        3: d e f
        4: g h i
        5: j k l
        6: m n o
        7: p q r s
        8: t u v
        9: w x y z
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = LetterCombinations("23");
        }
        static Dictionary<char, string> dic = new Dictionary<char, string>() {
            { '2', "abc" }, { '3', "def" }, { '4',"ghi"},
            {'5',"jkl" }, {'6',"mno"}, {'7',"pqrs"},
            {'8',"tuv" }, {'9',"wxyz"}
        };
        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> list = new List<string>();
            if (digits.Length == 0) return list;
            Assist(digits, 0, "", list);
            return list;
        }

        public static void Assist(string digits,int index,string str,IList<string> list)
        {
            if (index == digits.Length)
            {
                list.Add(str);
                return;
            }
            foreach (var c in dic[digits[index]])
            {                                
                Assist(digits, index + 1, str + c, list);                
            }
        }
    }
}
