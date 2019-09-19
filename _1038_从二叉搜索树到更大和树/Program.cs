using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1038_从二叉搜索树到更大和树
{
    /*
        给出二叉搜索树的根节点，该二叉树的节点值各不相同，修改二叉树，使每个节点 node 的新值等于原树中大于或等于 node.val 的值之和。

    提醒一下，二叉搜索树满足下列约束条件：

        节点的左子树仅包含键小于节点键的节点。
        节点的右子树仅包含键大于节点键的节点。
        左右子树也必须是二叉搜索树。

 

    示例：

    输入：[4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
    输出：[30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]

 

    提示：

        树中的节点数介于 1 和 100 之间。
        每个节点的值介于 0 和 100 之间。
        给定的树为二叉搜索树。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-search-tree-to-greater-sum-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode BstToGst(TreeNode root)
        {
            int tempSum = 0;
            Assist(root, ref tempSum);
            return root;
        }
        void Assist(TreeNode root,ref int tempSum)
        {
            if (root == null) return;
            Assist(root.right, ref tempSum);
            tempSum += root.val;
            root.val = tempSum;
            Assist(root.left, ref tempSum);
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
