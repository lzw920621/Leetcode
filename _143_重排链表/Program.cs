using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _143_重排链表
{
    /*
        给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
    将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…

    你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。

    示例 1:

    给定链表 1->2->3->4, 重新排列为 1->4->2->3.

    示例 2:

    给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3.

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/reorder-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null) return;
            ListNode temp = head;
            ListNode temp2 = head;
            while(temp2!=null && temp2.next!=null)//快慢指针找中点
            {
                temp = temp.next;
                temp2 = temp2.next;
                temp2 = temp2.next;
            }
            if(temp2!=null)
            {
                temp = temp.next;
            }
            ListNode temp3 = head;
            Queue<ListNode> queue = new Queue<ListNode>();//链表前半部分放入队列 
            while(temp3!=temp)
            {
                queue.Enqueue(temp3);
                temp3 = temp3.next;
            }
            ListNode temp4 = temp;
            Stack<ListNode> stack = new Stack<ListNode>();//链表后半部分放入栈中
            while(temp4!=null)
            {
                stack.Push(temp4);
                temp4 = temp4.next;
            }
            ListNode temp5 = queue.Dequeue();
            while(queue.Count>0 && stack.Count>0)
            {
                temp5.next = stack.Pop();
                temp5 = temp5.next;
                temp5.next = queue.Dequeue();
                temp5 = temp5.next;
                temp5.next = null;
            }
            while(queue.Count>0)
            {
                temp5.next = queue.Dequeue();
                temp5 = temp5.next;
                temp5.next = null;
            }
            while(stack.Count>0)
            {
                temp5.next = stack.Pop();
                temp5 = temp5.next;
                temp5.next = null;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
}
