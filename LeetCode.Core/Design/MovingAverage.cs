using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    /// <summary>
    /// my solution
    /// </summary>
    public class MovingAverage
    {
        private Queue<int> Queue;
        private int Sum;
        private int Size;
        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            Queue = new Queue<int>();
            Sum = 0;
            Size = size;
        }

        public double Next(int val)
        {
            if (Queue.Count < Size)
            {
                Sum += val;
                Queue.Enqueue(val);
                return (double) Sum/Queue.Count;
            }
            else
            {
                var last = Queue.Dequeue();
                Sum = Sum - last + val;
                Queue.Enqueue(val);
                return (double)Sum / Queue.Count;
            }
        }
    }
}
