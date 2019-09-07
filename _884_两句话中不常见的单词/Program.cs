using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _884_两句话中不常见的单词
{
    /*
    给定两个句子 A 和 B 。 （句子是一串由空格分隔的单词。每个单词仅由小写字母组成。）
    如果一个单词在其中一个句子中只出现一次，在另一个句子中却没有出现，那么这个单词就是不常见的。
    返回所有不常用单词的列表。
    您可以按任何顺序返回列表。
    
    示例 1：

    输入：A = "this apple is sweet", B = "this apple is sour"
    输出：["sweet","sour"]

    示例 2：

    输入：A = "apple apple", B = "banana"
    输出：["banana"]

    提示：

        0 <= A.length <= 200
        0 <= B.length <= 200
        A 和 B 都只包含空格和小写字母。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/uncommon-words-from-two-sentences
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "s z z z s";
            string str2 = "s z ejt";
            string[] array = UncommonFromSentences(str1, str2);
        }

        public static string[] UncommonFromSentences(string A, string B)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var str in A.Split(' '))
            {
                if(dic.ContainsKey(str))
                {
                    dic[str]++;
                }
                else
                {
                    dic[str] = 1;
                }
            }
            foreach (var str in B.Split(' '))
            {
                if (dic.ContainsKey(str))
                {
                    dic[str]++;
                }
                else
                {
                    dic[str] = 1;
                }
            }
            return dic.Where(pair => pair.Value == 1).Select(pair => pair.Key).ToArray();
        }
        
    }
}
