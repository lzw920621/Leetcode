using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _662_二叉树的最大宽度
{
    /*
        给定一个二叉树，编写一个函数来获取这个树的最大宽度。树的宽度是所有层中的最大宽度。这个二叉树与满二叉树（full binary tree）结构相同，
    但一些节点为空。每一层的宽度被定义为两个端点（该层最左和最右的非空节点，两端点间的null节点也计入长度）之间的长度。
    示例 1:

    输入: 
               1
             /   \
            3     2
           / \     \  
          5   3     9 

    输出: 4
    解释: 最大值出现在树的第 3 层，宽度为 4 (5,3,null,9)。

    示例 2:

    输入: 
              1
             /  
            3    
           / \       
          5   3     

    输出: 2
    解释: 最大值出现在树的第 3 层，宽度为 2 (5,3)。

    示例 3:

    输入: 
              1
             / \
            3   2 
           /        
          5      

    输出: 2
    解释: 最大值出现在树的第 2 层，宽度为 2 (3,2)。

    示例 4:

    输入: 
              1
             / \
            3   2
           /     \  
          5       9 
         /         \
        6           7
    输出: 8
    解释: 最大值出现在树的第 4 层，宽度为 8 (6,null,null,null,null,null,null,7)。

    注意: 答案在32位有符号整数的表示范围内。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-width-of-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(1);
            root.left.left = new TreeNode(1);
            root.left.left.left = new TreeNode(1);
            root.right = new TreeNode(1);
            root.right.right = new TreeNode(1);
            root.right.right.right = new TreeNode(1);
            int width = new Program().WidthOfBinaryTree(root);
        }

        Dictionary<int, int> dicLeft = new Dictionary<int, int>();
        Dictionary<int, int> dicRight = new Dictionary<int, int>();

        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Assist(root, 0, 1);
            int width = 0;
            foreach (var key in dicLeft.Keys)
            {
                width = Math.Max(dicRight[key] - dicLeft[key] + 1, width);
            }
            return width;
        }

        void Assist(TreeNode root,int offset,int level)
        {
            if (root == null) return;
            dicLeft[level] = dicLeft.ContainsKey(level) ? Math.Min(dicLeft[level], offset) : offset;
            dicRight[level] = dicRight.ContainsKey(level) ? Math.Max(dicRight[level], offset) : offset;
            Assist(root.left, 2*offset + 1, level + 1);
            Assist(root.right, 2*offset + 2, level + 1);
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
