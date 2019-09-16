using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _96_不同的二叉搜索树
{
    /*
        给定一个整数 n，求以 1 ... n 为节点组成的二叉搜索树有多少种？

    示例:

    输入: 3
    输出: 5
    解释:
    给定 n = 3, 一共有 5 种不同结构的二叉搜索树:

       1         3     3      2      1
        \       /     /      / \      \
         3     2     1      1   3      2
        /     /       \                 \
       2     1         2                 3

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/unique-binary-search-trees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            int num = program.NumTrees(3);
        }

        Dictionary<int, int> dic = new Dictionary<int, int>() { { 0, 1 }, { 1, 1 } };
        public int NumTrees(int n)
        {            
            if(n <= 1)
            {
                return 1;
            }
            else
            {
                int num = 0;
                int numLeft, numRight;
                for (int i = 1; i <= n; i++)
                {
                    if(dic.ContainsKey(i-1))
                    {
                        numLeft = dic[i - 1];
                    }
                    else
                    {
                        numLeft = NumTrees(i - 1);
                        dic[i - 1] = numLeft;
                    }
                    if(dic.ContainsKey(n-i))
                    {
                        numRight = dic[n - i];
                    }
                    else
                    {
                        numRight = NumTrees(n - i);
                        dic[n - i] = numRight;
                    }
                    num += numLeft * numRight;
                }
               
                return num;
            }
        }
    }
}
