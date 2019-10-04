using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1026_节点与其祖先之间的最大差值
{
    /*
        给定二叉树的根节点 root，找出存在于不同节点 A 和 B 之间的最大值 V，其中 V = |A.val - B.val|，且 A 是 B 的祖先。
    （如果 A 的任何子节点之一为 B，或者 A 的任何子节点是 B 的祖先，那么我们认为 A 是 B 的祖先）
    
    示例：

    输入：[8,3,10,1,6,null,14,null,null,4,7,13]
    输出：7
    解释： 
    我们有大量的节点与其祖先的差值，其中一些如下：
    |8 - 3| = 5
    |3 - 7| = 4
    |8 - 1| = 7
    |10 - 13| = 3
    在所有可能的差值中，最大值 7 由 |8 - 1| = 7 得出。

 

    提示：

        树中的节点数在 2 到 5000 之间。
        每个节点的值介于 0 到 100000 之间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-difference-between-node-and-ancestor
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int MaxAncestorDiff(TreeNode root)
        {
            if (root == null) return 0;
            int max = 0;
            if(root.left!=null)
            {
                Tuple<int, int> tupleLeft = GetMaxMin(root.left);
                max = Math.Max(max, Math.Abs(root.val - tupleLeft.Item1));
                max = Math.Max(max, Math.Abs(root.val - tupleLeft.Item2));
            }
            if(root.right!=null)
            {
                Tuple<int, int> tupleRight = GetMaxMin(root.right);
                max = Math.Max(max, Math.Abs(root.val - tupleRight.Item1));
                max = Math.Max(max, Math.Abs(root.val - tupleRight.Item2));
            }
            max = Math.Max(max, Math.Max(MaxAncestorDiff(root.left), MaxAncestorDiff(root.right)));
            return max;
        }

        Tuple<int,int> GetMaxMin(TreeNode root)
        {
            if (root == null) return null;
            int max = root.val;
            int min = root.val;
            if(root.left!=null)
            {
                Tuple<int, int> tupleLeft = GetMaxMin(root.left);
                max = Math.Max(max, tupleLeft.Item1);
                min = Math.Min(min, tupleLeft.Item2);
            }
            if(root.right!=null)
            {
                Tuple<int, int> tupleRight = GetMaxMin(root.right);
                max = Math.Max(max, tupleRight.Item1);
                min = Math.Min(min, tupleRight.Item2);
            }
            return new Tuple<int, int>(max, min);
        }




        int diff = 0;
        public int MaxAncestorDiff2(TreeNode root)
        {
            Helper(root, root.val, root.val);
            return diff;
        }
        /*
        每条从根节点到叶子节点的路径中的最大值和最小值，并求出差值更新全局变量
        */
        public void Helper(TreeNode root, int max, int min)
        {
            if (root == null) return;
            max = max > root.val ? max : root.val;
            min = min < root.val ? min : root.val;
            //到达叶子节点，求最大差值
            if (root.left == null && root.right == null)
            {
                diff = diff > max - min ? diff : max - min;
                return;
            }
                
            Helper(root.left, max, min);
            Helper(root.right, max, min);
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
