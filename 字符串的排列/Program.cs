using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _567_字符串的排列
{
    /*
    给定两个字符串 s1 和 s2，写一个函数来判断 s2 是否包含 s1 的排列。

    换句话说，第一个字符串的排列之一是第二个字符串的子串。

    示例1:

    输入: s1 = "ab" s2 = "eidbaooo"
    输出: True
    解释: s2 包含 s1 的排列之一 ("ba").

 

    示例2:

    输入: s1= "ab" s2 = "eidboaoo"
    输出: False

 

    注意：

        输入的字符串只包含小写字母
        两个字符串的长度都在 [1, 10,000] 之间
        

    */
    class Program
    {
        static void Main(string[] args)
        {
            bool b = CheckInclusion1("adc","dcda");
        }

        public static bool CheckInclusion(string s1, string s2)//效率不高
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length; i++)
            {
                if(dic.ContainsKey(s1[i]))
                {
                    dic[s1[i]]++;
                }
                else
                {
                    dic.Add(s1[i], 1);
                }
            }

            Dictionary<char, int> newDic = new Dictionary<char, int>(dic);
            //newDic.Concat(dic);
            int right;
            bool flag = true;
            for (int left = 0; left < s2.Length; left++)
            {
                flag = true;
                right = left + s1.Length - 1;
                {
                    if (right >= s2.Length) return false;
                }
                for (int i = left; i <= right; i++)
                {
                    if(newDic.ContainsKey(s2[i]))//dic中包含该字符
                    {
                        newDic[s2[i]]--;
                    } 
                    else//该字符不在dic中 标志位flag置为false 索引left置为i
                    {
                        flag = false;
                        left = i;
                        break;
                    }
                }
                if(flag==true)//left--right之间的字符都在dic中
                {
                    foreach (var item in newDic.Keys)
                    {
                        if (newDic[item] != 0)
                        {
                            flag = false;
                        }
                    }
                    if(flag==true)
                    {
                        return true;
                    }
                    else
                    {
                        newDic.Clear();
                        newDic = new Dictionary<char, int>(dic);//重置newdic
                    }
                }
                else
                {
                    newDic.Clear();
                    newDic = new Dictionary<char, int>(dic);//重置newdic
                }
               
            }
            return false;
        }


        public static bool CheckInclusion1(string s1, string s2)//效率不高
        {
            int[] array1 = GetArrayFromString(s1, 0, s1.Length-1);

            bool flag;
            int right;

            for (int left = 0; left <= s2.Length-s1.Length; left++)
            {
                right = left + s1.Length - 1;
                flag = true;
                for (int i = left; i <= right; i++)
                {
                    if(array1[s2[i]-'a']==0)//该字符不在s1中
                    {
                        left = i;
                        flag = false;
                        break;
                    }
                }
                if(flag==true)//left--right之间的所有字符都在s1中
                {
                    int[] array2 = GetArrayFromString(s2, left, right);
                    if(array1.SequenceEqual(array2))
                    {
                        return true;
                    }
                }                
            }
            return false;
        }

        public static int[] GetArrayFromString(string str,int left,int right)
        {
            int[] array = new int[26];
            for (; left <=right; left++)
            {
                array[str[left] - 'a'] += 1;
            }
            return array;
        }

        public static bool CheckInclusion2(string s1, string s2)//效率最高的方法
        {
            if (s1.Length > s2.Length) return false;
            int[] c1 = new int[26];
            int[] c2 = new int[26];
            foreach (char c in s1.ToCharArray())
            {
                c1[c - 'a']++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (i >= s1.Length)
                {
                    c2[s2[i - s1.Length] - 'a']--;
                }
                
                c2[s2[i] - 'a']++;

                if (c1.SequenceEqual(c2))
                    return true;
            }
            return false;
        }
    }
}
