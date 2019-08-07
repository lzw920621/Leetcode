using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _279_完全平方数
{
    /*
    给定正整数 n，找到若干个完全平方数（比如 1, 4, 9, 16, ...）使得它们的和等于 n。你需要让组成和的完全平方数的个数最少。
    示例 1:

    输入: n = 12
    输出: 3 
    解释: 12 = 4 + 4 + 4.

    示例 2:

    输入: n = 13
    输出: 2
    解释: 13 = 4 + 9.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/perfect-squares
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = NumSquares(13);
        }

        static Dictionary<int, int> dic = new Dictionary<int, int>
        { { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 1 }, { 5, 2 }, { 6, 3 },
            { 7, 4 }, { 8, 2 }, { 9, 1 }, { 10, 2 },{11,3 },{12, 3} };
        //方法1 动态规划
        public static int NumSquares(int n)
        {
            if (dic.ContainsKey(n)) return dic[n];
            if (n == 0) return 0;
            int count = 0;
            int maxSquare = GetBiggestSquareNum(n);
            List<int> countList = new List<int>();
            for (int i = maxSquare; i > 0; i--)
            {
                count = 1 + NumSquares(n - i * i);
                countList.Add(count);
            }
            int minCount = countList.Min();
            dic.Add(n, minCount);
            return minCount;
        }
        public static int GetBiggestSquareNum(int n)
        {
            int num =(int)Math.Sqrt(n);
            return num;
        }

        public static int NumSquares2(int n)//四平方数和定理 每个正整数均可表为四个整数的平方和(其中有些整数可以为零)。
        {
            while (n % 4 == 0)
            {
                n /= 4;
            }
            if (n % 8 == 7)
            {
                return 4;
            }
            for (int i = 0; i * i <= n; i++)
            {
                int r = (int)Math.Sqrt(n - i * i);
                if (i * i + r * r == n)
                {
                    if (i == 0 || r == 0) return 1;
                    return 2;
                }
            }
            return 3;
        }
    }
}
