﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _617_合并二叉树
{
    /*
    给定两个二叉树，想象当你将它们中的一个覆盖到另一个上时，两个二叉树的一些节点便会重叠。

    你需要将他们合并为一个新的二叉树。合并的规则是如果两个节点重叠，那么将他们的值相加作为节点合并后的新值，否则不为 NULL 的节点将直接作为新二叉树的节点。

    示例 1:

    输入: 
	    Tree 1                     Tree 2                  
              1                         2                             
             / \                       / \                            
            3   2                     1   3                        
           /                           \   \                      
          5                             4   7                  
    输出: 
    合并后的树:
	         3
	        / \
	       4   5
	      / \   \ 
	     5   4   7

    注意: 合并必须从两个树的根节点开始。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/merge-two-binary-trees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {

        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            
            if (t1 != null && t2 != null)
            {
                t1.val = t1.val + t2.val;
                t1.left = MergeTrees(t1.left, t2.left);
                t1.right = MergeTrees(t1.right, t2.right);
                return t1;
            }
            else if (t1 != null)
            {
                return t1;
            }
            else if (t2 != null)
            {

                return t2;
            }
            else
            {
                return null;
            }
        }

        public TreeNode MergeTrees1(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }
            t1.val = t1.val + t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
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
