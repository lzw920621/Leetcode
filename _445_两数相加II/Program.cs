using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _445_两数相加II
{
    /*
        给定两个非空链表来代表两个非负整数。数字最高位位于链表开始位置。它们的每个节点只存储单个数字。将这两数相加会返回一个新的链表。        
    你可以假设除了数字 0 之外，这两个数字都不会以零开头。

    进阶:

    如果输入链表不能修改该如何处理？换句话说，你不能对列表中的节点进行翻转。

    示例:

    输入: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
    输出: 7 -> 8 -> 0 -> 7

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/add-two-numbers-ii
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。


    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<ListNode> stack1 = new Stack<ListNode>();
            Stack<ListNode> stack2 = new Stack<ListNode>();
            ListNode node1 = l1, node2 = l2;
            int length1 = 0, length2 = 0;
            while(node1!=null)
            {
                stack1.Push(node1);
                node1 = node1.next;
                length1++;
            }
            while(node2!=null)
            {
                stack2.Push(node2);
                node2 = node2.next;
                length2++;
            }

            int carry = 0;
            ListNode tempNode = null;
            
            if (length1>=length2)
            {
                while (stack1.Count > 0 && stack2.Count > 0)
                {
                    tempNode = stack1.Pop();
                    int temp = tempNode.val + stack2.Pop().val + carry;
                    carry = temp / 10;
                    tempNode.val = temp % 10;
                }
                while (stack1.Count>0)
                {
                    tempNode = stack1.Pop();
                    int temp = tempNode.val + carry;
                    carry = temp / 10;
                    tempNode.val = temp % 10;
                }               
            }
            else
            {
                while (stack1.Count > 0 && stack2.Count > 0)
                {
                    tempNode = stack2.Pop();
                    int temp = tempNode.val + stack1.Pop().val + carry;
                    carry = temp / 10;
                    tempNode.val = temp % 10;
                }
                while (stack2.Count > 0)
                {
                    tempNode = stack2.Pop();
                    int temp = tempNode.val + carry;
                    carry = temp / 10;
                    tempNode.val = temp % 10;
                }
            }

            if (carry > 0)
            {
                ListNode head = new ListNode(carry);
                head.next = tempNode;
                return head;
            }
            else
            {
                return tempNode;
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
