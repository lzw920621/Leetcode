using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _897_递增顺序查找树
{
    /*
    给定一个树，按中序遍历重新排列树，使树中最左边的结点现在是树的根，并且每个结点没有左子结点，只有一个右子结点。
    
    示例 ：

    输入：[5,3,6,2,4,null,8,1,null,null,null,7,9]

           5
          / \
        3    6
       / \    \
      2   4    8
     /        / \ 
    1        7   9

    输出：[1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]

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
                \
                 7
                  \
                   8
                    \
                     9  
    提示：

        给定树中的结点数介于 1 和 100 之间。
        每个结点都有一个从 0 到 1000 范围内的唯一整数值。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/increasing-order-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(379);
            root.left = new TreeNode(826);
            TreeNode newRoot = IncreasingBST(root);
        }

        public static TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null) return null;
            List<TreeNode> list = new List<TreeNode>();
            InOrder(root, list);
            TreeNode newRoot = list[0];
            TreeNode current = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                current.right = list[i];
                current.left = null;
                current = list[i];
            }
            current.left = null;//这步很重要
            return newRoot;
        }

        public static void InOrder(TreeNode root,List<TreeNode> list)//中序遍历 将节点添加到list中
        {
            if (root == null) return;
            InOrder(root.left,list);
            list.Add(root);
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
