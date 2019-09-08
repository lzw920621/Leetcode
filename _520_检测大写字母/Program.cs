using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _520_检测大写字母
{
    /*
    给定一个单词，你需要判断单词的大写使用是否正确。

    我们定义，在以下情况时，单词的大写用法是正确的：

        全部字母都是大写，比如"USA"。
        单词中所有字母都不是大写，比如"leetcode"。
        如果单词不只含有一个字母，只有首字母大写， 比如 "Google"。

    否则，我们定义这个单词没有正确使用大写字母。

    示例 1:

    输入: "USA"
    输出: True

    示例 2:

    输入: "FlaG"
    输出: False

    注意: 输入是由大写和小写拉丁字母组成的非空单词。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/detect-capital
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;

            if(word[0]>='a')//首字母小写
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if(word[i]<'a')//后面的字母出现一个大写 则为false
                    {
                        return false;
                    }
                }
            }
            else//首字母大写
            {
                if(word[1]>='a')//第二个字母小写 则后面所有的字母都必须为小写
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if(word[i]<'a')
                        {
                            return false;
                        }
                    }
                }
                else//第二个字母大写
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if(word[i]>='a')
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool DetectCapitalUse2(string word)
        {
            if (word.Length == 1) return true;
            if (word[1] >= 'a')//第二个字母小写 则后面所有的字母都必须为小写
            {
                for (int i = 2; i < word.Length; i++)
                {
                    if (word[i] < 'a')
                    {
                        return false;
                    }
                }
            }
            else//第二个字母大写 则所有的字母都必须为大写
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] >= 'a')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
