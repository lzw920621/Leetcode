using System;

namespace _23_合并K个排序链表
{
    /*
    合并 k 个排序链表，返回合并后的排序链表。请分析和描述算法的复杂度。

    示例:

    输入:
    [
      1->4->5,
      1->3->4,
      2->6
    ]
    输出: 1->1->2->3->4->4->5->6

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/merge-k-sorted-lists
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length < 1) return null;
            if (lists.Length == 1) return lists[0];

            return MergeListsAssist(lists, 0, lists.Length - 1);
        }

        static ListNode MergeListsAssist(ListNode[] lists,int left,int right)//归并
        {
            if (left > right) return null;
            if (left == right) return lists[left];
            int mid = (left + right) / 2;
            ListNode listNode1 = MergeListsAssist(lists, left, mid);
            ListNode listNode2 = MergeListsAssist(lists, mid + 1, right);
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
