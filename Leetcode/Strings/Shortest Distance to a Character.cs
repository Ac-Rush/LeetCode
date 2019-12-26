using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Shortest_Distance_to_a_Character
    {

        public int[] ShortestToChar(String S, char C)
        {
            int N = S.Length;
            int[] ans = new int[N];
            int prev = int.MinValue / 2;

            for (int i = 0; i < N; ++i)
            {
                if (S[i] == C) prev = i;
                ans[i] = i - prev;
            }

            prev = int.MaxValue / 2;
            for (int i = N - 1; i >= 0; --i)
            {
                if (S[i] == C) prev = i;
                ans[i] = Math.Min(ans[i], prev - i);
            }

            return ans;
        }
    }
}
