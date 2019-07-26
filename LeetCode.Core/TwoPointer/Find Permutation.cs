using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.TwoPointer
{
    class Find_Permutation
    {
        public int[] FindPermutation(String s)
        {
            int[] res = new int[s.Length + 1];
            res[0] = 1;
            int i = 1;
            while (i <= s.Length)
            {
                res[i] = i + 1;
                int j = i;
                if (s[i - 1] == 'D')
                {
                    while (i <= s.Length && s[i - 1] == 'D')
                        i++;
                    for (int k = j - 1, c = i; k <= i - 1; k++, c--)
                    {
                        res[k] = c;
                    }
                }
                else
                    i++;
            }
            return res;
        }
    }
}
