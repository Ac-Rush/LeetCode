using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Stack
{
    class Next_Greater_Element
    {
        private void printNGE(int [] arr)
        {
            Stack<int> s = new Stack<int>();
            int[] nge = new int[arr.Length];

            // iterate for rest of the elements  
            //从后向前来
            for (int i = arr.Length - 1; i >= 0; i--)
            {

                /* if stack is not empty, then  
                pop an element from stack.  
                If the popped element is smaller  
                than next, then  
                a) print the pair  
                b) keep popping while elements are  
                smaller and stack is not empty */
                if (s.Count > 0)
                {
                    while (s.Count > 0 && s.Peek() <= arr[i])
                    {
                        s.Pop();
                    }
                }
                nge[i] = s.Count == 0 ? -1 : s.Peek();
                s.Push(arr[i]);

            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " --> " + nge[i]);
            }
        }
    }
}
