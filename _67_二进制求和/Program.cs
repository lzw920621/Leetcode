using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67_二进制求和
{
    /*
    给定两个二进制字符串，返回他们的和（用二进制表示）。

    输入为非空字符串且只包含数字 1 和 0。

    示例 1:

    输入: a = "11", b = "1"
    输出: "100"

    示例 2:

    输入: a = "1010", b = "1011"
    输出: "10101"

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/add-binary
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string str = AddBinary("1010", "1011");

        }

        public static string AddBinary(string a, string b)
        {
            int indexA = a.Length - 1;
            int indexB = b.Length - 1;
            char[] arrayC = (a.Length > b.Length) ? new char[a.Length] : new char[b.Length];
            int indexC = arrayC.Length - 1;
            int carry = 0;            
            int temp = 0;
            
            while(indexA>=0 && indexB>=0)
            {              
                temp = a[indexA] - '0' + b[indexB] - '0' + carry;
                switch(temp)
                {
                    case 0:carry = 0; arrayC[indexC] = '0'; break;
                    case 1:carry = 0; arrayC[indexC] = '1';break;
                    case 2:carry = 1;arrayC[indexC] = '0';break;
                    case 3:carry = 1;arrayC[indexC] = '1';break;
                }                
                indexA--;
                indexB--;
                indexC--;
            }
            while(indexA>=0)
            {
                temp = a[indexA] - '0' + carry;
                switch (temp)
                {
                    case 0: carry = 0; arrayC[indexC] = '0'; break;
                    case 1: carry = 0; arrayC[indexC] = '1'; break;
                    case 2: carry = 1; arrayC[indexC] = '0'; break;
                    case 3: carry = 1; arrayC[indexC] = '1'; break;
                }
                indexA--;                
                indexC--;
            }
            while(indexB>=0)
            {
                temp = b[indexB] - '0' + carry;
                switch (temp)
                {
                    case 0: carry = 0; arrayC[indexC] = '0'; break;
                    case 1: carry = 0; arrayC[indexC] = '1'; break;
                    case 2: carry = 1; arrayC[indexC] = '0'; break;
                    case 3: carry = 1; arrayC[indexC] = '1'; break;
                }
                indexB--;
                indexC--;
            }
            if(carry==1)
            {
                return '1' + new string(arrayC);
            }
            return new string(arrayC);
        }
    }
}
