using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Find_the_Difference
    {
        public char FindTheDifference(string s, string t)
        {
            char ans = (char)0;
            foreach (var c in s)
            {
                ans ^= c;
            }
            foreach (var c in t)
            {
                ans ^= c;
            }
            return ans;
        }
    }
}
