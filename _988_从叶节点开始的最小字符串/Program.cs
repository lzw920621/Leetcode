using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _988_从叶节点开始的最小字符串
{
    /*
        给定一颗根结点为 root 的二叉树，书中的每个结点都有一个从 0 到 25 的值，分别代表字母 'a' 到 'z'：值 0 代表 'a'，值 1 代表 'b'，依此类推。
    找出按字典序最小的字符串，该字符串从这棵树的一个叶结点开始，到根结点结束。
    （小贴士：字符串中任何较短的前缀在字典序上都是较小的：例如，在字典序上 "ab" 比 "aba" 要小。叶结点是指没有子结点的结点。）
    
    示例 1：

    输入：[0,1,2,3,4,3,4]
    输出："dba"

    示例 2：

    输入：[25,1,3,1,3,0,2]
    输出："adz"

    示例 3：

    输入：[2,2,1,null,1,0,null,0]
    输出："abc"
    
    提示：
        给定树的结点数介于 1 和 8500 之间。
        树中的每个结点都有一个介于 0 和 25 之间的值。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/smallest-string-starting-from-leaf
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(0);
            root.left = new TreeNode(1);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(4);
            string str = new Program().SmallestFromLeaf(root);
        }

        public string SmallestFromLeaf(TreeNode root)
        {
            List<List<int>> list = new List<List<int>>();
            Assist(root, list, new List<int>());
            List<int> tempList = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if(IsBigger(list[i],tempList)==false)
                {
                    tempList = list[i];
                }
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < tempList.Count; i++)
            {
                sb.Append((char)(tempList[i] + 'a'));
            }
            return sb.ToString();
        }

        void Assist(TreeNode root, List<List<int>> list,List<int> tempList)
        {
            if (root == null) return;
            List<int> newTempList = tempList.Select(item => item).ToList();
            newTempList.Add(root.val);
            if (root.left==null && root.right==null)
            {                
                newTempList.Reverse();
                list.Add(newTempList);
            }
            else
            {
                Assist(root.left, list, newTempList);
                Assist(root.right, list, newTempList);
            }
        }

        bool IsBigger(List<int> list1,List<int> list2)
        {
            if(list1.Count>list2.Count)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    if(list1[i]>list2[i])
                    {
                        return true;
                    }
                    else if(list1[i]<list2[i])
                    {
                        return false;
                    }
                }
                return true; 
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] > list2[i])
                    {
                        return true;
                    }
                    else if (list1[i] < list2[i])
                    {
                        return false;
                    }
                }
                return false;
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
