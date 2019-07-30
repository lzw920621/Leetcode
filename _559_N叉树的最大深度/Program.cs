using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _559_N叉树的最大深度
{
    /*
    给定一个 N 叉树，找到其最大深度。

    最大深度是指从根节点到最远叶子节点的最长路径上的节点总数。

    例如，给定一个 3叉树 :
    

    我们应返回其最大深度，3。

    说明:

        树的深度不会超过 1000。
        树的节点总不会超过 5000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/maximum-depth-of-n-ary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int MaxDepth(Node root)
        {
            if (root == null) return 0;
            if(root.children.Count>0)
            {
                int[] array = new int[root.children.Count];
                for (int i = 0; i < root.children.Count; i++)
                {
                    array[i] = MaxDepth(root.children[i]);
                }
                return array.Max() + 1;
            }
            else
            {
                return 1;
            }
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
