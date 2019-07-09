using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _700_二叉搜索树中的搜索
{
    /*
    给定二叉搜索树（BST）的根节点和一个值。 你需要在BST中找到节点值等于给定值的节点。 返回以该节点为根的子树。 如果节点不存在，则返回 NULL。

    例如，

    给定二叉搜索树:

            4
           / \
          2   7
         / \
        1   3

    和值: 2

    你应该返回如下子树:

          2     
         / \   
        1   3

    在上述示例中，如果要找的值是 5，但因为没有节点值为 5，我们应该返回 NULL。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/search-in-a-binary-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if(root==null)
            {
                return null;
            }

            if(root.val==val)//当前节点的值等于给定值
            {
                return root;
            }
            else
            {
                TreeNode leftSearch = SearchBST(root.left, val);
                if (leftSearch != null)
                {
                    return leftSearch;
                }
                else
                {
                    return SearchBST(root.right, val);
                }               
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
