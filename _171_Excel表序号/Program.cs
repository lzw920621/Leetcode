﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _171_Excel表序号
{
    /*
    给定一个Excel表格中的列名称，返回其相应的列序号。

    例如，

        A -> 1
        B -> 2
        C -> 3
        ...
        Z -> 26
        AA -> 27
        AB -> 28 
        ...

    示例 1:

    输入: "A"
    输出: 1

    示例 2:

    输入: "AB"
    输出: 28

    示例 3:

    输入: "ZY"
    输出: 701

    致谢：
    特别感谢 @ts 添加此问题并创建所有测试用例。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/excel-sheet-column-number
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int n = TitleToNumber("AB");
        }

        public static int TitleToNumber(string s)
        {
            double n = 0;
            int m = 0;
            for (int i = s.Length-1; i >=0; i--)
            {
                n += (s[i] - 'A' + 1) * Math.Pow(26, m);
                m++;
            }
            return (int)n;
        }
    }
}
