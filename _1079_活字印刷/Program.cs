using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1079_活字印刷
{
    /*
        你有一套活字字模 tiles，其中每个字模上都刻有一个字母 tiles[i]。返回你可以印出的非空字母序列的数目。

    示例 1：

    输入："AAB"
    输出：8
    解释：可能的序列为 "A", "B", "AA", "AB", "BA", "AAB", "ABA", "BAA"。

    示例 2：

    输入："AAABBC"
    输出：188

    提示：
        1 <= tiles.length <= 7
        tiles 由大写英文字母组成

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/letter-tile-possibilities
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        

        public int NumTilePossibilities(string tiles)
        {
            char[] charArray = tiles.ToCharArray();
            bool[] assistArray = new bool[tiles.Length];
            HashSet<string> set = new HashSet<string>();
            DFS(charArray, assistArray, new StringBuilder(), set);
            return set.Count;
        }

        void DFS(char[] charArray,bool[] assistArray,StringBuilder sb, HashSet<string> set)
        {
            if(sb.Length>0)
            {
                set.Add(sb.ToString());
            }

            for (int i = 0; i < assistArray.Length; i++)
            {
                if(assistArray[i]==false)
                {
                    assistArray[i] = true;
                    sb.Append(charArray[i]);
                    DFS(charArray, assistArray, sb,set);
                    sb.Remove(sb.Length - 1, 1);
                    assistArray[i] = false;
                }
            }
        }

        public int NumTilePossibilities2(string tiles)
        {
            int[] array = new int[26];
            for (int i = 0; i < tiles.Length; i++)
            {
                array[tiles[i] - 'A']++;
            }
            return DFS2(array);
        }

        int DFS2(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]>0)
                {
                    sum++;
                    array[i]--;
                    sum += DFS2(array);
                    array[i]++;
                }
            }
            return sum;
        }
    }
}
