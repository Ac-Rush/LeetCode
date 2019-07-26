using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class _4Sum_II
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var dict1 = new Dictionary<int, int>();
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    var sum = a + b;
                    if (!dict1.ContainsKey(sum))
                    {
                        dict1[sum] = 0;
                    }

                    dict1[sum]++;
                }
            }

            var count = 0;
            foreach (var c in C)
            {
                foreach (var d in D)
                {
                    var sum = -d - c;
                    if (dict1.ContainsKey(sum))
                    {
                        count += dict1[sum];
                    }
                }
            }
            return count;
        }
    }
}
