using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_二叉树的层次遍历
{
    /*
    给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。

    例如:
    给定二叉树: [3,9,20,null,null,15,7],

        3
       / \
      9  20
        /  \
       15   7

    返回其层次遍历结果：

    [
      [3],
      [9,20],
      [15,7]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-level-order-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null) return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode current;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int leveCount = queue.Count();//当前层的节点数
                List<int> subList = new List<int>();
                for (int i = 0; i < leveCount; i++)
                {
                    current = queue.Dequeue();
                    subList.Add(current.val);

                    if (current.left != null)
                    {
                        queue.Enqueue(current.left);
                    }
                    if (current.right != null)
                    {
                        queue.Enqueue(current.right);
                    }
                }
                list.Add(subList);
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
