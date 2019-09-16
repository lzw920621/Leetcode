using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _515_在每个树行中找最大值
{
    /*
        您需要在二叉树的每一行中找到最大的值。

    示例：

    输入: 

              1
             / \
            3   2
           / \   \  
          5   3   9 

    输出: [1, 3, 9]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-largest-value-in-each-tree-row
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<int> LargestValues(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null) return list;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode tempNode;
            int tempCount;
            int maxValue;
            queue.Enqueue(root);
            while(queue.Count>0)
            {
                tempCount = queue.Count;
                maxValue = int.MinValue;
                for (int i = 0; i < tempCount; i++)
                {
                    tempNode = queue.Dequeue();
                    maxValue = Math.Max(maxValue, tempNode.val);
                    if(tempNode.left!=null)
                    {
                        queue.Enqueue(tempNode.left);
                    }
                    if(tempNode.right!=null)
                    {
                        queue.Enqueue(tempNode.right);
                    }
                }
                list.Add(maxValue);
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
