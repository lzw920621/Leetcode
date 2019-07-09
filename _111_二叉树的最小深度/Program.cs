using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _111_二叉树的最小深度
{
    /*
    给定一个二叉树，找出其最小深度。

    最小深度是从根节点到最近叶子节点的最短路径上的节点数量。

    说明: 叶子节点是指没有子节点的节点。

    示例:

    给定二叉树 [3,9,20,null,null,15,7],

        3
       / \
      9  20
        /  \
       15   7

    返回它的最小深度  2.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/minimum-depth-of-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null)//叶子节点
            {
                return 1;
            }
            else if(root.left==null)//左子树空 右子树非空
            {
                return 1 + MinDepth(root.right);
            }
            else if(root.right==null)//左子树非空 右子树空
            {
                return 1 + MinDepth(root.left);
            }
            else//左右子树均非空
            {
                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }
            
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
