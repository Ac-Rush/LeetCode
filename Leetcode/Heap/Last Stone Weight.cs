using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    class Last_Stone_Weight
    {
        public int LastStoneWeight(int[] stones)
        {
            var sorted = new SortedDictionary<int, int>();

            foreach (var stone in stones)
            {
                if (sorted.ContainsKey(stone)) sorted[stone]++;
                else sorted[stone] = 1;
            }

            while (sorted.Count >= 2)
            {

                var max = sorted.Last();
                sorted.Remove(max.Key);

                if (max.Value % 2 == 1)
                {
                    var next = sorted.Last();
                    if (next.Value == 1) sorted.Remove(next.Key);
                    else sorted[next.Key]--;

                    if (sorted.ContainsKey(max.Key - next.Key)) sorted[max.Key - next.Key]++;
                    else sorted[max.Key - next.Key] = 1;

                }
            }

            var first = sorted.First();
            return first.Value % 2 == 0 ? 0 : first.Key;
        }
    }
}
