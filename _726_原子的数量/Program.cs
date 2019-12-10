using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _726_原子的数量
{
    /*
        给定一个化学式formula（作为字符串），返回每种原子的数量。
    原子总是以一个大写字母开始，接着跟随0个或任意个小写字母，表示原子的名字。
    如果数量大于 1，原子后会跟着数字表示原子的数量。如果数量等于 1 则不会跟数字。
    例如，H2O 和 H2O2 是可行的，但 H1O2 这个表达是不可行的。
    两个化学式连在一起是新的化学式。
    例如 H2O2He3Mg4 也是化学式。
    一个括号中的化学式和数字（可选择性添加）也是化学式。例如 (H2O2) 和 (H2O2)3 是化学式。
    给定一个化学式，输出所有原子的数量。格式为：第一个（按字典序）原子的名子，跟着它的数量（如果数量大于 1），
    然后是第二个原子的名字（按字典序），跟着它的数量（如果数量大于 1），以此类推。

    示例 1:

    输入: 
    formula = "H2O"
    输出: "H2O"
    解释: 
    原子的数量是 {'H': 2, 'O': 1}。

    示例 2:

    输入: 
    formula = "Mg(OH)2"
    输出: "H2MgO2"
    解释: 
    原子的数量是 {'H': 2, 'Mg': 1, 'O': 2}。

    示例 3:

    输入: 
    formula = "K4(ON(SO3)2)2"
    输出: "K4N2O14S4"
    解释: 
    原子的数量是 {'K': 4, 'N': 2, 'O': 14, 'S': 4}。

    注意:

        所有原子的第一个字母为大写，剩余字母都是小写。
        formula的长度在[1, 1000]之间。
        formula只包含字母、数字和圆括号，并且题目中给定的是合法的化学式。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/number-of-atoms
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            string value = new Program().CountOfAtoms("((HHe28Be26He)9)34");
        }

        public string CountOfAtoms(string formula)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            Helper(formula, 0, 1, dic);
            StringBuilder sb = new StringBuilder();
            foreach (var item in dic.OrderBy(keyPair => keyPair.Key))
            {
                sb.Append(item.Key);
                if(item.Value>1)
                {
                    sb.Append(item.Value);
                }               
            }
            return sb.ToString();
        }

        void Helper(string formula,int index,int num,Dictionary<string,int> dic)
        {
            for (int i = index; i < formula.Length; i++)
            {
                if(formula[i]=='(')
                {
                    int closeBracketIndex = GetCloseBracketIndex(formula, i);
                    string subFormula = formula.Substring(i + 1, closeBracketIndex - i - 1);
                    int subNumRightIndex;
                    int subNum = GetNum(formula, closeBracketIndex + 1,out subNumRightIndex);
                    Helper(subFormula, 0, subNum*num, dic);
                    i = subNumRightIndex;
                }
                else
                {
                    int atomRightIndex = GetAtomRightIndex(formula, i);
                    string atom = formula.Substring(i, atomRightIndex - i + 1);
                    i = atomRightIndex;
                    int subNum = 1;
                    if (atomRightIndex + 1<formula.Length && formula[atomRightIndex+1]>='1'&& formula[atomRightIndex + 1]<='9')
                    {
                        int subNumRightIndex;
                        subNum = GetNum(formula, atomRightIndex + 1, out subNumRightIndex);
                        i = subNumRightIndex;
                    }
                    if(dic.ContainsKey(atom))
                    {
                        dic[atom] += subNum * num;
                    }
                    else
                    {
                        dic[atom] = subNum * num;
                    }
                }
            }
        }
        /// <summary>
        /// 获取右括号的索引
        /// </summary>
        /// <param name="formula">字符串</param>
        /// <param name="openBracketIndex">左括号索引</param>
        /// <returns>右括号的索引</returns>
        int GetCloseBracketIndex(string formula, int openBracketIndex)
        {
            int countLeft = 0;
            int countRight = 0;
            for (int i = openBracketIndex; i < formula.Length; i++)
            {
                if(formula[i]=='(')
                {
                    countLeft++;
                }
                else if(formula[i]==')')
                {
                    countRight++;
                    if(countLeft==countRight)
                    {
                        return i;
                    }
                }                
            }
            return -1;
        }

        int GetNum(string formula,int index,out int numRightIndex)
        {
            numRightIndex = formula.Length - 1;
            for (int i = index+1; i < formula.Length; i++)
            {
                if(formula[i]<'0' || formula[i]>'9')//非数字
                {
                    numRightIndex = i - 1;
                    break;
                }
            }
            return int.Parse(formula.Substring(index, numRightIndex - index + 1));
        }

        int GetAtomRightIndex(string formula, int index)
        {
            for (int i = index+1; i < formula.Length; i++)
            {
                if(formula[i]>='a' && formula[i]<='z')
                {
                    //do nothing
                }
                else
                {
                    return i - 1;
                }
            }
            return formula.Length-1;
        }

    }
}
