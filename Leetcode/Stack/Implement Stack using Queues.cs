using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Implement_Stack_using_Queues
    {
        Queue<int> qStack = new Queue<int>();

        // Push element x onto stack.
        public void Push(int x)
        {
            qStack.Enqueue(x);
            for (int i = 0; i < qStack.Count - 1; i++)
                qStack.Enqueue(qStack.Dequeue());
        }

        // Removes the element on top of the stack.
        public void Pop()
        {
            qStack.Dequeue();
        }

        // Get the top element.
        public int Top()
        {
            return qStack.Peek();
        }

        // Return whether the stack is empty.
        public bool Empty()
        {
            return qStack.Count == 0 ? true : false;
        }
    }
}
