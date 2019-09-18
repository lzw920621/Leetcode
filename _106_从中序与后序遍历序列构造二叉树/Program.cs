using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106_从中序与后序遍历序列构造二叉树
{
    /*
        根据一棵树的中序遍历与后序遍历构造二叉树。
    注意:
    你可以假设树中没有重复的元素。

    例如，给出

    中序遍历 inorder = [9,3,15,20,7]
    后序遍历 postorder = [9,15,7,20,3]

    返回如下的二叉树：

        3
       / \
      9  20
        /  \
       15   7

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return Assist(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        public TreeNode Assist(int[] inorder,int left1,int right1,int[] postorder,int left2,int right2)
        {
            if (left1 > right1) return null;
            if (left1 == right1) return new TreeNode(inorder[left1]);

            int rootVal = postorder[right2];
            TreeNode root = new TreeNode(rootVal);

            int rootIndex = Array.IndexOf(inorder, rootVal);
            int countLeft = rootIndex - left1;

            root.left = Assist(inorder, left1, rootIndex - 1, postorder, left2, left2 + countLeft - 1);
            root.right = Assist(inorder, rootIndex + 1, right1, postorder, left2 + countLeft, right2-1);

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
