using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1302_层数最深叶子节点的和
{
    /*
    给你一棵二叉树，请你返回层数最深的叶子节点的和。
    

    示例：

    输入：root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
    输出：15

 

    提示：

        树中节点数目在 1 到 10^4 之间。
        每个节点的值在 1 到 100 之间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/deepest-leaves-sum
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(6);

            int sum = new Program().DeepestLeavesSum(root);

        }

        public int DeepestLeavesSum(TreeNode root)
        {
            if (root == null) return 0;
            List<int> list = new List<int>();
            list.Add(0);
            Helper(root, 0, list);
            return list[list.Count - 1];
        }

        void Helper(TreeNode root, int level, List<int> list)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                list[level] += root.val;
            }
            else
            {
                level++;
                if (level >= list.Count)
                {
                    list.Add(0);
                }

                Helper(root.left, level, list);
                Helper(root.right, level, list);
            }
        }




        int sum = 0;
        int deepest = 1;
        public int DeepestLeavesSum2(TreeNode root)
        {
            if (root == null) return 0;
            Helper2(root, 1);
            return sum;
        }
        void Helper2(TreeNode root, int currentLevel)
        {
            if (root == null) return;

            if(currentLevel==deepest)
            {
                sum += root.val;
            }
            if(currentLevel>deepest)
            {
                sum = 0;
                deepest = currentLevel;
                sum += root.val;
            }
            Helper2(root.left, currentLevel + 1);
            Helper2(root.right, currentLevel + 1);
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
