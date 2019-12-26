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
            //用hashset  嘎嘎
            var set = new HashSet< int>(candies);
            return Math.Min(set.Count, candies.Length/2);
        }
    }
}
