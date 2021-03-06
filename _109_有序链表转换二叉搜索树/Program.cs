﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _109_有序链表转换二叉搜索树
{
    /*
    给定一个单链表，其中的元素按升序排序，将其转换为高度平衡的二叉搜索树。
    本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。

    示例:

    给定的有序链表： [-10, -3, 0, 5, 9],

    一个可能的答案是：[0, -3, 9, -10, null, 5], 它可以表示下面这个高度平衡二叉搜索树：

          0
         / \
       -3   9
       /   /
     -10  5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/convert-sorted-list-to-binary-search-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            List<int> list = new List<int>();
            while(head!=null)
            {
                list.Add(head.val);
                head = head.next;
            }
            return ListToTree(list, 0, list.Count - 1);
        }

        public static TreeNode ListToTree(List<int> list,int left,int right)
        {
            if (left > right) return null;
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(list[mid]);
            root.left = ListToTree(list, left, mid - 1);
            root.right = ListToTree(list, mid + 1, right);
            return root;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
