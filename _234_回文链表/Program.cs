using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _234_回文链表
{
    /*
    请判断一个链表是否为回文链表。

    示例 1:

    输入: 1->2
    输出: false

    示例 2:

    输入: 1->2->2->1
    输出: true

    进阶：
    你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/palindrome-linked-list
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(1);
            bool isTrue = IsPalindrome(head);
        }

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;
            ListNode temp1 = head;
            ListNode temp2 = head;
            while(temp2!=null && temp2.next!=null)//快慢指针找中点
            {
                temp1 = temp1.next;
                temp2 = temp2.next.next;
            }
            //将后半部分翻转
            ListNode temp = null;
            while(temp1!=null)
            {
                ListNode temp3 = temp1.next;
                temp1.next = temp;
                temp = temp1;
                temp1 = temp3;
            }
            while(temp!=null)
            {
                if(head.val==temp.val)
                {
                    head = head.next;
                    temp = temp.next;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
