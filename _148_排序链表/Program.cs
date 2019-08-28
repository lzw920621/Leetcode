using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _148_排序链表
{
    /*
    在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序。

    示例 1:
    输入: 4->2->1->3
    输出: 1->2->3->4

    示例 2:
    输入: -1->5->3->4->0
    输出: -1->0->3->4->5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/sort-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
        //使用归并排序的思想来实现
        public static ListNode SortList(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return head;

            ListNode node1 = head;
            ListNode node2 = head.next;
            while(node2!=null && node2.next!=null)
            {
                node1 = node1.next;
                node2 = node2.next.next;
            }
            ListNode node3 = node1.next;
            node1.next = null;
            ListNode listNode1 = SortList(head);
            ListNode listNode2 = SortList(node3);
            return MergeTwoLists(listNode1, listNode2);
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)//合并两个链表
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val >= l2.val)
            {
                l2.next = MergeTwoLists(l2.next, l1);
                return l2;
            }
            else
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
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
