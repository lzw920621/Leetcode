﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1002_查找常用字符
{
    /*
    给定仅有小写字母组成的字符串数组 A，返回列表中的每个字符串中都显示的全部字符（包括重复字符）组成的列表。
    例如，如果一个字符在每个字符串中出现 3 次，但不是 4 次，则需要在最终答案中包含该字符 3 次。
    你可以按任意顺序返回答案。
    
    示例 1：

    输入：["bella","label","roller"]
    输出：["e","l","l"]

    示例 2：

    输入：["cool","lock","cook"]
    输出：["c","o"]
    

    提示：

        1 <= A.length <= 100
        1 <= A[i].length <= 100
        A[i][j] 是小写字母

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-common-characters
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        */
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = CommonChars(new string[] { "bella", "label", "roller" });
        }

        public static IList<string> CommonChars(string[] A)
        {
            int[] map = new int[26];
            foreach (var str in A)
            {
                foreach (var charItem in str.ToCharArray())
                {
                    map[charItem - 'a'] += 1;
                }
            }
            IList<string> list = new List<string>();
            
            for (int i = 0; i < 26; i++)
            {
                if(map[i]>=3)
                {                    
                    char tempChar = (char)(i + 'a');
                    int minCount = int.MaxValue;
                    foreach (var str in A)
                    {
                        minCount = Math.Min(minCount, CountOfChar(str, tempChar));
                    }
                    for (int j = 0; j < minCount; j++)
                    {
                        list.Add(tempChar.ToString());
                    }
                }
            }
            return list;
        }

        public static int CountOfChar(string str,char a)
        {
            int count = 0;
            foreach (var item in str.ToCharArray())
            {
                if(item==a)
                {
                    count++;
                }
            }
            return count;
        }


        //方法2
        public static IList<string> CommonChars2(string[] A)
        {
            int[,] array = new int[A.Length,26];
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    array[i, A[i][j] - 'a'] += 1;
                }
            }
            IList<string> list = new List<string>();
            
            for (int i = 0; i < 26; i++)
            {
                int minCount = int.MaxValue;
                for (int j = 0; j < A.Length; j++)
                {
                    minCount = Math.Min(minCount, array[j, i]);
                    if(minCount==0)
                    {
                        break;
                    }
                }
                if(minCount>0)
                {
                    char tempChar = (char)(i + 'a');
                    for (int k = 0; k < minCount; k++)
                    {
                        list.Add(tempChar.ToString());
                    }
                }
            }
            return list;
        }

    }
}
