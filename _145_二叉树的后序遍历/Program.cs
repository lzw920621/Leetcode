﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _145_二叉树的后序遍历
{
    /*
    给定一个二叉树，返回它的 后序 遍历。

    示例:

    输入: [1,null,2,3]  
       1
        \
         2
        /
       3 

    输出: [3,2,1]

    进阶: 递归算法很简单，你可以通过迭代算法完成吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-tree-postorder-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            //TODO
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            PostOrder(root, list);
            return list;
        }
        public static void PostOrder(TreeNode root, IList<int> list)
        {
            if (root == null) return;
            PostOrder(root.left, list);
            PostOrder(root.right, list);
            list.Add(root.val);
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
