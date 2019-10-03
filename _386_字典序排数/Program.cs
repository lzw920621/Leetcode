﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _386_字典序排数
{
    /*
        给定一个整数 n, 返回从 1 到 n 的字典顺序。
    例如，
    给定 n =1 3，返回 [1,10,11,12,13,2,3,4,5,6,7,8,9] 。

    请尽可能的优化算法的时间复杂度和空间复杂度。 输入的数据 n 小于等于 5,000,000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/lexicographical-numbers
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new Program().LexicalOrder(22);
        }

        public IList<int> LexicalOrder(int n)
        {
            IList<int> list = new List<int>();
            for (int i = 1; i <= 9; i++)
            {
                if(i<=n)
                {
                    list.Add(i);
                    Assist(i, n, list);
                }
                else
                {
                    break;
                }
            }
            return list;
        }
        void Assist(int tempNum, int n, IList<int> list)
        {
            int temp;
            for (int i = 0; i <= 9; i++)
            {
                temp = tempNum * 10 + i;
                if(temp<=n)
                {
                    list.Add(temp);
                    Assist(temp, n, list);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
