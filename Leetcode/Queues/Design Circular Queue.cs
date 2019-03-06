using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Queues
{
    class MyCircularQueue
    {

        private int Size;
        private int WriteIndex = -1;
        private int ReadIndex = 0;
        private readonly int Capacity = -1;
        private readonly int[] m_InternalBufferArray;
        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            this.Capacity = k;
            m_InternalBufferArray = new int[k];
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            if (IsFull()) return false;

            WriteIndex = (WriteIndex + 1) % Capacity;
            m_InternalBufferArray[WriteIndex] = value;
            Size++;
            return true;
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            if (IsEmpty()) return false;

            ReadIndex = (ReadIndex + 1) % Capacity;
            Size--;

            return true;
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (IsEmpty()) return -1;

            return m_InternalBufferArray[ReadIndex];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (IsEmpty()) return -1;

            return m_InternalBufferArray[WriteIndex];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return (Size == 0);
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return (Size == Capacity);
        }
    }
}
