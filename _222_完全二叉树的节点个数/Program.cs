using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222_完全二叉树的节点个数
{
    /*
        给出一个完全二叉树，求出该树的节点个数。

    说明：

    完全二叉树的定义如下：在完全二叉树中，除了最底层节点可能没填满外，其余每层节点数都达到最大值，并且最下面一层的节点都集中在该层最左边的若干位置。若最底层为第 h 层，则该层包含 1~ 2h 个节点。

    示例:

    输入: 
        1
       / \
      2   3
     / \  /
    4  5 6

    输出: 6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/count-complete-tree-nodes
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int CountNodes(TreeNode root)//直接递归,适用于求所有的二叉树的节点数
        {
            if (root == null) return 0;
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }


        //方法2
        public int CountNodes1(TreeNode root)
        {
            if (root == null) return 0;
            int leftDepth = GetDepth(root.left);//左子树的高度
            int rightDepth = GetDepth(root.right);//右子树的高度
            if(leftDepth>0)
            {
                if (leftDepth == rightDepth)//左子树为满二叉树
                {
                    return (int)Math.Pow(2, leftDepth) + CountNodes1(root.right);
                }
                else //右子树为满二叉树
                {
                    return (int)Math.Pow(2, rightDepth) + CountNodes1(root.left);
                }
            }
            return 1;
        }
        int GetDepth(TreeNode node)//获取完全二叉树的高 直接沿左子树的左节点一路向下
        {
            if (node == null) return 0;
            return 1 + GetDepth(node.left);
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
