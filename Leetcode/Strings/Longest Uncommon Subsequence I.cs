using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Longest_Uncommon_Subsequence_I
    {
        public int FindLUSlength(string a, string b)
        {
            if (a.Equals(b))
                return -1;
            return Math.Max(a.Length, b.Length);
        }
    }
}
