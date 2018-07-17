using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Output_Contest_Matches
    {
        public String FindContestMatch(int n)
        {
            String[] m = new String[n];
            for (int i = 0; i < n; i++)
            {
                m[i] =(i + 1).ToString();
            }

            while (n > 1)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    m[i] = "(" + m[i] + "," + m[n - 1 - i] + ")";
                }
                n /= 2;
            }

            return m[0];
        }
    }
}
