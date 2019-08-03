using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Custom_Sort_String
    {
        public string CustomSortString(string S, string T)
        {
            int[] count = new int[26];
            foreach (char c in T) { ++count[c - 'a']; }  // count each char in T.
            StringBuilder sb = new StringBuilder();
            foreach (char c in S)
            {
                while (count[c - 'a']-- > 0) { sb.Append(c); }    // sort chars both in T and S by the order of S.  //godd solution
            }
            for (char c = 'a'; c <= 'z'; ++c)
            {
                while (count[c - 'a']-- > 0) { sb.Append(c); }   // group chars in T but not in S.
            }
            return sb.ToString();
        }
    }
}
