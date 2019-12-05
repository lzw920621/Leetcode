using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _138_复制带随机指针的链表
{
    /*
        给定一个链表，每个节点包含一个额外增加的随机指针，该指针可以指向链表中的任何节点或空节点。

    要求返回这个链表的深拷贝。 

 

    示例：

    输入：
    {"$id":"1","next":{"$id":"2","next":null,"random":{"$ref":"2"},"val":2},"random":{"$ref":"2"},"val":1}

    解释：
    节点 1 的值是 1，它的下一个指针和随机指针都指向节点 2 。
    节点 2 的值是 2，它的下一个指针指向 null，随机指针指向它自己。

 

    提示：

        你必须返回给定头的拷贝作为对克隆列表的引用。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/copy-list-with-random-pointer
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;
            Dictionary<Node, int> dic = new Dictionary<Node, int>();
            List<Node> list = new List<Node>();
            List<Node> list2 = new List<Node>();

            int index = 0;
            Node tempNode = head;
            while(tempNode!=null)
            {
                list.Add(tempNode);

                Node tempNode2 = new Node();
                tempNode2.val = tempNode.val;
                list2.Add(tempNode2);

                dic[tempNode] = index;
                index++;
                tempNode = tempNode.next;
            }
            for (int i = 1; i < index; i++)
            {
                list2[i - 1].next = list2[i];
            }
            for (int i = 0; i < index; i++)
            {
                if(list[i].random==null)
                {
                    list2[i].random = null;
                }
                else
                {
                    int tempIndex = dic[list[i].random];//随机指针对应的索引
                    list2[i].random = list2[tempIndex];
                }                
            }
            return list2[0];
        }

        public Node CopyRandomList2(Node head)
        {
            if (head == null) return null;
            Dictionary<Node, Node> dic = new Dictionary<Node, Node>();
            Node temp = head;
            while(temp!=null)
            {
                Node tempNode2 = new Node();
                tempNode2.val = temp.val;
                dic[temp] = tempNode2;

                temp = temp.next;
            }

            foreach (var item in dic)
            {
                if(item.Key.next!=null)
                {
                    item.Value.next = dic[item.Key.next];
                }
                else
                {
                    item.Value.next = null;
                }

                if(item.Key.random!=null)
                {
                    item.Value.random = dic[item.Key.random];
                }
                else
                {
                    item.Value.random = null;
                }
            }
            return dic[head];
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }
        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    }
}