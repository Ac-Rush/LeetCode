using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Shuffle_an_Array
    {
        private int[] nums;
        private Random random;
        public Shuffle_an_Array(int[] nums)
        {
            this.nums = nums;
            random = new Random();
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return nums;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            if (nums == null) return null;
            int[] a = (int[])nums.Clone();
            for (int j = 1; j < a.Length; j++)
            {
                int i = random.Next(j + 1);
                swap(a, i, j);
            }
            return a;
        }
        private void swap(int[] a, int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
