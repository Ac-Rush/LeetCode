using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class _4_Keys_Keyboard
    {

        public int MaxADP(int N)
        {
            int[] best = new int[N + 1];
            for (int k = 1; k <= N; ++k)
            {
                best[k] = best[k - 1] + 1;
                for (int x = 0; x < k - 1; ++x)
                    best[k] = Math.Max(best[k], best[x] * (k - x - 1));
            }
            return best[N];
        }

        public int MaxA(int N)
        {
            int[] best = new int[]{0, 1, 2, 3, 4, 5, 6, 9, 12,
                               16, 20, 27, 36, 48, 64, 81};
            int q = N > 15 ? (N - 11) / 5 : 0;
            return best[N - 5 * q] << 2 * q;
        }
    }
}
