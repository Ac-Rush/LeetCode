using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Find_K_Closest_Elements
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (arr[0] >= x)
            {
                return arr.Take(k).ToList();
            }
            if (arr[arr.Length - 1] <= x)
            {
                return arr.Skip(arr.Length - k).Take(k).ToList();
            }

            var start = 0;
            var end = arr.Length - 1;
            var index = System.Array.BinarySearch(arr, x);
            if (index < 0)
            {
                index = -index - 1;
            }
            var count = 0;
            var left = index - 1;
            var right = index;
            while (count < k)
            {
                if (left < 0)
                {
                    right++;
                    count++;
                    
                }else if (right >= arr.Length)
                {
                    left --;
                    count++;
                }
                else
                {
                    if (x - arr[left] <= arr[right] - x)
                    {
                        left--;
                        count++;
                    }
                    else
                    {
                        right++;
                        count++;
                    }
                }
                
            }
            return arr.Skip(left + 1).Take(k).ToList();
        }

        
    }
}
