using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _637_二叉树的层平均值
{
    /*
    给定一个非空二叉树, 返回一个由每层节点平均值组成的数组.

    示例 1:
    输入:
        3
       / \
      9  20
        /  \
       15   7
    输出: [3, 14.5, 11]
    解释:
    第0层的平均值是 3,  第1层是 14.5, 第2层是 11. 因此返回 [3, 14.5, 11].

    注意：
        节点值的范围在32位有符号整数范围内。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/average-of-levels-in-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            IList<double> list = AverageOfLevels(root);
        }

        public static IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> list = new List<double>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode current;
            int levelCount;
            double sum = 0;
            while(queue.Count>0)
            {
                levelCount = queue.Count;//这一层当前的节点数
                sum = 0;//sum清零
                for (int i = 0; i < levelCount; i++)
                {
                    current = queue.Dequeue();
                    sum += current.val;//统计当前层 节点值的总和
                    if(current.left!=null)
                    {
                        queue.Enqueue(current.left);//添加左节点
                    }
                    if(current.right!=null)
                    {
                        queue.Enqueue(current.right);//添加右节点
                    }                    
                }
                list.Add(sum / levelCount);//将层平均值添加到list中
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
