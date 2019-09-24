using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _449_序列化和反序列化二叉搜索树
{
    /*
        序列化是将数据结构或对象转换为一系列位的过程，以便它可以存储在文件或内存缓冲区中，或通过网络连接链路传输，
    以便稍后在同一个或另一个计算机环境中重建。
        设计一个算法来序列化和反序列化二叉搜索树。 对序列化/反序列化算法的工作方式没有限制。 您只需确保二叉搜索树可以序列化为字符串，
    并且可以将该字符串反序列化为最初的二叉搜索树。
    编码的字符串应尽可能紧凑。

    注意：不要使用类成员/全局/静态变量来存储状态。 你的序列化和反序列化算法应该是无状态的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/serialize-and-deserialize-bst
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Codec
    {
        public string serialize(TreeNode root)
        {
            if (root == null) return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            StringBuilder sb = new StringBuilder();
            TreeNode current;
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    current = queue.Dequeue();
                    if (current != null)
                    {
                        sb.Append(current.val);
                        queue.Enqueue(current.left);
                        queue.Enqueue(current.right);
                    }
                    else
                    {
                        sb.Append("null");
                    }
                    sb.Append(",");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        public TreeNode deserialize(string data)
        {
            if (data == null) return null;
            string[] strArray = data.Split(',');
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(int.Parse(strArray[0]));
            TreeNode current;
            queue.Enqueue(root);
            int i = 1;
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                if (current == null) continue;
                current.left = (strArray[i] != "null") ? new TreeNode(int.Parse(strArray[i])) : null;
                current.right = (strArray[i + 1] != "null") ? new TreeNode(int.Parse(strArray[i + 1])) : null;
                i += 2;
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
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
