using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1189_气球的最大数量
{
    /*
        给你一个字符串 text，你需要使用 text 中的字母来拼凑尽可能多的单词 "balloon"（气球）。
    字符串 text 中的每个字母最多只能被使用一次。请你返回最多可以拼凑出多少个单词 "balloon"。

    示例 1：

    输入：text = "nlaebolko"
    输出：1

    示例 2：

    输入：text = "loonbalxballpoon"
    输出：2

    示例 3：

    输入：text = "leetcode"
    输出：0

 

    提示：

        1 <= text.length <= 10^4
        text 全部由小写英文字母组成

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-number-of-balloons
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxNumberOfBalloons(string text)
        {
            int countA = 0;
            int countB = 0;
            int countL = 0;
            int countN = 0;
            int countO = 0;
            foreach (var item in text)
            {
                switch(item)
                {
                    case 'a':countA++;break;
                    case 'b':countB++;break;
                    case 'l':countL++;break;
                    case 'n':countN++;break;
                    case 'o':countO++;break;
                    default:break;
                }
            }
            int num = int.MaxValue;
            num = Math.Min(num, countA);
            num = Math.Min(num, countB);
            num = Math.Min(num, countL / 2);
            num = Math.Min(num, countO / 2);
            num = Math.Min(num, countN);
            return num;
        }
    }
}
