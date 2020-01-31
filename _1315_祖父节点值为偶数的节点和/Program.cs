using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1315_祖父节点值为偶数的节点和
{
    /*
        给你一棵二叉树，请你返回满足以下条件的所有节点的值之和：
    该节点的祖父节点的值为偶数。（一个节点的祖父节点是指该节点的父节点的父节点。）
    如果不存在祖父节点值为偶数的节点，那么返回 0 。

 

    示例：

    输入：root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
    输出：18
    解释：图中红色节点的祖父节点的值为偶数，蓝色节点为这些红色节点的祖父节点。

 

    提示：

        树中节点的数目在 1 到 10^4 之间。
        每个节点的值在 1 到 100 之间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sum-of-nodes-with-even-valued-grandparent
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(6);
            root.left = new TreeNode(7);
            root.right = new TreeNode(8);
            root.left.left = new TreeNode(2);
            int sum = new Program().SumEvenGrandparent(root);
        }

        public int SumEvenGrandparent(TreeNode root)
        {
            if (root == null) return 0;
            int sum = 0;
            if (root.val % 2 == 0)
            {
                sum += SumChild(root.left) + SumChild(root.right);
            }
            sum += SumEvenGrandparent(root.left) + SumEvenGrandparent(root.right);

            return sum;
        }        

        int SumChild(TreeNode root)
        {
            if (root == null) return 0;
            int tempSum = 0;
            if(root.left!=null)
            {
                tempSum += root.left.val;
            }
            if(root.right!=null)
            {
                tempSum += root.right.val;
            }
            return tempSum;
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
