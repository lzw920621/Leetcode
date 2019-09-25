using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _599_两个列表的最小索引总和
{
    /*
        假设Andy和Doris想在晚餐时选择一家餐厅，并且他们都有一个表示最喜爱餐厅的列表，每个餐厅的名字用字符串表示。
    你需要帮助他们用最少的索引和找出他们共同喜爱的餐厅。 如果答案不止一个，则输出所有答案并且不考虑顺序。 你可以假设总是存在一个答案。

    示例 1:

    输入:
    ["Shogun", "Tapioca Express", "Burger King", "KFC"]
    ["Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun"]
    输出: ["Shogun"]
    解释: 他们唯一共同喜爱的餐厅是“Shogun”。

    示例 2:

    输入:
    ["Shogun", "Tapioca Express", "Burger King", "KFC"]
    ["KFC", "Shogun", "Burger King"]
    输出: ["Shogun"]
    解释: 他们共同喜爱且具有最小索引和的餐厅是“Shogun”，它有最小的索引和1(0+1)。

    提示:

        两个列表的长度范围都在 [1, 1000]内。
        两个列表中的字符串的长度将在[1，30]的范围内。
        下标从0开始，到列表的长度减1。
        两个列表都没有重复的元素。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-index-sum-of-two-lists
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            int index1, index2;
            int minIndexSum = int.MaxValue;
            
            List<string> list = new List<string>();
            for (index1 = 0; index1 < list1.Length; index1++)
            {
                for (index2 = 0; index2 < list2.Length; index2++)
                {
                    if (list1[index1] == list2[index2])
                    {
                        //minIndexSum = Math.Min(minIndexSum, index1 + index2);
                        if (index1 + index2 < minIndexSum)
                        {
                            minIndexSum = index1 + index2;
                            list = new List<string>();
                            list.Add(list1[index1]);
                        }
                        else if (index1 + index2 == minIndexSum)
                        {
                            list.Add(list1[index1]);
                        }
                    }
                }
            }
            return list.ToArray();
        }

        public string[] FindRestaurant2(string[] list1, string[] list2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int minIndexSum = int.MaxValue;
            List<string> list = new List<string>();

            for (int i = 0; i < list2.Length; i++)
            {
                dic[list2[i]] = i;
            }
            for (int i = 0; i < list1.Length; i++)
            {
                if (dic.ContainsKey(list1[i]))
                {
                    if (i + dic[list1[i]] < minIndexSum)
                    {
                        minIndexSum = i + dic[list1[i]];
                        list.Clear();
                        list.Add(list1[i]);
                    }
                    else if (i + dic[list1[i]] == minIndexSum)
                    {
                        list.Add(list1[i]);
                    }
                }
            }

            return list.ToArray();
        }
    }
}
