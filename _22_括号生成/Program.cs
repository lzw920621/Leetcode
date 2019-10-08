using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_括号生成
{
    /*
    给出 n 代表生成括号的对数，请你写出一个函数，使其能够生成所有可能的并且有效的括号组合。

    例如，给出 n = 3，生成结果为：

    [
      "((()))",
      "(()())",
      "(())()",
      "()(())",
      "()()()"
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/generate-parentheses
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
            IList<string> list = new Program().GenerateParenthesis(3);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            Assist(new char[n * 2], 0, 0, n, list);
            return list;
        }

        void Assist(char[] charArray,int count1,int count2,int n,IList<string> list)
        {
            if(count1==n && count2==n)
            {
                if (IsValid(charArray)) list.Add(new string(charArray));
            }
            else if(count1==n)
            {
                charArray[count1 + count2] = ')';
                Assist(charArray, count1, count2 + 1, n, list);
            }
            else if(count2==n)
            {
                charArray[count1 + count2] = '(';
                Assist(charArray, count1 + 1, count2, n, list);
            }
            else
            {
                char[] charArray1 = new char[2 * n];
                char[] charArray2 = new char[2 * n];
                charArray.CopyTo(charArray1, 0);
                charArray.CopyTo(charArray2, 0);
                charArray1[count1 + count2] = '(';
                charArray2[count1 + count2] = ')';
                Assist(charArray1, count1 + 1, count2, n, list);
                Assist(charArray2, count1, count2 + 1, n, list);
            }
        }

        bool IsValid(char[] charArray)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < charArray.Length; i++)
            {
                if(stack.Count==0)
                {
                    stack.Push(charArray[i]);
                }
                else
                {
                    if(charArray[i]=='(')
                    {
                        stack.Push(charArray[i]);
                    }
                    else
                    {
                        if(stack.Peek()=='(')
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            return stack.Count > 0 ? false : true;
        }
    }
}
