using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Maximize_Distance_to_Closest_Person
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxDistToClosest(int[] seats)
        {
            var max = 0;
            var seeOne = false;
            var count = 0;
            var lastI = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 0)
                {
                    count ++;
                }
                else
                {
                    if (!seeOne)
                    {
                        max = Math.Max(max, i - lastI);
                        seeOne = true;
                    }
                    else
                    {
                        max = Math.Max(max, (i - lastI +1)/2 ); //my bug was : max = Math.Max(max, (i - lastI )/2 +1 );
                    }
                    lastI = i + 1;
                }
            }
            max = Math.Max(max, seats.Length - lastI);
            return max;
        }
    }
}
