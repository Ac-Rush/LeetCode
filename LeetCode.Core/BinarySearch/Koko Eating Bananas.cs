using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// my solution 几乎一次过
    /// </summary>
    class Koko_Eating_Bananas
    {
        public int MinEatingSpeed(int[] piles, int H)
        {
            var min = 1;
            var max = piles.Max();
            while (min < max)
            {
                var mid = (min + max) / 2;
                if (CanEat(piles, H, mid))
                {
                    max = mid;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return min;
        }

        private bool CanEat(int[] piles, int H, int K)
        {
            var count = 0;
            foreach (var p in piles)
            {
                ///  count += p / K;  //my bug 得往上取整
                count += (p-1) / K + 1;
            }

            return count <= H;
        }
    }
}
