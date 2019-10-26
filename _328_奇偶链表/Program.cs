using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _328_奇偶链表
{
    /*
        给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，
    而不是节点的值的奇偶性。请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。

    示例 1:

    输入: 1->2->3->4->5->NULL
    输出: 1->3->5->2->4->NULL

    示例 2:

    输入: 2->1->3->5->6->4->7->NULL 
    输出: 2->3->6->7->1->5->4->NULL

    说明:
        应当保持奇数节点和偶数节点的相对顺序。
        链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/odd-even-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode evenHead = head.next;
            ListNode node1 = head;
            ListNode node2 = head.next;
            while(node1!=null && node2!=null)
            {                
                node1.next = node2.next;
                node1 = node2;
                node2 = node2.next;
            }
            if(node1!=null)
            {
                node1.next = null;
            }
            if(node2!=null)
            {
                node2.next = null;
            }
            
            ListNode temp = head;
            while(temp.next!=null)
            {
                temp = temp.next;
            }
            temp.next = evenHead;
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
