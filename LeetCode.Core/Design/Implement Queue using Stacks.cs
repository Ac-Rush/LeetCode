using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class MyQueue
    {
        Stack<int> input = new Stack<int>();
        Stack<int> output = new Stack<int>();
        /** Initialize your data structure here. */
        public MyQueue()
        {
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            input.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            Peek();
            return  output.Pop();
        }
        
        /** Get the front element. */
        public int Peek()
        {
            if (output.Count == 0)
            {//把所有的 input都导入到 output里面
                while (input.Count != 0)
                {
                    output.Push(input.Pop());
                }
            }
            return output.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            if (input.Count == 0 && output.Count == 0) return true;
            else return false;
        }
    }
}
