using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Intersection_of_Two_Arrays_II
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {

            var numbers = new Dictionary<int, int>();
            foreach (var n in nums1)
            {
                if (!numbers.ContainsKey(n))
                {
                    numbers[n] = 0;
                }

                numbers[n]++;
            }
            var ret = new List<int>();
            foreach (var n in nums2)
            {
                if (numbers.ContainsKey(n))
                {
                    if (--numbers[n] == 0)
                    {
                        numbers.Remove(n);
                    }
                    ret.Add(n);
                }
            }
            return ret.ToArray();
        }
    }
}
