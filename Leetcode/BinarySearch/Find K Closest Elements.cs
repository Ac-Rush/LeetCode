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
                    
                }else if (right >= arr.Length)
                {
                    left --;
                }
                else
                {
                    if (x - arr[left] <= arr[right] - x)
                    {
                        left--;
                    }
                    else
                    {
                        right++;
                    }
                }
                count++;
            }
            return arr.Skip(left + 1).Take(k).ToList();
        }



        public static IList<int> FindClosestElements2(int[] arr, int k, int x)
        {
            var ans = new List<int>();
            var l = 0;
            var r = arr.Length - 1;
            while (l < r)
            {
                var m = (l + r) / 2;
                if (arr[m] >= x)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }
            var count = 0;
            var left = l - 1;
            var right = l;
            while (count < k)
            {
                if (left < 0)
                {
                    right++;
                }
                else if (right >= arr.Length)
                {
                    left--;
                }
                else
                {
                    if (x - arr[left] <= arr[right] - x)
                    {
                        left--;
                    }
                    else
                    {
                        right++;
                    }
                }
                count++;

            }
            return arr.Skip(left + 1).Take(k).ToList();
        }

    }
}
