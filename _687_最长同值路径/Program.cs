using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_最长同值路径
{
    /*
    给定一个二叉树，找到最长的路径，这个路径中的每个节点具有相同值。 这条路径可以经过也可以不经过根节点。
    注意：两个节点之间的路径长度由它们之间的边数表示。

    示例 1:

    输入:
                  5
                 / \
                4   5
               / \   \
              1   1   5

    输出:

    2

    示例 2:

    输入:
                  1
                 / \
                4   5
               / \   \
              4   4   5

    输出:

    2

    注意: 给定的二叉树不超过10000个结点。 树的高度不超过1000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/longest-univalue-path
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null) return 0;
            int left = LongestUnivaluePath(root.left);//左子树的同值路径
            int right = LongestUnivaluePath(root.right);//右子树的同值路径
            int temp = Assist(root.left, root.val) + Assist(root.right, root.val);
            return Math.Max(temp, Math.Max(left, right));
        }

        public int Assist(TreeNode node,int value)//以节点node向下延伸的同值路径最大值(包含节点node)
        {
            if (node == null) return 0;
            if (node.val != value) return 0;
            return 1 + Math.Max(Assist(node.left, value), Assist(node.right, value));
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
