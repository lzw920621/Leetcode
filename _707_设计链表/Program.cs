using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _707_设计链表
{
    /*
        设计链表的实现。您可以选择使用单链表或双链表。单链表中的节点应该具有两个属性：val 和 next。val 是当前节点的值，next 是指向下一个节点的指针/引用。如果要使用双向链表，则还需要一个属性 prev 以指示链表中的上一个节点。假设链表中的所有节点都是 0-index 的。
    在链表类中实现这些功能：

        get(index)：获取链表中第 index 个节点的值。如果索引无效，则返回-1。
        addAtHead(val)：在链表的第一个元素之前添加一个值为 val 的节点。插入后，新节点将成为链表的第一个节点。
        addAtTail(val)：将值为 val 的节点追加到链表的最后一个元素。
        addAtIndex(index,val)：在链表中的第 index 个节点之前添加值为 val  的节点。如果 index 等于链表的长度，则该节点将附加到链表的末尾。如果 index 大于链表长度，则不会插入节点。如果index小于0，则在头部插入节点。
        deleteAtIndex(index)：如果索引 index 有效，则删除链表中的第 index 个节点。
        
    示例：

    MyLinkedList linkedList = new MyLinkedList();
    linkedList.addAtHead(1);
    linkedList.addAtTail(3);
    linkedList.addAtIndex(1,2);   //链表变为1-> 2-> 3
    linkedList.get(1);            //返回2
    linkedList.deleteAtIndex(1);  //现在链表是1-> 3
    linkedList.get(1);            //返回3

 

    提示：

        所有val值都在 [1, 1000] 之内。
        操作次数将在  [1, 1000] 之内。
        请不要使用内置的 LinkedList 库。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/design-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();
            int num1 = list.Get(0);
            list.AddAtIndex(1, 2);
            int num2 = list.Get(0);
            int num3 = list.Get(1);
            list.AddAtIndex(0, 1);
            int num4 = list.Get(0);
            int num5 = list.Get(1);
        }
    }

    class Node
    {
        public int val;
        public Node next;
        public Node(int val)
        {
            this.val = val;
        }
    }

    public class MyLinkedList
    {
        Node head;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = null;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if( index < 0 )
            {
                return -1;
            }
            
            Node tempNode = head;
            while(index>0 && tempNode!=null)
            {
                tempNode = tempNode.next;
                index--;
            }
            return tempNode == null ? -1 : tempNode.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node newHead = new Node(val);
            newHead.next = head;
            head = newHead;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {           
            if(head==null)
            {
                head = new Node(val);
            }
            else
            {
                Node lastNode = head;
                while(lastNode.next!=null)
                {
                    lastNode = lastNode.next;
                }
                lastNode.next = new Node(val);
            }            
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if(index<=0)
            {
                AddAtHead(val);
            }
            else
            {
                int i = 0;
                Node tempNode = head;
                while (tempNode != null && i < index - 1)//寻找index的前一个节点
                {
                    tempNode = tempNode.next;
                    i++;
                }
                if (tempNode != null)//要插入的索引位置未超出链表长度
                {
                    Node newNode = new Node(val);
                    newNode.next = tempNode.next;
                    tempNode.next = newNode;
                }
            }
            
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (head == null) return;
            if (index == 0)
            {
                head = head.next;
            }
            if (index>0)
            {
                int i = 0;
                Node tempNode = head;
                while (tempNode != null && i < index - 1)//寻找index的前一个节点
                {
                    tempNode = tempNode.next;
                    i++;
                }
                if (tempNode != null && tempNode.next != null)
                {
                    if(tempNode.next.next==null)
                    {
                        tempNode.next = null;
                    }
                    else
                    {
                        tempNode.next = tempNode.next.next;
                    }
                }
            }
        }
    }
}
