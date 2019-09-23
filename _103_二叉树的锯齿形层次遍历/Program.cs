using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _103_二叉树的锯齿形层次遍历
{
    /*
        给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
    例如：
    给定二叉树 [3,9,20,null,null,15,7],

        3
       / \
      9  20
        /  \
       15   7

    返回锯齿形层次遍历如下：

    [
      [3],
      [20,9],
      [15,7]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null) return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            bool leftToRight = false;
            int tempCount;
            TreeNode tempNode;
            IList<int> tempList; 
            queue.Enqueue(root);
            while(queue.Count>0)
            {
                leftToRight = !leftToRight;

                tempList = new List<int>();
                tempCount = queue.Count;
                for (int i = 0; i < tempCount; i++)
                {
                    tempNode = queue.Dequeue();
                    tempList.Add(tempNode.val);
                    if (tempNode.left != null)
                    {
                        queue.Enqueue(tempNode.left);
                    }
                    if (tempNode.right != null)
                    {
                        queue.Enqueue(tempNode.right);
                    }
                }
                if(leftToRight==true)
                {
                    list.Add(tempList);
                }
                else
                {
                    list.Add(tempList.Reverse().ToList());
                }
            }
            return list;
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
