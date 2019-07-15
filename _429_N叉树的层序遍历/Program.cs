using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _429_N叉树的层序遍历
{
    /*
    给定一个 N 叉树，返回其节点值的层序遍历。 (即从左到右，逐层遍历)。

    例如，给定一个 3叉树 :

    返回其层序遍历:

    [
         [1],
         [3,2,4],
         [5,6]
    ]
    
    说明:

        树的深度不会超过 1000。
        树的节点总数不会超过 5000。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/n-ary-tree-level-order-traversal
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IList<IList<int>> LevelOrder(Node root)
        {           
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null) return list;
            Queue<Node> queue = new Queue<Node>();
            Node current = root;
            queue.Enqueue(current);
            while(queue.Count!=0)
            {
                int count = queue.Count();//当前队列里的元素个数
                List<int> subList = new List<int>();
                while (count>0)
                {
                    current = queue.Dequeue();
                    subList.Add(current.val);
                    foreach (var node in current.children)
                    {
                        queue.Enqueue(node);
                    }
                    count--;
                }
                list.Add(subList);
                
            }

            return list;
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