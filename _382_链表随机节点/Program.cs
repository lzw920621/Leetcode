using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _382_链表随机节点
{
    /*
        给定一个单链表，随机选择链表的一个节点，并返回相应的节点值。保证每个节点被选的概率一样。

    进阶:
    如果链表十分大且长度未知，如何解决这个问题？你能否使用常数级空间复杂度实现？

    示例:

    // 初始化一个单链表 [1,2,3].
    ListNode head = new ListNode(1);
    head.next = new ListNode(2);
    head.next.next = new ListNode(3);
    Solution solution = new Solution(head);

    // getRandom()方法应随机返回1,2,3中的一个，保证每个元素被返回的概率相等。
    solution.getRandom();

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/linked-list-random-node
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }


        //蓄水池抽样
        public class Solution
        {
            ListNode head = null;

            /** @param head The linked list's head.
                Note that the head is guaranteed to be not null, so it contains at least one node. */
            public Solution(ListNode head)
            {
                this.head = head;                
            }

            /** Returns a random node's value. */
            public int GetRandom()
            {
                ListNode node = head;
                Random random = new Random();
                int ans = node.val;
                int n = 2;
                node = node.next;
                while (node != null)
                {
                    if (random.Next(n) == n - 1)
                        ans = node.val;
                    n++;
                    node = node.next;
                }
                return ans;
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
