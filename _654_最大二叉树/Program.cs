﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _654_最大二叉树
{
    /*
    给定一个不含重复元素的整数数组。一个以此数组构建的最大二叉树定义如下：
    二叉树的根是数组中的最大元素。
    左子树是通过数组中最大值左边部分构造出的最大二叉树。
    右子树是通过数组中最大值右边部分构造出的最大二叉树。

    通过给定的数组构建最大二叉树，并且输出这个树的根节点。
    
    示例 ：

    输入：[3,2,1,6,0,5]
    输出：返回下面这棵树的根节点：

          6
        /   \
       3     5
        \    / 
         2  0   
           \
            1

    提示：

        给定的数组的大小在 [1, 1000] 之间。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = ConstructMaximumBinaryTree(new int[] { 3, 2, 1, 6, 0, 5 });
        }

        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Assist(nums, 0, nums.Length - 1);
        }

        public static TreeNode Assist(int[] nums,int left,int right)
        {
            if (left > right) return null;
            int index = left;
            for (int i = left; i <= right; i++)//寻找最大值的索引
            {
                if(nums[i]> nums[index])
                {
                    index = i;
                }
            }
            TreeNode root = new TreeNode(nums[index]);
            root.left = Assist(nums, left, index - 1);
            root.right = Assist(nums, index + 1, right);
            return root;
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
