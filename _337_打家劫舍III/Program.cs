using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _337_打家劫舍III
{
    /*
    在上次打劫完一条街道之后和一圈房屋后，小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，
    我们称之为“根”。 除了“根”之外，每栋房子有且只有一个“父“房子与之相连。一番侦察之后，
    聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 如果两个直接相连的房子在同一天晚上被打劫，房屋将自动报警。
    计算在不触动警报的情况下，小偷一晚能够盗取的最高金额。

    示例 1:
    输入: [3,2,3,null,3,null,1]

         3
        / \
       2   3
        \   \ 
         3   1

    输出: 7 
    解释: 小偷一晚能够盗取的最高金额 = 3 + 3 + 1 = 7.

    示例 2:
    输入: [3,4,5,1,3,null,1]

         3
        / \
       4   5
      / \   \ 
     1   3   1

    输出: 9
    解释: 小偷一晚能够盗取的最高金额 = 4 + 5 = 9.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/house-robber-iii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        static Dictionary<TreeNode, int> dic = new Dictionary<TreeNode, int>();
        public static int Rob(TreeNode root)
        {        
            if(root==null) return 0;
            if (dic.ContainsKey(root)) return dic[root];
            if (root.left==null)
            {
                if(root.right==null)//root.left为空 root.right为空
                {
                    dic[root] = root.val;
                    return root.val;
                }
                else//root.left为空 root.right不为空
                {
                    int n1 = root.val + Rob(root.right.left) + Rob(root.right.right);
                    int n2 = Rob(root.right);
                    int max= Math.Max(n1, n2);
                    dic[root] = max;
                    return max;
                }
            }
            else
            {
                if(root.right==null)//root.left不为空 root.right为空
                {
                    int n1 = root.val + Rob(root.left.left) + Rob(root.left.right);
                    int n2 = Rob(root.left);
                    int max = Math.Max(n1, n2);
                    dic[root] = max;
                    return max;
                }
                else//root.left不为空 root.right不为空
                {
                    int n1 = Rob(root.left) + Rob(root.right);
                    int n2=root.val+ Rob(root.left.left) + Rob(root.left.right)+
                        Rob(root.right.left) + Rob(root.right.right);
                    int max = Math.Max(n1, n2);
                    dic[root] = max;
                    return max;
                }
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
