using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _199_二叉树的右视图
{
    /*
        给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
    示例:

    输入: [1,2,3,null,5,null,4]
    输出: [1, 3, 4]
    解释:

       1            <---
     /   \
    2     3         <---
     \     \
      5     4       <---

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-right-side-view
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;

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
                    if(i==0)
                    {
                        list.Add(tempNode.val);
                    }
                    if(tempNode.right!=null)
                    {
                        queue.Enqueue(tempNode.right);
                    }
                    if(tempNode.left!=null)
                    {
                        queue.Enqueue(tempNode.left);
                    }
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
