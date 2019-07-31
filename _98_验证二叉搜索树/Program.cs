using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98_验证二叉搜索树
{
    /*
    给定一个二叉树，判断其是否是一个有效的二叉搜索树。

    假设一个二叉搜索树具有如下特征：

        节点的左子树只包含小于当前节点的数。
        节点的右子树只包含大于当前节点的数。
        所有左子树和右子树自身必须也是二叉搜索树。

    示例 1:

    输入:
        2
       / \
      1   3
    输出: true

    示例 2:

    输入:
        5
       / \
      1   4
         / \
        3   6
    输出: false
    解释: 输入为: [5,1,4,null,null,3,6]。
         根节点的值为 5 ，但是其右子节点值为 4 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/validate-binary-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;
            List<int> list = new List<int>();
            InOrder(root, list);
            for (int i = 1; i < list.Count; i++)
            {
                if(list[i-1]>=list[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void InOrder(TreeNode root,List<int> list)
        {
            if (root == null) return;
            InOrder(root.left, list);
            list.Add(root.val);
            InOrder(root.right, list);
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
