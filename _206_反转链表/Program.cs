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

        public ListNode ReverseList2(ListNode head)
        {
            ListNode list1 = null;
            ListNode list2 = head;

            while (list2 != null)
            {
                var list2Next = list2.next;
                list2.next = list1;
                list1 = list2;
                list2 = list2Next;
            }

            return list1;
        }
    }


  public class ListNode
  {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }
}
