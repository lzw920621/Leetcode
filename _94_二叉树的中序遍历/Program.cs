using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _94_二叉树的中序遍历
{
    /*
    给定一个二叉树，返回它的中序 遍历。

    示例:

    输入: [1,null,2,3]
       1
        \
         2
        /
       3

    输出: [1,3,2]

    进阶: 递归算法很简单，你可以通过迭代算法完成吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-inorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while (curr != null || stack.Count > 0)
            {
                while (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }
                curr = stack.Pop();
                list.Add(curr.val);
                curr = curr.right;
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
