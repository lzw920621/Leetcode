using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_二叉树的最近公共祖先
{
    /*
    给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
    百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”

    例如，给定如下二叉树:  root = [3,5,1,6,2,0,8,null,null,7,4]

    示例 1:

    输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
    输出: 3
    解释: 节点 5 和节点 1 的最近公共祖先是节点 3。

    示例 2:

    输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
    输出: 5
    解释: 节点 5 和节点 4 的最近公共祖先是节点 5。因为根据定义最近公共祖先节点可以为节点本身。
    
    说明:

        所有节点的值都是唯一的。
        p、q 为不同节点且均存在于给定的二叉树中。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root == p || root == q) return root;
            if(IsContainsNode(root.left,p))//以左节点为根的树包含节点p
            {
                if(IsContainsNode(root.left,q))//以左节点为根的树包含节点q
                {
                    return LowestCommonAncestor(root.left, p, q);
                }
                else//以左节点为根的树包不含节点q (p,q分别在根节点的左右子树中)
                {
                    return root;
                }
            }
            else//以右节点为根的树包含节点p
            {
                if(IsContainsNode(root.right,q))//以右节点为根的树包含节点q
                {
                    return LowestCommonAncestor(root.right, p, q);
                }
                else
                {
                    return root;
                }
            }
        }

        public bool IsContainsNode(TreeNode root,TreeNode targerNode)
        {
            if (root == null) return false;
            if(root==targerNode)
            {
                return true;
            }
            else
            {
                return IsContainsNode(root.left, targerNode) || IsContainsNode(root.right, targerNode);
            }
        }

        //方法2
        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root == p || root == q) return root;
            TreeNode left = LowestCommonAncestor1(root.left, p, q);
            TreeNode right = LowestCommonAncestor1(root.right, p, q);
            if (left != null && right != null)
            {
                return root;
            }
            else if (left != null)
            {
                return left;
            }
            else if (right != null)
            {
                return right;
            }
            return null;
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
