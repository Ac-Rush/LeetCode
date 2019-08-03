using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Greedy
{
    class Candy_
    {
        public int Candy(int[] ratings)
        {
            var candies = new int[ratings.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                candies[i] = 1;
            }

            for (int i = 1; i < candies.Length; i++)
            {// Scan from left to right, to make sure right higher rated child gets 1 more candy than left lower rated child
                if (ratings[i] > ratings[i - 1]) candies[i] = (candies[i - 1] + 1);
            }

            for (int i = candies.Length - 2; i >= 0; i--)
            {// Scan from right to left, to make sure left higher rated child gets 1 more candy than right lower rated child
                if (ratings[i] > ratings[i + 1]) candies[i] = Math.Max(candies[i], (candies[i + 1] + 1));
            }

            int sum = 0;
            foreach (int candy in candies)
                sum += candy;
            return sum;
        }
    }
}
