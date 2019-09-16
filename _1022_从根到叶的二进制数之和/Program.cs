using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1022_从根到叶的二进制数之和
{
    /*
        给出一棵二叉树，其上每个结点的值都是 0 或 1 。每一条从根到叶的路径都代表一个从最高有效位开始的二进制数。例如，如果路径为 0 -> 1 -> 1 -> 0 -> 1，那么它表示二进制数 01101，也就是 13 。
    对树上的每一片叶子，我们都要找出从根到该叶子的路径所表示的数字。
    以 10^9 + 7 为模，返回这些数字之和。
    
    示例：

    输入：[1,0,1,0,1,0,1]
    输出：22
    解释：(100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
    
    提示：

        树中的结点数介于 1 和 1000 之间。
        node.val 为 0 或 1 。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sum-of-root-to-leaf-binary-numbers
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int SumRootToLeaf(TreeNode root)
        {
            List<int> list = new List<int>();
            Assist(root, 0, list);
            return list.Sum();
        }

        public void Assist(TreeNode node,int tempSum,List<int> list)
        {
            if (node == null)
            {
                list.Add(0);
            }

            int temp = (tempSum << 1) + node.val;
            if (node.left==null && node.right==null )//当前节点是叶子
            {
                list.Add(temp);
            }
            else if(node.left==null)//左子树为空 右子树不为空
            {
                Assist(node.right, temp, list);
            }
            else if(node.right==null)//右子树为空 左子树不为空
            {
                Assist(node.left, temp, list);
            }
            else//左右子树都不为空
            {
                Assist(node.right, temp, list);
                Assist(node.left, temp, list);
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
