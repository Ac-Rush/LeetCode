using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    public class HitCounter
    {
        private int[] times;
        private int[] hits;
        /** Initialize your data structure here. */
        public HitCounter()
        {
            times = new int[300];
            hits = new int[300];
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp)
        {
            int index = timestamp % 300;
            if (times[index] != timestamp)
            {
                times[index] = timestamp;  //记录时间
                hits[index] = 1;
            }
            else
            {
                hits[index]++;
            }
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp)
        {
            int total = 0;
            for (int i = 0; i < 300; i++)
            {
                if (timestamp - times[i] < 300)
                {
                    total += hits[i];
                }
            }
            return total;
        }
    }
}
