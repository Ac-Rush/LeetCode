using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class _868__Binary_Gap
    {
        public int BinaryGap(int N)
        {
            int last = -1, ans = 0;
            for (int i = 0; i < 32; ++i)
                if (((N >> i) & 1) > 0)
                {
                    if (last >= 0)
                        ans = Math.Max(ans, i - last);
                    last = i;
                }

            return ans;
        }
    }
}
