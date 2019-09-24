using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _297_二叉树的序列化和反序列化
{
    /*
        序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。
    请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。

    示例: 
    你可以将以下二叉树：

        1
       / \
      2   3
         / \
        4   5

    序列化为 "[1,2,3,null,null,4,5]"

    提示: 这与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。

    说明: 不要使用类的成员 / 全局 / 静态变量来存储状态，你的序列化和反序列化算法应该是无状态的。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);

            root.right.left = new TreeNode(2);
            root.right.right = new TreeNode(4);

            Codec codec = new Codec();
            string str = codec.serialize(root);
            TreeNode newRoot = codec.deserialize(str);
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
            while(queue.Count>0)
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    current = queue.Dequeue();
                    if(current!=null)
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
            while(queue.Count>0)
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
