﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _998_最大二叉树II
{
    /*
    最大树定义：一个树，其中每个节点的值都大于其子树中的任何其他值。
    给出最大树的根节点 root。

    就像之前的问题那样，给定的树是从表 A（root = Construct(A)）递归地使用下述 Construct(A) 例程构造的：

        如果 A 为空，返回 null
        否则，令 A[i] 作为 A 的最大元素。创建一个值为 A[i] 的根节点 root
        root 的左子树将被构建为 Construct([A[0], A[1], ..., A[i-1]])
        root 的右子树将被构建为 Construct([A[i+1], A[i+2], ..., A[A.length - 1]])
        返回 root

    请注意，我们没有直接给定 A，只有一个根节点 root = Construct(A).

    假设 B 是 A 的副本，并附加值 val。保证 B 中的值是不同的。

    返回 Construct(B)。

 

    示例 1：

    输入：root = [4,1,3,null,null,2], val = 5
    输出：[5,4,null,1,3,null,null,2]
    解释：A = [1,4,2,3], B = [1,4,2,3,5]

    示例 2：

    输入：root = [5,2,4,null,1], val = 3
    输出：[5,2,4,null,1,null,3]
    解释：A = [2,1,5,4], B = [2,1,5,4,3]

    示例 3：

    输入：root = [5,2,3,null,1], val = 4
    输出：[5,2,4,null,1,3]
    解释：A = [2,1,5,3], B = [2,1,5,3,4]

 

    提示：

        1 <= B.length <= 100

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-binary-tree-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        //主要理解题意，如果val > root.Val, 直接使之成为根，反之，插入到右子树中
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            if(val>=root.val)
            {
                TreeNode newRoot = new TreeNode(val);
                newRoot.left = root;
                return newRoot;
            }
            else
            {
                root.right = InsertIntoMaxTree(root.right, val);
            }
            
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
