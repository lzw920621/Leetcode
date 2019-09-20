using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _318_最大单词长度乘积
{
    /*
        给定一个字符串数组 words，找到 length(word[i]) * length(word[j]) 的最大值，并且这两个单词不含有公共字母。
        你可以认为每个单词只包含小写字母。如果不存在这样的两个单词，返回 0。
    示例 1:

    输入: ["abcw","baz","foo","bar","xtfn","abcdef"]
    输出: 16 
    解释: 这两个单词为 "abcw", "xtfn"。

    示例 2:

    输入: ["a","ab","abc","d","cd","bcd","abcd"]
    输出: 4 
    解释: 这两个单词为 "ab", "cd"。

    示例 3:

    输入: ["a","aa","aaa","aaaa"]
    输出: 0 
    解释: 不存在这样的两个单词。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-product-of-word-lengths
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            int max = new Program().MaxProduct(new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" });
        }

        public int MaxProduct(string[] words)
        {
            int max = 0;
            bool intesection;
            for (int i = 0; i < words.Length; i++)
            {
                //获取map
                int[] map = new int[26];
                for (int j = 0; j < words[i].Length; j++)
                {
                    map[words[i][j] - 'a']++;
                }
               
                for (int j = 1; j < words.Length; j++)
                {
                    intesection = false;
                    //判断words[i]和words[j]是否有公共字符
                    for (int k = 0; k < words[j].Length; k++)
                    {
                        if (map[words[j][k] - 'a'] > 0)
                        {
                            intesection = true;
                            break;
                        }
                    }

                    if (!intesection)
                    {
                        max = Math.Max(max, words[i].Length * words[j].Length);
                    }
                }
            }
            return max;
        }
        

        //方法2 针对每个单词构造对应的二进制数与之对应 通过二进制数相交是否为零判断有没有公共字符
        public int MaxProduct2(string[] words)
        {
            /*
             * 判断由不同成分组成的单词，乘积的最大值
             * 思路：
             *  1.首先要分析出单词的成分
             *  2.然后每两个单词比较，就能确定成分是否一致，以及获取到最大值了
             *  
             * 时间复杂度：O(n^2)
             * 空间复杂度：O(n)
             */

            //遍历单词，构造二进制标识
            int[] wordPos = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words[i].Length; j++)
                    wordPos[i] |= (1 << (words[i][j] - 'a'));


            //二进制标识位运算，求得最大值
            int forReturn = 0;
            for (int k = 0; k < words.Length - 1; k++)
            {
                for (int l = k + 1; l < words.Length; l++)
                {
                    if ((wordPos[k] & wordPos[l]) == 0)
                    {
                        int maxTemp = words[k].Length * words[l].Length;

                        if (maxTemp > forReturn) forReturn = maxTemp;
                    }
                }
            }

            return forReturn;
        }
    }
}
