using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1305_两棵二叉搜索树中的所有元素
{
    /*
        给你 root1 和 root2 这两棵二叉搜索树。
    请你返回一个列表，其中包含 两棵树 中的所有整数并按 升序 排序。.
    
    示例 1：

    输入：root1 = [2,1,4], root2 = [1,0,3]
    输出：[0,1,1,2,3,4]

    示例 2：

    输入：root1 = [0,-10,10], root2 = [5,1,7,0,2]
    输出：[-10,0,0,1,2,5,7,10]

    示例 3：

    输入：root1 = [], root2 = [5,1,7,0,2]
    输出：[0,1,2,5,7]

    示例 4：

    输入：root1 = [0,-10,10], root2 = []
    输出：[-10,0,10]

    示例 5：

    输入：root1 = [1,null,8], root2 = [8,1]
    输出：[1,1,8,8]

    提示：

        每棵树最多有 5000 个节点。
        每个节点的值在 [-10^5, 10^5] 之间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/all-elements-in-two-binary-search-trees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。



    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            PreSort(root1, list1);
            PreSort(root2, list2);
            List<int> list3 = new List<int>();
            int i = 0,j=0;
            while(i<list1.Count && j<list2.Count)
            {
                if(list1[i]<=list2[j])
                {
                    list3.Add(list1[i]);
                    i++;
                }
                else
                {
                    list3.Add(list2[j]);
                    j++;
                }
            }
            while(i<list1.Count)
            {
                list3.Add(list1[i]);
                i++;
            }
            while(j<list2.Count)
            {
                list3.Add(list2[j]);
                j++;
            }
            return list3;
        }

        void PreSort(TreeNode root,IList<int> list)
        {
            if (root == null) return;
            PreSort(root.left, list);
            list.Add(root.val);
            PreSort(root.right, list);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
