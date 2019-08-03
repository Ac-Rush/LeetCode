using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Greedy
{
    class Partition_Labels
    {
        public IList<int> PartitionLabels(string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return null;
            }
            List<int> list = new List<int>();
            int[] map = new int[26];  // record the last index of the each char

            for (var i = 0; i < S.Length; i++)
            {
                map[S[i] - 'a'] = i;
            }
            // record the end index of the current sub string
            int last = 0;
            int start = 0;
            for (int i = 0; i < S.Length; i++)
            {
                last = Math.Max(last, map[S[i] - 'a']);
                if (last == i)
                {
                    list.Add(last - start + 1);
                    start = last + 1;
                }
            }
            return list;
        }
    }
}
