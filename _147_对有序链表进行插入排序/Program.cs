using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _147_对链表进行插入排序
{
    /*
        对链表进行插入排序。       
    插入排序的动画演示如上。从第一个元素开始，该链表可以被认为已经部分排序（用黑色表示）。
    每次迭代时，从输入数据中移除一个元素（用红色表示），并原地将其插入到已排好序的链表中。
    
    插入排序算法：

        插入排序是迭代的，每次只移动一个元素，直到所有元素可以形成一个有序的输出列表。
        每次迭代中，插入排序只从输入数据中移除一个待排序的元素，找到它在序列中适当的位置，并将其插入。
        重复直到所有输入数据插入完为止。
        
    示例 1：

    输入: 4->2->1->3
    输出: 1->2->3->4

    示例 2：

    输入: -1->5->3->4->0
    输出: -1->0->3->4->5

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/insertion-sort-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
    
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode current = head;
            while(current.next!=null)
            {
                //寻找待排序的节点
                while (current != null && current.next != null && current.val <= current.next.val)
                {
                    current = current.next;
                }
                if (current.next != null)
                {
                    ListNode tempNode = current.next;//待排序的节点
                    current.next = tempNode.next;
                    //从头节点开始向后遍历找到合适的位置进行插入
                    if (tempNode.val < head.val)
                    {
                        tempNode.next = head;
                        head = tempNode;
                    }
                    else
                    {
                        ListNode tempNode2 = head;
                        while(tempNode.val>tempNode2.next.val)
                        {
                            tempNode2 = tempNode2.next;
                        }
                        tempNode.next = tempNode2.next;
                        tempNode2.next = tempNode;
                    }
                }
            }
            return head;
            
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
