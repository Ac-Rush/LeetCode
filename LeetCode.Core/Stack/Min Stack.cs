using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    /// <summary>
    /// my solution
    /// </summary>
    class MinStack
    {
        private Stack<int> stack;
        private Stack<int> min;
        public MinStack()
        {
            stack = new Stack<int>();
            min = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (min.Count == 0 || x <= min.Peek())
            {
                min.Push(x);
            }
        }

        public void Pop()
        {
            var x =stack.Pop();
            if (x == min.Peek())
            {
                min.Pop();
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min.Peek();
        }
    }
}
