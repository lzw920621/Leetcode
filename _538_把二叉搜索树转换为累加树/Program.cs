using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _538_把二叉搜索树转换为累加树
{
    /*
    给定一个二叉搜索树（Binary Search Tree），把它转换成为累加树（Greater Tree)，使得每个节点的值是原来的节点值加上所有大于它的节点值之和。

    例如：
    输入: 二叉搜索树:
                  5
                /   \
               2     13

    输出: 转换为累加树:
                 18
                /   \
              20     13

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/convert-bst-to-greater-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            RightRootLeftOrder(root, ref sum);
            return root;
        }
        public static void RightRootLeftOrder(TreeNode root,ref int sum)
        {
            if (root == null)
            {
                return;
            }
            RightRootLeftOrder(root.right, ref sum);
            root.val += sum;
            sum = root.val;
            RightRootLeftOrder(root.left, ref sum);
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
