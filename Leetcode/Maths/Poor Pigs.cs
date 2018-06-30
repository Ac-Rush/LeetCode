using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Poor_Pigs
    {
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            int status = minutesToTest / minutesToDie + 1;
            int num_of_pig = 0;
            while (Math.Pow(status, num_of_pig) < buckets) { num_of_pig++; }
            return num_of_pig;
        }
    }
}
