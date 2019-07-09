using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101_对称二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool IsSymmetric(TreeNode root)
        {
            return isMirror(root, root);
        }
        public static bool isMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;
            if (t1 == null || t2 == null)
                return false;
            return (t1.val == t2.val) && isMirror(t1.right, t2.left) && isMirror(t1.left, t2.right);
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
