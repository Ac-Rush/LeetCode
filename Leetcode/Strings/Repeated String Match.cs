using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Repeated_String_Match
    {
        public int RepeatedStringMatch(string A, string B)
        {
            for (int i = 0, j = 0; i < A.Length; ++i)
            {
                for (j = 0; j < B.Length && A[(i + j) % A.Length] == B[j]; ++j) ;
                if (j == B.Length) return (i + j) / A.Length + ((i + j) % A.Length != 0 ? 1 : 0);
            }
            return -1;
        }
    }
}
