using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _92_反转链表II
{
    /*
        反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。

    说明:
    1 ≤ m ≤ n ≤ 链表长度。

    示例:

    输入: 1->2->3->4->5->NULL, m = 2, n = 4
    输出: 1->4->3->2->5->NULL

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-linked-list-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);
            ListNode newHead = ReverseBetween(head, 1, 3);
        }

        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (head == null || m == n) return head;
            int index1 = m - 1;
            int index2 = n - 1;
            int tempIndex = 0;
            if(index1==0)
            {
                ListNode node1 = null;
                ListNode node2 = head;
                while(tempIndex<=index2)
                {
                    tempIndex++;
                    ListNode tempNode = node2.next;
                    node2.next = node1;
                    node1 = node2;
                    node2 = tempNode;
                }
                head.next = node2;
                return node1;
            }
            else
            {
                ListNode node = head;
                while(tempIndex+1<index1)
                {
                    node = node.next;
                    tempIndex++;
                }
                tempIndex++;
                ListNode node1 = null;
                ListNode node2 = node.next;
                while (tempIndex <= index2)
                {
                    tempIndex++;
                    ListNode tempNode = node2.next;
                    node2.next = node1;
                    node1 = node2;
                    node2 = tempNode;
                }
                node.next.next = node2;
                node.next = node1;
                return head;
            }
            
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
