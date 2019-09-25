using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _454_四数相加
{
    /*
        给定四个包含整数的数组列表 A , B , C , D ,计算有多少个元组 (i, j, k, l) ，使得 A[i] + B[j] + C[k] + D[l] = 0。
    为了使问题简单化，所有的 A, B, C, D 具有相同的长度 N，且 0 ≤ N ≤ 500 。所有整数的范围在 -228 到 228 - 1 之间，最终结果不会超过 231 - 1 。

    例如:

    输入:
    A = [ 1, 2]
    B = [-2,-1]
    C = [-1, 2]
    D = [ 0, 2]

    输出:
    2

    解释:
    两个元组如下:
    1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
    2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/4sum-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { -1, -1 };
            int[] B = new int[] { -1, 1 };
            int[] C = new int[] { -1, 1 };
            int[] D = new int[] { 1, -1 };
            int count = new Program().FourSumCount(A, B, C, D);
        }

        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            if (A.Length < 1) return 0;
            int count = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if(dic.ContainsKey(A[i]+B[j]))
                    {
                        dic[A[i] + B[j]]++;
                    }
                    else
                    {
                        dic[A[i] + B[j]] = 1;
                    }
                }
            }

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < D.Length; j++)
                {
                    if (dic.ContainsKey(-C[i] - D[j]))
                    {
                        count += dic[-C[i] - D[j]];
                    }
                    
                }
            }
            
            return count;
        }
    }
}
