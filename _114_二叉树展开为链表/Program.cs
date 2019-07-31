using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _114_二叉树展开为链表
{
    /*
    给定一个二叉树，原地将它展开为链表。

    例如，给定二叉树

        1
       / \
      2   5
     / \   \
    3   4   6

    将其展开为：

    1
     \
      2
       \
        3
         \
          4
           \
            5
             \
              6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/flatten-binary-tree-to-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void Flatten(TreeNode root)
        {
            if (root == null) return;
            List<TreeNode> list = new List<TreeNode>();
            
            PreOrder(root, list);
            TreeNode current = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                current.right = list[i];
                current.left = null;
                current = list[i];
            }
            current.left = null;
        }

        public static void PreOrder(TreeNode root,List<TreeNode> list)
        {
            if (root == null) return;
            list.Add(root);
            PreOrder(root.left, list);
            PreOrder(root.right, list);
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
