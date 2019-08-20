using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _543_二叉树的直径
{
    /*
    给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过根结点。

    示例 :
    给定二叉树

              1
             / \
            2   3
           / \     
          4   5    

    返回 3, 它的长度是路径 [4,2,1,3] 或者 [5,2,1,3]。

    注意：两结点之间的路径长度是以它们之间边的数目表示。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/diameter-of-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }


        public static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            int diameter1 = GetHight(root.left) + GetHight(root.right);
            int diameter2 = DiameterOfBinaryTree(root.left);
            int diameter3 = DiameterOfBinaryTree(root.right);
            return Math.Max(diameter1, Math.Max(diameter2, diameter3));
        }
        static int GetHight(TreeNode node)
        {
            if(node==null)
            {
                return 0;
            }
            else
            {
                return Math.Max(GetHight(node.left), GetHight(node.right)) + 1;
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
