using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Reorganize_String
    {
        public string ReorganizeString(string S)
        {
            int N = S.Length;
            int[] counts = new int[26];
            foreach (var c in S)
            {
                counts[c - 'a'] += 100;
            }
            for (int i = 0; i < 26; ++i) counts[i] += i;
            //Encoded counts[i] = 100*(actual count) + (i)
            System.Array.Sort(counts);

            char[] ans = new char[N];
            int t = 1;
            foreach (var code in counts)
            {
                int ct = code / 100;
                char ch = (char)('a' + (code % 100));
                if (ct > (N + 1) / 2) return "";
                for (int i = 0; i < ct; ++i)
                {
                    if (t >= N) t = 0;
                    ans[t] = ch;
                    t += 2;
                }
            }

            return new string(ans);

        }
    }
}
