using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _97_交错字符串
{
    /*
        给定三个字符串 s1, s2, s3, 验证 s3 是否是由 s1 和 s2 交错组成的。

    示例 1:

    输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
    输出: true

    示例 2:

    输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
    输出: false

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/interleaving-string
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool isTrue = new Program().IsInterleave("aabcc","dbbca","aadbbcbcac");
        }


        string s1, s2, s3;
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            this.s1 = s1;
            this.s2 = s2;
            this.s3 = s3;
            return Assist( 0, 0, 0);
        }
        //dfs 部分测试用例超时
        bool Assist(int index1,int index2,int index3)
        {
            if (index1 == s1.Length && index2==s2.Length) return true;
           
            if (index1 < s1.Length && s1[index1] == s3[index3])
            {
                if (Assist(index1 + 1, index2, index3 + 1)) return true;               
            }
            if (index2 < s2.Length && s2[index2] == s3[index3])
            {
                if (Assist(index1, index2 + 1, index3 + 1)) return true;
            }
            return false;
        }

        //优化Assist,增加备忘录,存储已知的结果
        Dictionary<string, bool> dic = new Dictionary<string, bool>();
        bool Assist2(int index1, int index2, int index3)
        {
            if (index1 == s1.Length && index2 == s2.Length) return true;

            if(dic.ContainsKey(index1 + " " + index2))
            {
                return false;
            }

            if (index1 < s1.Length && s1[index1] == s3[index3])
            {
                if (Assist2(index1 + 1, index2, index3 + 1)) return true;
                dic[index1 + " " + index2] = false;
            }
            if (index2 < s2.Length && s2[index2] == s3[index3])
            {
                if (Assist2(index1, index2 + 1, index3 + 1)) return true;
                dic[index1 + " " + index2] = false;
            }
            return false;
        }
    }
}
