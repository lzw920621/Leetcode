using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _105_从前序与中序遍历序列构造二叉树
{
    /*
        根据一棵树的前序遍历与中序遍历构造二叉树。
    注意:
    你可以假设树中没有重复的元素。

    例如，给出

    前序遍历 preorder = [3,9,20,15,7]
    中序遍历 inorder = [9,3,15,20,7]

    返回如下的二叉树：

        3
       / \
      9  20
        /  \
       15   7

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Assist(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }

        public TreeNode Assist(int[] perorder,int left1,int right1,int[] inorder,int left2,int right2)
        {
            if (left1 > right1) return null;
            if (left1 == right1) return new TreeNode(perorder[left1]);

            int rootVal = perorder[left1];//根节点的值
            TreeNode root = new TreeNode(rootVal);//根节点
            
            //rootIndex是根节点值 在inorder中对应的索引   rootIndex左侧的值都是左子树的值,rootIndex右侧的值都是右子树的值
            int rootIndex = Array.IndexOf(inorder, rootVal);

            int countLeft = rootIndex - left2;//左子树节点个数

            root.left = Assist(perorder, left1 + 1, left1 + countLeft, inorder, left2, rootIndex - 1);
            root.right = Assist(perorder, left1 + countLeft + 1, right1, inorder, rootIndex + 1, right2);

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
