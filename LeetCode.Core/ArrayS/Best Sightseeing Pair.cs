using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.ArrayS
{
    class Best_Sightseeing_Pair
    {
        public int MaxScoreSightseeingPair(int[] A)
        {
            int res = 0, cur = 0;
            foreach (int a in A)
            {
                res = Math.Max(res, cur + a);
                cur = Math.Max(cur, a) - 1;
            }
            return res;
        }
    }
}
