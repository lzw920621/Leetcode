using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_删除链表的倒数第N个节点
{
    /*
    给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。

    示例：

    给定一个链表: 1->2->3->4->5, 和 n = 2.

    当删除了倒数第二个节点后，链表变为 1->2->3->5.

    说明：

    给定的 n 保证是有效的。

    进阶：

    你能尝试使用一趟扫描实现吗？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)//双指针法
        {
            if (head.next == null && n == 1) return null;
            ListNode node1 = head;
            ListNode node2 = head;
            
            while (n > 0)//node1先向后走N步
            {
                node2 = node2.next;
                n--;
                if (node2 == null) return head.next;//特殊情况 倒数第N个节点正好是头节点
            }
            while(node2.next!=null)//然后 node1 node2 一起往后走 当node2的下一个节点为空时 node1刚好时倒数第N+1个节点
            {
                node2 = node2.next;
                node1 = node1.next;
            }
            if (n == 1)
            {
                node1.next = null;
            }
            else
            {
                node1.next = node1.next.next;
            }
            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
