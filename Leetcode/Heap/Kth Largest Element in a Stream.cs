using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    class Kth_Largest_Element_in_a_Stream
    {
        MinIntHeap minHeap;
        int capacity;

        //Time complexity : O(n * log k)
        public KthLargest(int k, int[] nums)
        {
            capacity = k;
            minHeap = new MinIntHeap(k);
            for (int i = 0; i < nums.Length; i++)
            {
                Add(nums[i]);
            }
        }

        //Time complexity: O(log k)
        public int Add(int val)
        {
            if (minHeap.Size < capacity)
            {
                minHeap.Add(val);
            }
            else
            {
                if (val > minHeap.Peek())
                {
                    minHeap.Poll();
                    minHeap.Add(val);
                }
            }
            return minHeap.Peek();
        }
    }
}
