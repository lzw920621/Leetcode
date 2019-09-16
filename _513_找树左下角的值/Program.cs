using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _513_找树左下角的值
{
    /*
        给定一个二叉树，在树的最后一行找到最左边的值。

    示例 1:

    输入:

        2
       / \
      1   3

    输出:
    1

 

    示例 2:

    输入:

            1
           / \
          2   3
         /   / \
        4   5   6
           /
          7

    输出:
    7

 

    注意: 您可以假设树（即给定的根节点）不为 NULL。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-bottom-left-tree-value
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int FindBottomLeftValue(TreeNode root)
        {
            return LevelOrder(root);
        }

        int LevelOrder(TreeNode root)//层序遍历找到最下层左边的节点(每一层从右往左遍历)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();

            TreeNode tempNode = root;
            int tempCount;
            queue.Enqueue(root);
            while(queue.Count>0)
            {                
                tempCount = queue.Count;
                for (int i = 0; i < tempCount; i++)
                {
                    tempNode = queue.Dequeue();
                    if (tempNode.right != null) queue.Enqueue(tempNode.right);
                    if (tempNode.left != null) queue.Enqueue(tempNode.left);                   
                }
            }
            return tempNode.val;
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
