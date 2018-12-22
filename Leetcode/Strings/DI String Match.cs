using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class DI_String_Match
    {
        public int[] DiStringMatch(String S)
        {
            int n = S.Length, left = 0, right = n;
            int[] res = new int[n + 1];
            for (int i = 0; i < n; ++i)
                res[i] = S[i] == 'I' ? left++ : right--;
            res[n] = left;
            return res;
        }
    }
}