using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_合并两个有序链表
{
    /*
    将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 

    示例：

    输入：1->2->4, 1->3->4
    输出：1->1->2->3->4->4

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/merge-two-sorted-lists
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode listNodeA = new ListNode(1);
            listNodeA.next = new ListNode(2);
            listNodeA.next.next = new ListNode(4);

            ListNode listNodeB = new ListNode(1);
            listNodeB.next = new ListNode(3);
            listNodeB.next.next = new ListNode(4);

            ListNode newListNode = MergeTwoLists(listNodeA, listNodeB);

        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode listNode = null;
            ListNode nextNode = null;
            if (l1.val <= l2.val)
            {
                listNode = l1;
                l1 = l1.next;
            }
            else
            {
                listNode = l2;
                l2 = l2.next;
            }
            nextNode = listNode;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    nextNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    nextNode.next = l2;
                    l2 = l2.next;
                }
                nextNode = nextNode.next;
            }
            while (l1 != null)
            {
                nextNode.next = l1;
                l1 = l1.next;
                nextNode = nextNode.next;
            }
            while (l2 != null)
            {
                nextNode.next = l2;
                l2 = l2.next;
                nextNode = nextNode.next;
            }
            return listNode;
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
