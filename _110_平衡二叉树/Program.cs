﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _110_平衡二叉树
{
    /*
    给定一个二叉树，判断它是否是高度平衡的二叉树。

    本题中，一棵高度平衡二叉树定义为：

        一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过1。

    示例 1:

    给定二叉树 [3,9,20,null,null,15,7]

        3
       / \
      9  20
        /  \
       15   7

    返回 true 。

    示例 2:

    给定二叉树 [1,2,2,3,3,null,null,4,4]

           1
          / \
         2   2
        / \
       3   3
      / \
     4   4

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/balanced-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool IsBalanced(TreeNode root)
        {
            Tuple<bool, int> result = IsBalanced_Assist(root);
            return result.Item1;
        }

        public static Tuple<bool,int> IsBalanced_Assist(TreeNode root)
        {
            if(root==null)
            {
                return new Tuple<bool, int>(true, 0);
            }
            Tuple<bool, int> resultLeft = IsBalanced_Assist(root.left);
            Tuple<bool, int> resultRight = IsBalanced_Assist(root.right);

            int diff = Math.Abs(resultLeft.Item2 - resultRight.Item2);//左右子树高度差
            int height = Math.Max(resultLeft.Item2, resultRight.Item2) + 1;

            if (resultLeft.Item1 && resultRight.Item1)//左右子树 都为 平衡二叉树
            {                
                if (diff>1)//高度差大于1
                {
                    return new Tuple<bool, int>(false, height);
                }
                else
                {                    
                    return new Tuple<bool, int>(true, height);
                }               
            }
            else//左右不平衡
            {
                return new Tuple<bool, int>(false, height);
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
