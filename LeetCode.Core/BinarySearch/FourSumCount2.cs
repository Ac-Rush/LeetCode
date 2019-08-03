using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class FourSumCount2
    {
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var sum2 = new Dictionary<int,int>();

            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    if (!sum2.ContainsKey(a + b))
                    {
                        sum2[a + b] = 1;
                    }
                    else
                    {
                        sum2[a + b]++;
                    }
                    
                }
            }
            var count = 0;
            foreach (var c in C)
            {
                foreach (var d in D)
                {
                    if (sum2.ContainsKey(-c - d))
                    {
                        count += sum2[-c - d];
                    }
                }   
            }
            return count;
        }

        /// <summary>
        /// resharper
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns></returns>
        public int FourSumCount2C(int[] A, int[] B, int[] C, int[] D)
        {
            var sum2 = new Dictionary<int, int>();

            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    if (!sum2.ContainsKey(a + b))
                    {
                        sum2[a + b] = 0;
                    }
                    sum2[a + b]++;
                }
            }
            return (from c in C from d in D where sum2.ContainsKey(-c - d) select sum2[-c - d]).Sum();
        }
    }
}
