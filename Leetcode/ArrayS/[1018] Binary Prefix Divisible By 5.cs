using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class _1018__Binary_Prefix_Divisible_By_5
    {
        public IList<bool> PrefixesDivBy5(int[] A)
        {
            var ans = new List<bool>();
            var rest = 0;
            foreach (var n in A)
            {
                rest = rest * 2 + n;
                ans.Add(rest % 5 == 0);
                rest %= 5;
            }
            return ans;
        }
    }
}
