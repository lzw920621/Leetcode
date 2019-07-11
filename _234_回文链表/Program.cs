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
        }

        public static bool IsPalindrome(ListNode head)
        {
            ListNode current1 = head;
            ListNode current2 = head.next;

            int len = 0;
            while(current1!=null)//获取链表长度
            {
                len++;
                current1 = current1.next;
            }
            if(len%2==1)//长度为奇数
            {
                int mid = len / 2 + 1;//中心点位置
            }
            else//长度为偶数
            {

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
