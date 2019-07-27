using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _108_将有序数组转换为二叉搜索树
{
    /*
    将一个按照升序排列的有序数组，转换为一棵高度平衡二叉搜索树。

    本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

    示例:

    给定有序数组: [-10,-3,0,5,9],

    一个可能的答案是：[0,-3,9,-10,null,5]，它可以表示下面这个高度平衡二叉搜索树：

          0
         / \
       -3   9
       /   /
     -10  5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/convert-sorted-array-to-binary-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return ArrayToBinaryTree(nums, 0, nums.Length - 1);
        }

        public static TreeNode ArrayToBinaryTree(int[] array, int low, int high)//将数组转为二叉树
        {
            if (low > high) return null;
            int mid = (low + high) / 2;
            TreeNode treeNode = new TreeNode(array[mid]);
            treeNode.left = ArrayToBinaryTree(array, low, mid - 1);
            treeNode.right = ArrayToBinaryTree(array, mid + 1, high);
            return treeNode;
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
