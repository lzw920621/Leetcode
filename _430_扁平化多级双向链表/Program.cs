﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _430_扁平化多级双向链表
{
    /*
        您将获得一个双向链表，除了下一个和前一个指针之外，它还有一个子指针，可能指向单独的双向链表。
    这些子列表可能有一个或多个自己的子项，依此类推，生成多级数据结构，如下面的示例所示。
    扁平化列表，使所有结点出现在单级双链表中。您将获得列表第一级的头部。

 

    示例:

    输入:
     1---2---3---4---5---6--NULL
             |
             7---8---9---10--NULL
                 |
                 11--12--NULL

    输出:
    1-2-3-7-8-11-12-9-10-4-5-6-NULL

 

    以上示例的说明:

    给出以下多级双向链表:

 

    我们应该返回如下所示的扁平双向链表:



    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/flatten-a-multilevel-doubly-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public Node Flatten(Node head)
        {
            List<Node> list = new List<Node>();
            Helper(head, list);
            for (int i = 0; i < list.Count-1; i++)
            {
                list[i].next = list[i + 1];
                list[i + 1].prev = list[i];
                list[i].child = null;
            }
            return head;
        }

        void Helper(Node head,List<Node> list)
        {            
            Node tempNode = head;
            while(tempNode!=null)
            {
                list.Add(tempNode);
                if (tempNode.child != null)
                {
                    Helper(tempNode.child, list);
                }
                tempNode = tempNode.next;
            }           
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node() { }
        public Node(int _val, Node _prev, Node _next, Node _child)
        {
            val = _val;
            prev = _prev;
            next = _next;
            child = _child;
        }
    }
}