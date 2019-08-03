using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
    class Beautiful_Arrangement
    {
        int count = 0;

        public int CountArrangement(int N)
        {
            if (N == 0) return 0;
            Helper(N, 1, new int[N + 1]);
            return count;
        }

        private void Helper(int N, int pos, int[] used)
        {
            if (pos > N)
            {
                count++;
                return;
            }

            for (int i = 1; i <= N; i++)
            {
                if (used[i] == 0 && (i % pos == 0 || pos % i == 0))
                {
                    used[i] = 1;
                    Helper(N, pos + 1, used);
                    used[i] = 0;
                }
            }
        }
    }
}
