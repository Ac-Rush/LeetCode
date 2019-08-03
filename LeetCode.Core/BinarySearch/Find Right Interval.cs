using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class Interval
    {
      public int start;
     public int end;
     public Interval() { start = 0; end = 0; }
     public Interval(int s, int e) { start = s; end = e; }
  }

    class Find_Right_Interval
    {
        public int[] FindRightInterval(Interval[] intervals)
        {
            int[] result = new int[intervals.Length];
            int[] starts = new int[intervals.Length];
            var intervalMap = new SortedDictionary<int, int>();

            for (int i = 0; i < intervals.Length; ++i)
            {
                intervalMap[intervals[i].start] = i;
                starts[i] = intervals[i].start;
            }

            System.Array.Sort(starts);

            for (int i = 0; i < intervals.Length; i++)
            {
                int index = System.Array.BinarySearch(starts, intervals[i].end);
                if (index >= 0)
                {
                    result[i] = intervalMap[starts[index]];
                }
                else
                {
                    index = -index - 1;
                    if (index < intervals.Length)
                        result[i] = intervalMap[starts[index]];
                    else
                        result[i] = -1;
                }
            }

            return result;
        }
    }
}
