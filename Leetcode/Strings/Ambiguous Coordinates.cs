using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Ambiguous_Coordinates
    {
        public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets)
        {
            int N = S.Length;
            int[] match = new int[N];
            for (int i = 0; i < match.Length; i++)
            {
                match[i] = -1;
            }

            int ix;
            for (int i = 0; i < indexes.Length; ++i)
            {
                ix = indexes[i];
                if (S.Substring(ix, sources[i].Length).Equals(sources[i]))
                    match[ix] = i;
            }

            StringBuilder ans = new StringBuilder();
            ix = 0;
            while (ix < N)
            {
                if (match[ix] >= 0)
                {
                    ans.Append(targets[match[ix]]);
                    ix += sources[match[ix]].Length;
                }
                else
                {
                    ans.Append(S[ix++]);
                }
            }
            return ans.ToString();
        }
    }
}
