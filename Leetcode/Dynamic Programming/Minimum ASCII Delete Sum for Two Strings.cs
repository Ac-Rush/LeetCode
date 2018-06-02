using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Minimum_ASCII_Delete_Sum_for_Two_Strings
    {
        /*
         * 
         * LCA 问题 
         * 
         * 
         */
        public int MinimumDeleteSum(string s1, string s2)
        {
            var n1 = s1.Length + 1;
            var n2 = s2.Length + 1;
            var m = new int[n1, n2];
            m[0, 0] = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                m[i + 1, 0] = m[i, 0] + s1[i];
            }

            for (int i = 0; i < s2.Length; i++)
            {
                m[0, i + 1] = m[0, i] + s2[i];
            }

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        m[i + 1, j + 1] = m[i, j];
                    }
                    else
                    {
                        m[i + 1, j + 1] = Math.Min(m[i, j + 1] + s1[i], m[i + 1, j] + s2[j]);
                    }
                }
            }
            return m[n1 - 1, n2 - 1];
        }
    }
}
