using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _119_杨辉三角II
{
    /*
        给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。
    在杨辉三角中，每个数是它左上方和右上方的数的和。

    示例:

    输入: 3
    输出: [1,3,3,1]

    进阶：

    你可以优化你的算法到 O(k) 空间复杂度吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/pascals-triangle-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<int> GetRow(int rowIndex)
        {
            IList<int> list = new List<int>();
            list.Add(1);
            for (int i = 0; i < rowIndex; i++)
            {
                for (int j = list.Count-1; j >0; j--)//这里倒着遍历比较关键 可以避免前值被覆盖
                {
                    list[j] = list[j] + list[j - 1];
                }
                list.Add(1);
            }
            return list;
        }
    }
}
