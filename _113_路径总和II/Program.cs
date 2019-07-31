using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _113_路径总和II
{
    /*
    给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。
    说明: 叶子节点是指没有子节点的节点。

    示例:
    给定如下二叉树，以及目标和 sum = 22，

                  5
                 / \
                4   8
               /   / \
              11  13  4
             /  \    / \
            7    2  5   1
    返回:

    [
       [5,4,11,2],
       [5,8,4,5]
    ]

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/path-sum-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> list = new List<IList<int>>();
            PreOrder(root, sum, 0, new List<int>(), list);
            return list;
        }
        public static void PreOrder(TreeNode root, int targetSum, int tempSum,List<int> tempList,IList<IList<int>> list)
        {
            if (root == null)
            {
                return;
            }
            tempSum = tempSum + root.val;
            tempList.Add(root.val);
            if (root.left==null && root.right==null && tempSum == targetSum)//当前节点是叶子节点 且路径和等于目标值
            {
                list.Add(tempList);
                return;
            }
            
            if(root.left!=null)
            {
                List<int> tempListClone = ListClone(tempList);
                PreOrder(root.left, targetSum, tempSum, tempListClone, list);
            }
            if(root.right!=null)
            {
                List<int> tempListClone = ListClone(tempList);
                PreOrder(root.right, targetSum, tempSum, tempListClone, list);
            }                    
        }
        public static List<int> ListClone(List<int> list)
        {
            List<int> newList = new List<int>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
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
