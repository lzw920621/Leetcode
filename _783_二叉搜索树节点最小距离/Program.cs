using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _783_二叉搜索树节点最小距离
{
    /*
    给定一个二叉搜索树的根结点 root, 返回树中任意两节点的差的最小值。

    示例：

    输入: root = [4,2,6,1,3,null,null]
    输出: 1
    解释:
    注意，root是树结点对象(TreeNode object)，而不是数组。

    给定的树 [4,2,6,1,3,null,null] 可表示为下图:

              4
            /   \
          2      6
         / \    
        1   3  

    最小的差值是 1, 它是节点1和节点2的差值, 也是节点3和节点2的差值。

    注意：

        二叉树的大小范围在 2 到 100。
        二叉树总是有效的，每个节点的值都是整数，且不重复。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-distance-between-bst-nodes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinDiffInBST(TreeNode root)
        {
            List<int> list = new List<int>();
            GetListFromBinaryTree(root, ref list);
            list.Sort();
            int temp = int.MaxValue;
            for (int i = 0; i < list.Count-1; i++)
            {
                temp = Math.Min(Math.Abs(list[i] - list[i + 1]), temp);                
            }
            return temp;
        }

        void GetListFromBinaryTree(TreeNode root,ref List<int> list)
        {
            if (root == null) return;
            list.Add(root.val);
            GetListFromBinaryTree(root.left, ref list);
            GetListFromBinaryTree(root.right, ref list);
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
