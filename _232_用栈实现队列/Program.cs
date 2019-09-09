using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _232_用栈实现队列
{
    /*
        使用栈实现队列的下列操作：

        push(x) -- 将一个元素放入队列的尾部。
        pop() -- 从队列首部移除元素。
        peek() -- 返回队列首部的元素。
        empty() -- 返回队列是否为空。

    示例:

    MyQueue queue = new MyQueue();

    queue.push(1);
    queue.push(2);  
    queue.peek();  // 返回 1
    queue.pop();   // 返回 1
    queue.empty(); // 返回 false

    说明:

        你只能使用标准的栈操作 -- 也就是只有 push to top, peek/pop from top, size, 和 is empty 操作是合法的。
        你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。
        假设所有操作都是有效的 （例如，一个空的队列不会调用 pop 或者 peek 操作）。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/implement-queue-using-stacks
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MyQueue
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();        

        /** Initialize your data structure here. */
        public MyQueue()
        {

        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            stack1.Push(x);            
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            stack2.Clear();
            while(stack1.Count>0)
            {
                stack2.Push(stack1.Pop());
            }
            int num= stack2.Pop();
            while(stack2.Count>0)
            {
                stack1.Push(stack2.Pop());
            }
            return num;
        }

        /** Get the front element. */
        public int Peek()
        {
            stack2.Clear();
            while (stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
            int num = stack2.Peek();
            while (stack2.Count > 0)
            {
                stack1.Push(stack2.Pop());
            }
            return num;
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return stack1.Count == 0;
        }
    }

    public class MyQueue2
    {
        Stack<int> s1;
        Stack<int> s2;
        /** Initialize your data structure here. */
        public MyQueue2()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }
        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            while (s2.Count != 0)
            {
                s1.Push(s2.Pop());
            }
            s1.Push(x);
        }
        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            while (s1.Count != 0)
            {
                s2.Push(s1.Pop());
            }
            return s2.Pop();
        }
        /** Get the front element. */
        public int Peek()
        {
            while (s1.Count != 0)
            {
                s2.Push(s1.Pop());
            }
            return s2.Peek();
        }
        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return (s1.Count + s2.Count) == 0;
        }
    }
}
