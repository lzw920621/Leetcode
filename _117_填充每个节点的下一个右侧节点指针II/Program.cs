﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _117_填充每个节点的下一个右侧节点指针II
{
    /*
        给定一个二叉树

    struct Node {
      int val;
      Node *left;
      Node *right;
      Node *next;
    }

    填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。

    初始状态下，所有 next 指针都被设置为 NULL。

 

    示例：

    输入：{"$id":"1","left":{"$id":"2","left":{"$id":"3","left":null,"next":null,"right":null,"val":4},"next":null,"right":{"$id":"4","left":null,"next":null,"right":null,"val":5},"val":2},"next":null,"right":{"$id":"5","left":null,"next":null,"right":{"$id":"6","left":null,"next":null,"right":null,"val":7},"val":3},"val":1}

    输出：{"$id":"1","left":{"$id":"2","left":{"$id":"3","left":null,"next":{"$id":"4","left":null,"next":{"$id":"5","left":null,"next":null,"right":null,"val":7},"right":null,"val":5},"right":null,"val":4},"next":{"$id":"6","left":null,"next":null,"right":{"$ref":"5"},"val":3},"right":{"$ref":"4"},"val":2},"next":null,"right":{"$ref":"6"},"val":1}

    解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。

 

    提示：

        你只能使用常量级额外空间。
        使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public Node Connect(Node root)
        {
            if (root == null) return null;
            Queue<Node> queue = new Queue<Node>();
            Node tempNode;
            int tempCount;
            Node preNode;

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                preNode = queue.Peek();
                tempCount = queue.Count;
                for (int i = 0; i < tempCount; i++)
                {
                    tempNode = queue.Dequeue();
                    if (i >= 1)
                    {
                        preNode.next = tempNode;
                        preNode = tempNode;
                    }

                    if (tempNode.left != null)
                    {
                        queue.Enqueue(tempNode.left);
                    }
                    if (tempNode.right != null)
                    {
                        queue.Enqueue(tempNode.right);
                    }
                }
            }
            return root;
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }
        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
