using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _144_二叉树的前序遍历
{
    /*
    给定一个二叉树，返回它的 前序 遍历。

     示例:

    输入: [1,null,2,3]  
       1
        \
         2
        /
       3 

    输出: [1,2,3]

    进阶: 递归算法很简单，你可以通过迭代算法完成吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-preorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */

    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            stack.Push(current);
            while (stack.Count > 0)
            {
                current = stack.Pop();
                list.Add(current.val);
                if (current.right != null)
                {
                    stack.Push(current.right);
                }
                if (current.left != null)
                {
                    stack.Push(current.left);
                }
            }
            return list;
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
