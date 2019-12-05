using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _146_LRU缓存机制
{
    /*
        运用你所掌握的数据结构，设计和实现一个  LRU (最近最少使用) 缓存机制。它应该支持以下操作： 获取数据 get 和 写入数据 put 。
    获取数据 get(key) - 如果密钥 (key) 存在于缓存中，则获取密钥的值（总是正数），否则返回 -1。
    写入数据 put(key, value) - 如果密钥不存在，则写入其数据值。当缓存容量达到上限时，
    它应该在写入新数据之前删除最近最少使用的数据值，从而为新的数据值留出空间。

    进阶:

    你是否可以在 O(1) 时间复杂度内完成这两种操作？

    示例:

    LRUCache cache = new LRUCache( 2 /缓存容量/ );

    cache.put(1, 1);
    cache.put(2, 2);
    cache.get(1);       // 返回  1
    cache.put(3, 3);    // 该操作会使得密钥 2 作废
    cache.get(2);       // 返回 -1 (未找到)
    cache.put(4, 4);    // 该操作会使得密钥 1 作废
    cache.get(1);       // 返回 -1 (未找到)
    cache.get(3);       // 返回  3
    cache.get(4);       // 返回  4

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/lru-cache
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */

    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            cache.Get(1);       // 返回  1
            cache.Put(3, 3);    // 该操作会使得密钥 2 作废
            cache.Get(2);       // 返回 -1 (未找到)
            cache.Put(4, 4);    // 该操作会使得密钥 1 作废
            cache.Get(1);       // 返回 -1 (未找到)
            cache.Get(3);       // 返回  3
            cache.Get(4);       // 返回  4
            
        }
    }

    public class LRUCache
    {
        Dictionary<int, Node> dic = new Dictionary<int, Node>();
        Node head;//头节点
        Node tail;//尾节点
        int count;//节点数
        int capacity;//容量

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            count = 0;
        }

        public int Get(int key)
        {
            if(dic.ContainsKey(key))
            {
                MoveCurrentNodeToHead(dic[key]);//将节点移动到头部
                return dic[key].value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if(dic.ContainsKey(key))//节点已存在,则更新节点值,并将节点移动到头部
            {
                dic[key].value = value;

                MoveCurrentNodeToHead(dic[key]);//将节点移动到头部
            }
            else//节点不存在 
            {
                Node newNode = new Node(key, value);
                AddNewNode(newNode);//添加新节点
                
                if(count>capacity)//容量已满,删除链表尾节点
                {                                       
                    DeleteTail();//删除尾节点
                }
            }
        }

        //添加新节点
        void AddNewNode(Node node)
        {
            dic[node.key] = node;
            count++;

            if(head==null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.next = head;
                head.pre = node;
                head = node;
            }      
        }

        //删除尾节点
        void DeleteTail()
        {
            dic.Remove(tail.key);
            count--;

            if (tail.pre==null)//尾节点 同时也是头节点
            {               
                head = null;
                tail = null;                
            }
            else//将尾节点的前节点作为新的尾节点
            {
                Node newTail = tail.pre;
                newTail.next = null;
                tail = newTail;               
            }
        }

        //将指定节点移动到链表头部
        void MoveCurrentNodeToHead(Node node)
        {
            if (node.pre == null)//当前节点就是头节点
            {
                return;
            }

            if(node.next==null)//当前节点是尾节点
            {
                Node preNode = node.pre;
                preNode.next = null;
                tail = preNode;
            }
            else
            {
                Node preNode = node.pre;
                Node nextNode = node.next;
                preNode.next = nextNode;
                nextNode.pre = preNode;               
            }

            node.pre = null;
            node.next = head;
            head.pre = node;
            head = node;
        }
    }

    class Node
    {
        public int key;
        public int value;
        public Node pre;
        public Node next;
        public Node(int key,int value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
