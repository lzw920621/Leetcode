using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_有效的括号
{
    /*
    给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
    有效字符串需满足：
        左括号必须用相同类型的右括号闭合。
        左括号必须以正确的顺序闭合。

    注意空字符串可被认为是有效字符串。

    示例 1:

    输入: "()"
    输出: true

    示例 2:

    输入: "()[]{}"
    输出: true

    示例 3:

    输入: "(]"
    输出: false

    示例 4:

    输入: "([)]"
    输出: false

    示例 5:

    输入: "{[]}"
    输出: true

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/valid-parentheses
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            if (s.Length % 2 != 0)
                return false;
            Stack<char> stack = new Stack<char>();
            stack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if(s[i]=='(' || s[i]=='[' || s[i]=='{' || stack.Count == 0)
                {
                    stack.Push(s[i]);
                }
                else
                {
                    char temp = stack.Peek();
                    if (temp == '(')
                    {
                        if (s[i] == ')') stack.Pop();
                        else return false;
                    }
                    else if(temp=='[')
                    {
                        if (s[i] == ']') stack.Pop();
                        else return false;
                    }
                    else if(temp=='{')
                    {
                        if (s[i] == '}') stack.Pop();
                        else return false;
                    }
                    else //temp:')' ']' '}'
                    {                        
                        stack.Push(s[i]);
                    }
                }                
            }
            return stack.Count > 0 ? false : true;
        }
    }
}
