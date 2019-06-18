using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _965_单值二叉树
{
    //如果二叉树每个节点都具有相同的值，那么该二叉树就是单值二叉树。
    //只有给定的树是单值二叉树时，才返回 true；否则返回 false。


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsUnivalTree(TreeNode root)
        {
            int val = root.val;
            if (root.left != null)
            {
                if (root.left.val != val)
                {
                    return false;
                }
                else
                {
                    if (IsUnivalTree(root.left) == false)
                        return false;
                }
            }
            if (root.right != null)
            {
                if (root.right.val != val)
                {
                    return false;
                }
                else
                {
                    if (IsUnivalTree(root.right) == false)
                        return false;
                }
            }
            return true;
        }

        public bool IsUnivalTree_(TreeNode root)
        {
            if (root == null)
                return true;
            if (root.left != null && root.val != root.left.val)
                return false;
            if (root.right != null && root.val != root.right.val)
                return false;
            return IsUnivalTree(root.left) && IsUnivalTree(root.right);
        }
    }
}
