using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class findRadiusC
    {
        public static int findRadius(int[] houses, int[] heaters)
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
                int dist1 = index - 1 >= 0 ? house - heaters[index - 1] : int.MaxValue;
                int dist2 = index < heaters.Length ? heaters[index] - house : int.MaxValue;

                result = Math.Max(result, Math.Min(dist1, dist2));
            }

            return result;
        }

        public static int TestBinarySearch(int[] array, int target)
        {
            return System.Array.BinarySearch(array, target);
        }
    }
}
