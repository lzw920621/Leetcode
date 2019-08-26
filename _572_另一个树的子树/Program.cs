using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _572_另一个树的子树
{
    /*
    给定两个非空二叉树 s 和 t，检验 s 中是否包含和 t 具有相同结构和节点值的子树。
    s 的一个子树包括 s 的一个节点和这个节点的所有子孙。
    s 也可以看做它自身的一棵子树。

    示例 1:
    给定的树 s:
         3
        / \
       4   5
      / \
     1   2

    给定的树 t：
       4 
      / \
     1   2

    返回 true，因为 t 与 s 的一个子树拥有相同的结构和节点值。

    示例 2:
    给定的树 s：
         3
        / \
       4   5
      / \
     1   2
        /
       0

    给定的树 t：
       4
      / \
     1   2

    返回 false。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/subtree-of-another-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        //方法1
        public static bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (IsSameTree(s, t) == false )
            {
                if(s!=null)
                {
                    return IsSubtree(s.left, t) || IsSubtree(s.right, t);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null) return true;
            if ((s == null && t != null) || (s != null && t == null)) return false;
            if (s.val == t.val)
            {
                return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
            }
            else
            {
                return false;
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
