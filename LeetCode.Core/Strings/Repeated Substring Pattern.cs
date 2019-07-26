using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Repeated_Substring_Pattern
    {
        public bool RepeatedSubstringPattern(string s)
        {
            int l = s.Length;
            for (int i = l / 2; i >= 1; i--)
            {
                if (l % i == 0)
                {
                    int m = l / i;
                    String subS = s.Substring(0, i);
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < m; j++)
                    {
                        sb.Append(subS);
                    }
                    if (sb.ToString().Equals(s)) return true;
                }
            }
            return false;
        }
    }
}
