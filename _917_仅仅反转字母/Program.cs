using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _917_仅仅反转字母
{
    /*
    给定一个字符串 S，返回 “反转后的” 字符串，其中不是字母的字符都保留在原地，而所有字母的位置发生反转。

    示例 1：

    输入："ab-cd"
    输出："dc-ba"

    示例 2：

    输入："a-bC-dEf-ghIj"
    输出："j-Ih-gfE-dCba"

    示例 3：

    输入："Test1ng-Leet=code-Q!"
    输出："Qedo1ct-eeLg=ntse-T!"

 

    提示：

        S.length <= 100
        33 <= S[i].ASCIIcode <= 122 
        S 中不包含 \ or "

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-only-letters
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            string s = ReverseOnlyLetters("Test1ng-Leet=code-Q!");
        }

        public static string ReverseOnlyLetters(string S)
        {
            char[] array = new char[S.Length];
            int left = 0, right = S.Length - 1;
            
            while (left <= right)
            {
                while ((S[left] >= 33 && S[left]<=64)||(S[left]>=91&&S[left]<=96))//不是字母
                {
                    array[left] = S[left];
                    left++;         
                    if(left>=S.Length)
                    {
                        break;
                    }
                }
                while ((S[right] >= 33 && S[right] <= 64) || (S[right] >= 91 && S[right] <= 96))//不是字母
                {
                    array[right] = S[right];
                    right--;
                    if(right<0)
                    {
                        break;
                    }
                }
                if(left<=right)
                {                   
                    array[left] = S[right];
                    array[right] = S[left];
                    left++;
                    right--;
                }                
            }
            return new string(array);
        }
    }
}
