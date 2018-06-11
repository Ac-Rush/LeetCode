using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Distribute_Candies
    {
        public int DistributeCandies(int[] candies)
        {
            var dict = new Dictionary<int, int>();
            foreach (var candy in candies)
            {
                if (!dict.ContainsKey(candy)) dict[candy] = 0;
                dict[candy]++;
            }
            return Math.Min(dict.Count, candies.Length/2);
        }
    }
}
