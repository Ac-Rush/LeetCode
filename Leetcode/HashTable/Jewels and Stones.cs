using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Jewels_and_Stones
    {
        public int NumJewelsInStones(string J, string S)
        {
            if (string.IsNullOrEmpty(J))
            {
                return 0;
            }
            var set = new int[256];
            foreach(var c in J)
            {
                set[c] =1;
            }

            var ans = 0;
            foreach (var c in S)
            {
                if (set[c] == 1)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
