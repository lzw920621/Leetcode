using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _173_二叉搜索树迭代器
{
    /*
        实现一个二叉搜索树迭代器。你将使用二叉搜索树的根节点初始化迭代器。

    调用 next() 将返回二叉搜索树中的下一个最小的数。

 

    示例：

    BSTIterator iterator = new BSTIterator(root);
    iterator.next();    // 返回 3
    iterator.next();    // 返回 7
    iterator.hasNext(); // 返回 true
    iterator.next();    // 返回 9
    iterator.hasNext(); // 返回 true
    iterator.next();    // 返回 15
    iterator.hasNext(); // 返回 true
    iterator.next();    // 返回 20
    iterator.hasNext(); // 返回 false

 

    提示：

        next() 和 hasNext() 操作的时间复杂度是 O(1)，并使用 O(h) 内存，其中 h 是树的高度。
        你可以假设 next() 调用总是有效的，也就是说，当调用 next() 时，BST 中至少存在一个下一个最小的数。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/binary-search-tree-iterator
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class BSTIterator
    {
#warning 不满足题设条件 使用 O(h) 内存，其中 h 是树的高度。
        List<int> list = new List<int>();
        IEnumerator<int> enumerator;
        int index = -1;

        public BSTIterator(TreeNode root)
        {
            Inorder(root, list);            
        }

        /** @return the next smallest number */
        public int Next()
        {
            if(index+1<list.Count)
            {
                return GetNext();
            }
            return 0;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return index + 1 < list.Count;
        }

        void Inorder(TreeNode root,List<int> list)
        {
            if (root == null) return;
            Inorder(root.left, list);
            list.Add(root.val);
            Inorder(root.right, list);
        }

        int GetNext()
        {
            index++;
            return list[index];
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
