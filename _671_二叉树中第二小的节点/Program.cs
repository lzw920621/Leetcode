﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _671_二叉树中第二小的节点
{
    /*
    给定一个非空特殊的二叉树，每个节点都是正数，并且每个节点的子节点数量只能为 2 或 0。如果一个节点有两个子节点的话，那么这个节点的值不大于它的子节点的值。 

    给出这样的一个二叉树，你需要输出所有节点中的第二小的值。如果第二小的值不存在的话，输出 -1 。

    示例 1:

    输入: 
        2
       / \
      2   5
         / \
        5   7

    输出: 5
    说明: 最小的值是 2 ，第二小的值是 5 。

    示例 2:

    输入: 
        2
       / \
      2   2

    输出: -1
    说明: 最小的值是 2, 但是不存在第二小的值。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/second-minimum-node-in-a-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static  int FindSecondMinimumValue(TreeNode root)
        {
            int num = FindSecondMinimumValue(root, root.val);
            return num > root.val ? num : -1;
        }

        public static int FindSecondMinimumValue(TreeNode root,int smallestVal)//寻找最小的大于 smallestVal的数
        {
            if (root.left == null) return root.val;
            int leftSecondMin = FindSecondMinimumValue(root.left, smallestVal);
            int rightSeconMin = FindSecondMinimumValue(root.right, smallestVal);
            if(leftSecondMin>rightSeconMin)
            {
                if(rightSeconMin>smallestVal)
                {
                    return rightSeconMin;
                }
                else
                {
                    return leftSecondMin;
                }
            }
            else if(rightSeconMin>leftSecondMin)
            {
                if(leftSecondMin>smallestVal)
                {
                    return leftSecondMin;
                }
                else
                {
                    return rightSeconMin;
                }
            }
            else
            {
                return leftSecondMin;
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
