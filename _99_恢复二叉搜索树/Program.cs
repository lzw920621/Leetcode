using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99_恢复二叉搜索树
{
    /*
    二叉搜索树中的两个节点被错误地交换。
    请在不改变其结构的情况下，恢复这棵树。

    示例 1:

    输入: [1,3,null,null,2]

       1
      /
     3
      \
       2

    输出: [3,1,null,null,2]

       3
      /
     1
      \
       2

    示例 2:

    输入: [3,1,4,null,null,2]

      3
     / \
    1   4
       /
      2

    输出: [2,1,4,null,null,3]

      2
     / \
    1   4
       /
      3

    进阶:
        使用 O(n) 空间复杂度的解法很容易实现。
        你能想出一个只使用常数空间的解决方案吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/recover-binary-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        //方法1
        public void RecoverTree(TreeNode root)
        {
            if (root == null) return;
            List<TreeNode> list = new List<TreeNode>();
            InOrder(root, list);
            Partition(list, 0, list.Count - 1);
        }

        public static void InOrder(TreeNode root,List<TreeNode> list)
        {
            if (root == null) return;
            InOrder(root.left, list);
            list.Add(root);
            InOrder(root.right, list);
        }

        static void Partition(List<TreeNode> list, int left, int right)
        {
            if (left >= right) return;

            int pivot = list[left].val;
            int l = left, r = right;
            while (l < r)
            {
                while (l < r && list[r].val >= pivot)
                {
                    r--;
                }
                list[l].val = list[r].val;
                while (l < r && list[l].val <= pivot)
                {
                    l++;
                }
                list[r].val = list[l].val;
            }
            list[l].val = pivot;

            Partition(list, left, l - 1);
            Partition(list, l + 1, right);
        }

        //方法2
        public void RecoverTree1(TreeNode root)
        {
            //TODO 有bug
            if (root == null) return;
            TreeNode node1 = null;
            TreeNode node2 = null;
            TreeNode preNode = null;

            InOrder1(root, preNode, node1, node2);
            //交换node1和node2的值
            int temp = node1.val;
            node1.val = node2.val;
            node2.val = temp;
        }

        public static void InOrder1(TreeNode root, TreeNode preNode, TreeNode node1,TreeNode node2)
        {
            if (root == null) return;
            InOrder1(root.left, preNode, node1, node2);
            if(preNode!=null)
            {
                if(preNode.val>root.val)//位置错误的节点
                {
                    if(node1==null)
                    {
                        node1 = preNode;
                    }
                    else
                    {
                        node2 = preNode;
                    }
                }
            }
            preNode = root;
            InOrder1(root.right, preNode, node1, node2);
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
