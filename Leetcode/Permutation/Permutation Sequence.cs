using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Permutation
{
    class Permutation_Sequence
    {
        public string GetPermutation(int n, int k)
        {
            string sb = "";
            List<int> n1 = new List<int>();
            k -= 1;
            for (int i = 1; i <= n; i++)
            {
                n1.Add(i);
            }
            for (int i = n; i > 0; i--)
            {
                int a = 1;
                for (int j = 1; j < i; j++)
                {
                    a *= j;
                }
                sb += n1[k / a].ToString();
                n1.Remove(n1[k / a]);
                k %= a;
            }
            return sb;
        }
    }
}
