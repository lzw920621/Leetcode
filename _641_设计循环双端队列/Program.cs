using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _641_设计循环双端队列
{
    /*
        设计实现双端队列。
    你的实现需要支持以下操作：

        MyCircularDeque(k)：构造函数,双端队列的大小为k。
        insertFront()：将一个元素添加到双端队列头部。 如果操作成功返回 true。
        insertLast()：将一个元素添加到双端队列尾部。如果操作成功返回 true。
        deleteFront()：从双端队列头部删除一个元素。 如果操作成功返回 true。
        deleteLast()：从双端队列尾部删除一个元素。如果操作成功返回 true。
        getFront()：从双端队列头部获得一个元素。如果双端队列为空，返回 -1。
        getRear()：获得双端队列的最后一个元素。 如果双端队列为空，返回 -1。
        isEmpty()：检查双端队列是否为空。
        isFull()：检查双端队列是否满了。

    示例：

    MyCircularDeque circularDeque = new MycircularDeque(3); // 设置容量大小为3
    circularDeque.insertLast(1);			        // 返回 true
    circularDeque.insertLast(2);			        // 返回 true
    circularDeque.insertFront(3);			        // 返回 true
    circularDeque.insertFront(4);			        // 已经满了，返回 false
    circularDeque.getRear();  				// 返回 2
    circularDeque.isFull();				        // 返回 true
    circularDeque.deleteLast();			        // 返回 true
    circularDeque.insertFront(4);			        // 返回 true
    circularDeque.getFront();				// 返回 4
 

 

    提示：

        所有值的范围为 [1, 1000]
        操作次数的范围为 [1, 1000]
        请不要使用内置的双端队列库。

    来源：力扣（LeetCode）
    链接：https://leetcode-cn.com/problems/design-circular-deque
    著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。

    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class MyCircularDeque
    {
        int[] array;
        int leftIndex = 0;
        int rightIndex = 0;
        int count = 0;


        /** Initialize your data structure here. Set the size of the deque to be k. */
        public MyCircularDeque(int k)
        {
            array = new int[k];
        }

        /** Adds an item at the front of Deque. Return true if the operation is successful. */
        public bool InsertFront(int value)
        {
            if(count>=array.Length)//数量满了
            {
                return false;
            }

            if(count==0)
            {
                array[leftIndex] = value;
                rightIndex = leftIndex;             
            }
            else if(count<array.Length)
            {
                if(leftIndex==0)
                {
                    leftIndex = array.Length - 1;                    
                }
                else
                {
                    leftIndex--;
                }
                array[leftIndex] = value;
            }
            
            count++;

            return true;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if (count >= array.Length)//数量满了
            {
                return false;
            }

            if(count==0)
            {
                array[leftIndex] = value;
                rightIndex = leftIndex;
            }
            else if (count < array.Length)
            {
                if(rightIndex==array.Length-1)
                {
                    rightIndex = 0;
                }
                else
                {
                    rightIndex++;
                }
                array[rightIndex] = value;
            }

            count++;

            return true;
        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if(count==0)
            {
                return false;
            }

            if(count==1)
            {         
                //do nothing
            }
            else
            {
                if(leftIndex==array.Length-1)
                {
                    leftIndex = 0;
                }
                else
                {
                    leftIndex++;
                }                
            }
            count--;
            return true;
        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if (count == 0)
            {
                return false;
            }

            if (count == 1)
            {
                //do nothing
            }
            else
            {
                if (rightIndex == 0)
                {
                    rightIndex = array.Length - 1;
                }
                else
                {
                    rightIndex--;
                }
            }
            count--;
            return true;
        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if(count==0)
            {
                return -1;
            }
            return array[leftIndex];
        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if(count==0)
            {
                return -1;
            }
            return array[rightIndex];
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return count == 0;
        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
            return count == array.Length;
        }
    }
}
