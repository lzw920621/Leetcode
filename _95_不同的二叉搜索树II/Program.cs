using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _95_不同的二叉搜索树II
{
    /*
        给定一个整数 n，生成所有由 1 ... n 为节点所组成的二叉搜索树。

    示例:
    输入: 3
    输出:
    [
      [1,null,3,2],
      [3,2,null,1],
      [3,1,null,null,2],
      [2,1,3],
      [1,null,2,null,3]
    ]
    解释:
    以上的输出对应以下 5 种不同结构的二叉搜索树：

       1         3     3      2      1
        \       /     /      / \      \
         3     2     1      1   3      2
        /     /       \                 \
       2     1         2                 3

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/unique-binary-search-trees-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            return AssistGenerateTrees(1, n);
        }

        static IList<TreeNode> AssistGenerateTrees(int left,int right)
        {            
            IList<TreeNode> list = new List<TreeNode>();
            if (left > right)
            {
                return list;
            }
            if (left == right)
            {
                TreeNode tempNode = new TreeNode(left);
                list.Add(tempNode);
                return list;
            }
            
            for (int i = left; i <= right; i++)
            {                
                IList<TreeNode> leftNodes = AssistGenerateTrees(left, i - 1);
                IList<TreeNode> rightNodes = AssistGenerateTrees(i + 1, right);
                
                if(leftNodes.Count>0 && rightNodes.Count>0)
                {
                    for (int j = 0; j < leftNodes.Count; j++)
                    {
                        for (int k = 0; k < rightNodes.Count; k++)
                        {
                            TreeNode tempNode = new TreeNode(i);
                            tempNode.left = leftNodes[j];
                            tempNode.right = rightNodes[k];
                            list.Add(tempNode);
                        }
                    }
                }
                else if(leftNodes.Count>0)
                {
                    for (int j = 0; j < leftNodes.Count; j++)
                    {
                        TreeNode tempNode = new TreeNode(i);
                        tempNode.left = leftNodes[j];
                        list.Add(tempNode);
                    }
                }
                else if(rightNodes.Count>0)
                {
                    for (int j = 0; j < rightNodes.Count; j++)
                    {
                        TreeNode tempNode = new TreeNode(i);
                        tempNode.right = rightNodes[j];
                        list.Add(tempNode);
                    }
                }               
            }
            return list;
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
