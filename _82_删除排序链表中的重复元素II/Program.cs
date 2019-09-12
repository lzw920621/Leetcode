using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _82_删除排序链表中的重复元素II
{
    /*
    给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。

    示例 1:
    输入: 1->2->3->3->4->4->5
    输出: 1->2->5

    示例 2:
    输入: 1->1->1->2->3
    输出: 2->3

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode node1 = new ListNode(1);
            ListNode node2 = new ListNode(2);
            ListNode node3 = new ListNode(3);
            ListNode node4 = new ListNode(3);
            ListNode node5 = new ListNode(4);
            ListNode node6 = new ListNode(4);
            ListNode node7 = new ListNode(5);
            node1.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;
            node6.next = node7;

            ListNode node = DeleteDuplicates(node1);

        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode tempNode1 = head;
            ListNode tempNode2 = head.next;
            if(tempNode1.val!=tempNode2.val)
            {
                tempNode1.next = DeleteDuplicates(tempNode2);
                return tempNode1;
            }
            while(tempNode1.val==tempNode2.val)
            {
                tempNode1 = tempNode1.next;
                tempNode2 = tempNode2.next;
                if(tempNode2==null)
                {
                    break;
                }
            }
            return DeleteDuplicates(tempNode2);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
