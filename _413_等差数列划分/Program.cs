﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _413_等差数列划分
{
    /*
        如果一个数列至少有三个元素，并且任意两个相邻元素之差相同，则称该数列为等差数列。

    例如，以下数列为等差数列:

    1, 3, 5, 7, 9
    7, 7, 7, 7
    3, -1, -5, -9

    以下数列不是等差数列。

    1, 1, 2, 5, 7

 

    数组 A 包含 N 个数，且索引从0开始。数组 A 的一个子数组划分为数组 (P, Q)，P 与 Q 是整数且满足 0<=P<Q<N 。

    如果满足以下条件，则称子数组(P, Q)为等差数组：

    元素 A[P], A[p + 1], ..., A[Q - 1], A[Q] 是等差的。并且 P + 1 < Q 。

    函数要返回数组 A 中所有为等差数组的子数组个数。

 

    示例:

    A = [1, 2, 3, 4]

    返回: 3, A 中有三个子等差数组: [1, 2, 3], [2, 3, 4] 以及自身 [1, 2, 3, 4]。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/arithmetic-slices
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = NumberOfArithmeticSlices(new int[] { 1, 2, 3, 4 });
        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            if (A.Length < 3) return 0;
            int n = A.Length - 1;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                A[i] = A[i + 1] - A[i];
            }
            int tempCount = 1;
            for (int i = 1; i < n; i++)
            {
                if(A[i]==A[i-1])
                {
                    tempCount++;
                    if(i==n-1)
                    {
                        if (tempCount >= 2)
                        {
                            count += tempCount * (tempCount - 1) / 2;
                        }
                    }
                }
                else
                {
                    if(tempCount>=2)
                    {
                        count += tempCount  * (tempCount -1) / 2;
                    }
                    tempCount = 1;
                }
            }
            return count;
        }

        public int NumberOfArithmeticSlices2(int[] A)
        {
            int dp = 0;
            int sum = 0;
            for (int i = 2; i < A.Length; i++)
            {
                if (A[i] - A[i - 1] == A[i - 1] - A[i - 2])
                {
                    dp = 1 + dp;
                    sum += dp;
                }
                else
                    dp = 0;
            }
            return sum;
        }
    }
}
