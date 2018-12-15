using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Tree;

namespace Leetcode.Array
{
    class Heaters
    {
        /*
         *
         * The idea is to leverage decent Arrays.binarySearch() function provided by Java.

For each house, find its position between those heaters (thus we need the heaters array to be sorted).
Calculate the distances between this house and left heater and right heater, get a MIN value of those two values. Corner cases are there is no left or right heater.
Get MAX value among distances in step 2. It's the answer.
Time complexity: max(O(nlogn), O(mlogn)) - m is the length of houses, n is the length of heaters.
         */
        public int FindRadius(int[] houses, int[] heaters)
        {
            System.Array.Sort(heaters);
            int result = int.MinValue;

            foreach (var house in houses)
            {
                int index = System.Array.BinarySearch(heaters, house);
                if (index < 0)
                {
                    index = -(index + 1);
                }
                // 左边暖气的距离
                int dist1 = index - 1 >= 0 ? house - heaters[index - 1] : int.MaxValue;
                //右边暖气的距离 
                int dist2 = index < heaters.Length ? heaters[index] - house : int.MaxValue;
                
                result = Math.Max(result, Math.Min(dist1, dist2));
            }

            return result;
        }
    }
}
