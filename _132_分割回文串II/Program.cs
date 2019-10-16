using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _132_分割回文串II
{
    /*
        给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。

    返回符合要求的最少分割次数。

    示例:

    输入: "aab"
    输出: 1
    解释: 进行一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/palindrome-partitioning-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            int min = new Program().MinCut2("fifgbeajcacehiicccfecbfhhgfiiecdcjjffbghdidbhbdbfbfjccgbbdcjheccfbhafehieabbdfeigbiaggchaeghaijfbjhi");
        }



        int min = int.MaxValue;
        //DFS + 加备忘录 部分测试用例超时 蛋疼
        public int MinCut(string s)
        {
            char[] array = s.ToCharArray();
            bool[,] map = new bool[s.Length, s.Length];
            Helper(array,0, -1, map);
            return min;
        }

        void Helper(char[] array,int index,int count, bool[,] map)
        {
            if (count > min) return;
            if (index== array.Length)
            {
                min = Math.Min(count, min);
                return;
            }
            for (int i = index; i < array.Length; i++)
            {
                if(map[index,i]==true)
                {
                    Helper(array, i + 1, count + 1, map);
                }
                else
                {
                    if (CheckPalindrome(array,index, i) == true)
                    {
                        map[index, i] = true;
                        Helper(array, i + 1, count + 1, map);
                    }
                    else
                    {
                        map[index, i] = false;
                    }
                }
            }
        }

        bool CheckPalindrome(char[] array,int left,int right)
        {            
            while (left < right)
            {
                if (array[left] != array[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        //方法2 动态规划 速度超快
        public int MinCut2(string s)
        {
            int[] min_s = new int[s.Length];//最少分割次数
            bool[,] dp = new bool[s.Length, s.Length];//dp[index1,index2]表示从index1到index2的字符串是回文字串
            for (int i = 0; i < s.Length; i++)
            {
                min_s[i] = i;//最多需要分割的次数
                for (int j = 0; j <= i; j++)
                {
                    if (s[i] == s[j] && (i - j < 2 || dp[j + 1,i - 1]))
                    {
                        dp[j,i] = true;//i-j是回文子串
                        min_s[i] = j == 0 ? 0 : Math.Min(min_s[i], min_s[j - 1] + 1);
                    }
                }
            }
            return min_s[s.Length - 1];
        }

    }
}
