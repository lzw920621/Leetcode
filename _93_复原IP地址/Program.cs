using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _93_复原IP地址
{
    /*
        给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。

    示例:

    输入: "25525511135"
    输出: ["255.255.11.135", "255.255.111.35"]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/restore-ip-addresses
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = new Program().RestoreIpAddresses("1111");
        }

        public IList<string> RestoreIpAddresses(string s)
        {
            IList<string> list = new List<string>();
            Helper(s, 0, 1, "", list);
            return list;
        }

        void Helper(string s,int index,int count,string tempStr, IList<string> list)
        {
            if (index >= s.Length) return;
            
            if(count==4)
            {
                if (s.Length - index > 3) return;
                if (s[index] == '0' && s.Length - index > 1) return;
                int num = int.Parse(s.Substring(index, s.Length - index));
                if(num<=255)
                {
                    tempStr += num;
                    list.Add(tempStr);
                }
            }
            else
            {
                for (int i = index; i < index+3 && i<s.Length; i++)
                {
                    string tempStr2 = tempStr;
                    if(i>index && s[index]=='0')
                    {
                        continue;
                    }
                    if (i < 2 + index)
                    {
                        tempStr2 += s.Substring(index, i - index + 1) + ".";
                        Helper(s, i + 1, count + 1, tempStr2, list);
                    }
                    else
                    {
                        int num = int.Parse(s.Substring(index, i - index + 1));
                        if (num <= 255)
                        {
                            tempStr2 += num + ".";
                            Helper(s, i + 1, count + 1, tempStr2, list);
                        }
                    }
                }
            }
        }
    }
}
