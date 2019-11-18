using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _894_所有可能的满二叉树
{
    /*
        满二叉树是一类二叉树，其中每个结点恰好有 0 或 2 个子结点。

    返回包含 N 个结点的所有可能满二叉树的列表。 答案的每个元素都是一个可能树的根结点。

    答案中每个树的每个结点都必须有 node.val=0。

    你可以按任何顺序返回树的最终列表。

 

    示例：

    输入：7
    输出：[[0,0,0,null,null,0,0,null,null,0,0],[0,0,0,null,null,0,0,0,0],[0,0,0,0,0,0,0],[0,0,0,0,0,null,null,null,null,0,0],[0,0,0,0,0,null,null,0,0]]
    解释：

 

    提示：

        1 <= N <= 20

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/all-possible-full-binary-trees
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        public IList<TreeNode> AllPossibleFBT(int N)
        {          
            IList<TreeNode> list = new List<TreeNode>();
            
            if(N==1)
            {
                list.Add(new TreeNode(0));
                return list;
            }
            
            for (int i = 1; i < N; i+=2)
            {
                IList<TreeNode> leftNodes = AllPossibleFBT(i);
                IList<TreeNode> rightNodes = AllPossibleFBT(N-1-i);
                for (int l = 0; l < leftNodes.Count; l++)
                {
                    for (int r = 0; r < rightNodes.Count; r++)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = leftNodes[l];
                        root.right = rightNodes[r];
                        list.Add(root);
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
