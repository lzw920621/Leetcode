using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _203_移除链表元素
{
    /*
    删除链表中等于给定值 val 的所有节点。

    示例:

    输入: 1->2->6->3->4->5->6, val = 6
    输出: 1->2->3->4->5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/remove-linked-list-elements
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(4);
            head.next.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next.next = new ListNode(6);

            ListNode node = RemoveElements(head, 6);
            List<int> list = new List<int>();
            while(node!=null)
            {
                list.Add(node.val);
                node = node.next;
            }
        }

        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            while(head!=null && head.val==val)//寻找新的头节点 (排除头节点刚好是要删除的节点)
            {
                head = head.next;
            }
            if(head!=null)
            {
                ListNode node1 = head.next;
                while (node1 != null && node1.val == val)//找到头节点之后的第一个非空节点
                {
                    node1 = node1.next;
                }
                head.next = node1;

                if(node1!=null)                 
                {
                    ListNode node2 = node1.next;
                    while(node2!=null)
                    {
                        if(node2.val==val)
                        {
                            node2 = node2.next;
                            node1.next = node2;
                        }
                        else
                        {
                            node1 = node2;
                            node2 = node2.next;
                        }
                    }
                }
            }

            return head;
        }

        public static ListNode RemoveElements1(ListNode head, int val)
        {
            ListNode header = new ListNode(-1);
            header.next = head;
            ListNode cur = header;
            while (cur.next != null)
            {
                if (cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }
            return header.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
