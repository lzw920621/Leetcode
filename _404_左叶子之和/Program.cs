﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _404_左叶子之和
{
    /*
    计算给定二叉树的所有左叶子之和。

    示例：

        3
       / \
      9  20
        /  \
       15   7

    在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sum-of-left-leaves
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            if(root.left!=null)
            {
                if(root.left.left==null && root.left.right==null)//该左节点是叶子节点
                {
                    return root.left.val + SumOfLeftLeaves(root.right);
                }
                else
                {
                    return SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
                }
            }
            else
            {
                return SumOfLeftLeaves(root.right);
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
