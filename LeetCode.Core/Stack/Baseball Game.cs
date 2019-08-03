using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Baseball_Game
    {
        public int CalPoints(string[] ops)
        {
            Stack<int> stack = new Stack<int>();

            foreach (String op in ops)
            {
                if (op.Equals("+"))
                {
                    int top = stack.Pop();
                    int newtop = top + stack.Peek();
                    stack.Push(top);
                    stack.Push(newtop);
                }
                else if (op.Equals("C"))
                {
                    stack.Pop();
                }
                else if (op.Equals("D"))
                {
                    stack.Push(2 * stack.Peek());
                }
                else
                {
                    stack.Push(int.Parse(op));
                }
            }

            return stack.Sum(); ;
        }
    }
}
