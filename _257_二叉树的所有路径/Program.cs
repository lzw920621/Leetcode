using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _257_二叉树的所有路径
{
    /*
    给定一个二叉树，返回所有从根节点到叶子节点的路径。

    说明: 叶子节点是指没有子节点的节点。

    示例:

    输入:

       1
     /   \
    2     3
     \
      5

    输出: ["1->2->5", "1->3"]

    解释: 所有根节点到叶子节点的路径为: 1->2->5, 1->3

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-paths
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static  IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> list = new List<string>();
            if (root == null) return list;
            if(root.left==null && root.right==null)
            {
                list.Add(root.val.ToString());
            }
            PreOrder(root.left, root.val.ToString(), list);
            PreOrder(root.right, root.val.ToString(), list);
            return list;
        }

        public static void PreOrder(TreeNode root,string str,IList<string> list)
        {
            if (root == null) return;
            string str1 = str + "->" + root.val;
            if (root.left==null && root.right==null)//叶子节点
            {
                list.Add(str1);
            }
            if(root.left!=null)
            {
                PreOrder(root.left, str1, list);
            }
            if(root.right!=null)
            {
                PreOrder(root.right, str1, list);
            }
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
