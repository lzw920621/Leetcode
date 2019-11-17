using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _345_反转字符串中的元音字母
{
    /*
        编写一个函数，以字符串作为输入，反转该字符串中的元音字母。

    示例 1:

    输入: "hello"
    输出: "holle"

    示例 2:

    输入: "leetcode"
    输出: "leotcede"

    说明:
    元音字母不包含字母"y"。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-vowels-of-a-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = new Program().ReverseVowels("hello");
        }

        static HashSet<char> set = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        public string ReverseVowels(string s)
        {
            if (s.Length < 2) return s;
            
            int left = 0, right = s.Length - 1;
            char[] array = s.ToCharArray();
            while(left<right)
            {
                while(left < right && !set.Contains(array[left]))
                {
                    left++;
                }

                while(left < right && !set.Contains(array[right]))
                {
                    right--;
                }

                if(left<right)
                {
                    char temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    left++;
                    right--;                    
                }
                else
                {
                    break;
                }
            }
            return new string(array);
        }
    }
}
