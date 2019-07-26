using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    /// <summary>
    /// my solution 一遍过
    /// </summary>
    class Capacity_To_Ship_Packages_Within_D_Days
    {
        public int ShipWithinDays(int[] weights, int D)
        {
            var min = weights.Max();
            var max = weights.Sum();
            while (min < max)
            {
                var mid = (min + max) / 2;
                if (CanShip(weights, D, mid))
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


        private bool CanShip(int[] weights, int D, int maxWeight)
        {
            var day = 1;
            var total = 0;
            foreach (var w in weights)
            {
                //if (w > maxWeight) return false;
                if (total + w> maxWeight)
                {
                    day++;
                    total =0;
                }

                total += w;
            }

            return day <= D;
        }
    }
}
