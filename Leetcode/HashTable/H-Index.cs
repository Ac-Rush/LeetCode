using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class H_Index
    {
        public int HIndex(int[] citations)
        {
            var sort = citations.OrderByDescending(x => x).ToArray();
            var hIndex = 0;
            for (int i = 0; i < sort.Length; i++)
            {
                if (sort[i] > hIndex) //my bug was >=
                {
                    hIndex++;
                }
                else
                {
                    break;
                }
            }
            return hIndex;
        }

        public int hIndex2(int[] citations)
        {
            int n = citations.Length;
            int[] buckets = new int[n + 1];
            foreach (int c in citations)
           
            {
                if (c >= n)
                {
                    buckets[n]++;
                }
                else
                {
                    buckets[c]++;
                }
            }
            int count = 0;
            for (int i = n; i >= 0; i--)
            {
                count += buckets[i];
                if (count >= i)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}
