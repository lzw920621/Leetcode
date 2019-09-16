using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008_先序遍历构造二叉树
{
    /*
        返回与给定先序遍历 preorder 相匹配的二叉搜索树（binary search tree）的根结点。
    (回想一下，二叉搜索树是二叉树的一种，其每个节点都满足以下规则，对于 node.left 的任何后代，值总 < node.val，而 node.right 的任何后代，值总 > node.val。此外，先序遍历首先显示节点的值，然后遍历 node.left，接着遍历 node.right。）

 

    示例：

    输入：[8,5,1,7,10,12]
    输出：[8,5,10,1,7,null,12]

 

    提示：

        1 <= preorder.length <= 100
        先序 preorder 中的值是不同的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/construct-binary-search-tree-from-preorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = new TreeNode(preorder[0]);
            for (int i = 1; i < preorder.Length; i++)
            {
                InsertIntoTree(root, preorder[i]);
            }
            return root;
        }

        public TreeNode InsertIntoTree(TreeNode root,int value)
        {
            if (root == null) return new TreeNode(value);
            if(value>root.val)
            {
                root.right = InsertIntoTree(root.right, value);
            }
            else
            {
                root.left = InsertIntoTree(root.left, value);
            }
            return root;
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
