using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _399_除法求值
{
    /*
        给出方程式 A / B = k, 其中 A 和 B 均为代表字符串的变量， k 是一个浮点型数字。根据已知方程式求解问题，并返回计算结果。如果结果不存在，则返回 -1.0。

    示例 :
    给定 a / b = 2.0, b / c = 3.0
    问题: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? 
    返回 [6.0, 0.5, -1.0, 1.0, -1.0 ]

    输入为: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries(方程式，方程式结果，问题方程式)， 
    其中 equations.size() == values.size()，即方程式的长度与方程式结果长度相等（程式与结果一一对应），并且结果值均为正数。
    以上为方程式的描述。 返回vector<double>类型。

    基于上述例子，输入如下：

    equations(方程式) = [ ["a", "b"], ["b", "c"] ],
    values(方程式结果) = [2.0, 3.0],
    queries(问题方程式) = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ]. 

    输入总是有效的。你可以假设除法运算中不会出现除数为0的情况，且不存在任何矛盾的结果。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/evaluate-division
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */

    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> equations = new List<IList<string>>()
            {
                new List<string>() { "a","b"},
                new List<string>() { "e","f"},
                new List<string>() { "b","e"},
            };
            double[] values = new double[] { 3.4, 1.4, 2.3 };
            IList<IList<string>> queries = new List<IList<string>>()
            {
                new List<string>() { "b","a"},
                new List<string>() { "a","f"},
                new List<string>() { "f","f"},
                new List<string>() { "e","e"},
                new List<string>() { "c","c"},
                new List<string>() { "a","c"},
                new List<string>() { "f","e"},
            };

            double[] result = new Program().CalcEquation(equations, values, queries);
        }

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Tuple<double,string>> dic = new Dictionary<string, Tuple<double, string>>();
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < equations.Count; i++)
            {
                if(!dic.ContainsKey(equations[i][0]))
                {                    
                    dic[equations[i][0]] = new Tuple<double, string>(values[i], equations[i][1]);
                }
                else
                {
                    Tuple<double, string> tuple = dic[equations[i][0]];
                    dic[equations[i][1]] = new Tuple<double, string>(tuple.Item1 / values[i], tuple.Item2);
                }
                set.Add(equations[i][0]);
                set.Add(equations[i][1]);
            }

            double[] array = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                if( (!set.Contains(queries[i][0])) || (!set.Contains(queries[i][1])) )
                {
                    array[i] = -1;
                }
                else
                {                    
                    Tuple<double, string> tuple1 = Helper(dic, queries[i][0]);
                    Tuple<double, string> tuple2 = Helper(dic, queries[i][1]);

                    if (tuple1.Item2 != tuple2.Item2)
                    {
                        array[i] = -1;
                    }
                    else
                    {
                        array[i] = tuple1.Item1 / tuple2.Item1;
                    }                    
                }
            }
            return array;
        }

        Tuple<double, string> Helper(Dictionary<string, Tuple<double, string>> dic,string str)
        {
            if(dic.ContainsKey(str))
            {
                Tuple<double, string> tuple = dic[str];
                double temp = tuple.Item1;

                while(dic.ContainsKey(tuple.Item2))
                {
                    tuple = dic[tuple.Item2];
                    temp *= tuple.Item1;                   
                }
                return new Tuple<double, string>(temp, tuple.Item2);
            }
            else
            {
                return new Tuple<double, string>(1, str);
            }
        }
    }
}
