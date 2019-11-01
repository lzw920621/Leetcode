using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _652_寻找重复的子树
{
    /*
        给定一棵二叉树，返回所有重复的子树。对于同一类的重复子树，你只需要返回其中任意一棵的根结点即可。
    两棵树重复是指它们具有相同的结构以及相同的结点值。

    示例 1：

            1
           / \
          2   3
         /   / \
        4   2   4
           /
          4

    下面是两个重复的子树：

          2
         /
        4

    和

        4

    因此，你需要以列表的形式返回上述重复子树的根结点。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/find-duplicate-subtrees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(4);
            root.right = new TreeNode(3);
            root.right.left = new TreeNode(2);
            root.right.left.left = new TreeNode(4);
            root.right.right = new TreeNode(4);

            IList<TreeNode> list = new Program().FindDuplicateSubtrees(root);
        }

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            IList<TreeNode> list = new List<TreeNode>();
            if (root == null) return list;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            PreOrder(root, dic, list);
            return list;
        }
        
        string PreOrder(TreeNode root, Dictionary<string, int> dic, IList<TreeNode> list)
        {
            if (root == null) return "#";
            string temp= root.val.ToString() +',' +PreOrder(root.left,dic,list) + ','+PreOrder(root.right,dic,list); 
            if(!dic.ContainsKey(temp))
            {                
                dic[temp] = 1;
            }
            else
            {
                dic[temp]++;
                if(dic[temp]==2)
                {
                    list.Add(root);
                }
                
            }
            return temp;
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
