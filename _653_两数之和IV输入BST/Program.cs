using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _653_两数之和IV输入BST
{
    /*
    给定一个二叉搜索树和一个目标结果，如果 BST 中存在两个元素且它们的和等于给定的目标结果，则返回 true。

    案例 1:
    输入: 
        5
       / \
      3   6
     / \   \
    2   4   7

    Target = 9

    输出: True
    
    案例 2:

    输入: 
        5
       / \
      3   6
     / \   \
    2   4   7

    Target = 28

    输出: False

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/two-sum-iv-input-is-a-bst
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。 
    */
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;
            HashSet<int> set = new HashSet<int>();
            InOrder(root, set);
            foreach (var item in set)
            {
                if(set.Contains(k-item) && item!=k-item)
                {
                    return true;
                }
            }
            return false;
        }

        public static void InOrder(TreeNode root,HashSet<int> set)
        {
            if (root == null) return;
            InOrder(root.left, set);
            set.Add(root.val);
            InOrder(root.right, set);
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
