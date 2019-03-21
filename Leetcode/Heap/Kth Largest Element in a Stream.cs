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

    public class KthLargest
    {
        private int[] heap;

        public KthLargest(int k, int[] nums)
        {
            heap = new int[k];

            for (int i = 0; i < k; i++)
                heap[i] = i < nums.Length ? nums[i] : int.MinValue;

            for (int i = k / 2; i >= 0; i--)
                HeapifyDown(i);

            for (int i = k; i < nums.Length; i++)
                Add(nums[i]);
        }

        public int Add(int val)
        {
            if (val > heap[0])
            {
                heap[0] = val;
                HeapifyDown(0);
            }

            return heap[0];
        }

        private void HeapifyDown(int index)
        {
            int left = index * 2 + 1;
            int right = left + 1;

            int small = index;

            if (left < heap.Length && heap[left] < heap[small])
                small = left;

            if (right < heap.Length && heap[right] < heap[small])
                small = right;

            if (small != index)
            {
                Swap(heap, index, small);
                HeapifyDown(small);
            }
        }

        private void Swap(int[] arr, int left, int right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
