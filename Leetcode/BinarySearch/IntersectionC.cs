using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class IntersectionC
    {
        public int[] Intersection(int[] nums1, int[] nums2)
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
                if (numbers.ContainsKey(n) && numbers[n] > 0)
                {
                    ret.Add(n);
                    numbers[n]--;
                }
            }
            return ret.ToArray();
        }
    }
}
