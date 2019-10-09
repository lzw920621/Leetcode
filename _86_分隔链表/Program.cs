using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _86_分隔链表
{
    /*
        给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。

    你应当保留两个分区中每个节点的初始相对位置。

    示例:

    输入: head = 1->4->3->2->5->2, x = 3
    输出: 1->2->2->4->3->5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/partition-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。




    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(4);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(2);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(2);

            ListNode newHead = new Program().Partition(head, 3);
        }

        public ListNode Partition(ListNode head, int x)
        {
            if (head == null) return head;
            Queue<ListNode> queue1 = new Queue<ListNode>();
            Queue<ListNode> queue2 = new Queue<ListNode>();
            ListNode temp = head;
            while(temp!=null)
            {
                if(temp.val<x)
                {
                    queue1.Enqueue(temp);
                }
                else
                {
                    queue2.Enqueue(temp);
                }
                temp = temp.next;
            }

            ListNode tempHead;
            if(queue1.Count>0)
            {
                tempHead = queue1.Dequeue();
                ListNode temp2 = tempHead;
                while(queue1.Count > 0)
                {
                    temp2.next = queue1.Dequeue();
                    temp2 = temp2.next;
                    temp2.next = null;
                }
                while(queue2.Count>0)
                {
                    temp2.next = queue2.Dequeue();
                    temp2 = temp2.next;
                    temp2.next = null;
                }
            }
            else
            {
                tempHead = queue2.Dequeue();
                ListNode temp2 = tempHead;
                while (queue2.Count > 0)
                {
                    temp2.next = queue2.Dequeue();
                    temp2 = temp2.next;
                    temp2.next = null;
                }
            }
            return tempHead;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
