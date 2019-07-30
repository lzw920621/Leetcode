using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _872_叶子相似的树
{
    /*
    请考虑一颗二叉树上所有的叶子，这些叶子的值按从左到右的顺序排列形成一个 叶值序列 。

    举个例子，如上图所示，给定一颗叶值序列为 (6, 7, 4, 9, 8) 的树。

    如果有两颗二叉树的叶值序列是相同，那么我们就认为它们是 叶相似 的。

    如果给定的两个头结点分别为 root1 和 root2 的树是叶相似的，则返回 true；否则返回 false 。

 

    提示：

        给定的两颗树可能会有 1 到 100 个结点。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/leaf-similar-trees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            GetLeafValues(root1, list1);
            GetLeafValues(root2, list2);
            return list1.SequenceEqual(list2);
        }

        public static void GetLeafValues(TreeNode root,List<int> list)
        {
            if (root == null) return;
            if(root.left==null && root.right==null)//左右节点为空 则该节点是叶子节点
            {
                list.Add(root.val);
            }
            else
            {
                GetLeafValues(root.left, list);
                GetLeafValues(root.right, list);
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
