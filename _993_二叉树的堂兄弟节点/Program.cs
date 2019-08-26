using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _993_二叉树的堂兄弟节点
{
    /*
    在二叉树中，根节点位于深度 0 处，每个深度为 k 的节点的子节点位于深度 k+1 处。
    如果二叉树的两个节点深度相同，但父节点不同，则它们是一对堂兄弟节点。
    我们给出了具有唯一值的二叉树的根节点 root，以及树中两个不同节点的值 x 和 y。
    只有与值 x 和 y 对应的节点是堂兄弟节点时，才返回 true。否则，返回 false。
    
    示例 1：
    输入：root = [1,2,3,4], x = 4, y = 3
    输出：false

    示例 2：
    输入：root = [1,2,3,null,4,null,5], x = 5, y = 4
    输出：true

    示例 3：
    输入：root = [1,2,3,null,4], x = 2, y = 3
    输出：false
    
    提示：

        二叉树的节点数介于 2 到 100 之间。
        每个节点的值都是唯一的、范围为 1 到 100 的整数。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/cousins-in-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool IsCousins(TreeNode root, int x, int y)
        {
            Tuple<int, TreeNode> tupleX = Assist(root, x, 0, null);
            Tuple<int, TreeNode> tupleY = Assist(root, y, 0, null);
            if(tupleX.Item1==tupleY.Item1 && tupleX.Item2!=tupleY.Item2)
            {
                return true;
            }
            return false;
        }
        public Tuple<int,TreeNode> Assist(TreeNode root,int target,int depth,TreeNode father)
        {
            if (root == null) return new Tuple<int, TreeNode>(-1, null);
            if(root.val==target)
            {
                return new Tuple<int, TreeNode>(depth, father);
            }
            Tuple<int, TreeNode> tuple = Assist(root.left, target, depth + 1,root);
            if(tuple.Item1 != -1)
            {
                return tuple;                
            }
            else
            {
                return Assist(root.right, target, depth + 1,root);
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
