using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _206_反转链表
{
    /*
    反转一个单链表。

    示例:

    输入: 1->2->3->4->5->NULL
    输出: 5->4->3->2->1->NULL

    进阶:
    你可以迭代或递归地反转链表。你能否用两种方法解决这道题？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            Stack<ListNode> stack = new Stack<ListNode>();
            stack.Push(head);
            while(head.next!=null)
            {               
                head = head.next;
                stack.Push(head);
            }
            ListNode newHead= stack.Pop();
            ListNode node = newHead;
            while(stack.Count>0)
            {
                node.next = stack.Pop();
                node = node.next;
            }
            node.next = null;
            return newHead;
        }
        //迭代
        public ListNode ReverseList2(ListNode head)
        {
            ListNode node1 = null;
            ListNode node2 = head;
            
            while (node2 != null)
            {
                ListNode tempNode = node2.next;
                node2.next = node1;//颠倒节点指向
                node1 = node2;
                node2 = tempNode;                
            }
            return node1;
        }

        //递归
        public ListNode ReverseList3(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode nextNode = head.next;
            head.next = null;
            ListNode newHead= ReverseList3(nextNode);
            nextNode.next = head;
            return newHead;
        }
    }


  public class ListNode
  {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
