using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Longest_Harmonious_Subsequence
    {
        public int FindLHS(int[] nums)
        {
            var dic = new Dictionary<int,int>();
            foreach (var n in nums)
            {
                if (!dic.ContainsKey(n))
                {
                    dic[n] = 0;
                }
                dic[n]++;
            }
            var max = 0;
            foreach (var num in nums)
            {
                if (dic.ContainsKey(num + 1))
                {
                    var curt = dic[num]+ dic[num + 1];
                    max = Math.Max(max, curt);
                }
            }
            return max;
        }
    }
}
