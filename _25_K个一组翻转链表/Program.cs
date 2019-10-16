using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_K个一组翻转链表
{
    /*
        给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。
    k 是一个正整数，它的值小于或等于链表的长度。
    如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。

    示例 :

    给定这个链表：1->2->3->4->5

    当 k = 2 时，应当返回: 2->1->4->3->5

    当 k = 3 时，应当返回: 3->2->1->4->5

    说明 :

        你的算法只能使用常数的额外空间。
        你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reverse-nodes-in-k-group
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            ListNode newHead = ReverseKGroup(head, 3);
        }

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || head.next==null ||k==1) return head;
            int index = 1;
            ListNode temp = head;
            while(temp!=null)
            {
                index++;
                temp = temp.next;
                
                if(index==k && temp!=null)
                {
                    ListNode nextHead = temp.next;

                    ListNode node1 = null;
                    ListNode node2 = head;
                    int tempIndex = 1;
                    while(tempIndex<=k)
                    {
                        tempIndex++;
                        ListNode tempNode = node2.next;
                        node2.next = node1;
                        node1 = node2;
                        node2 = tempNode;
                    }
                    head.next = ReverseKGroup(nextHead, k);
                    return node1;
                }
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
