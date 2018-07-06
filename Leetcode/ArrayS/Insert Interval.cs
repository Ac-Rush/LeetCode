using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Insert_Interval
    {
        public class Interval
        {
            public int start;
            public int end;

            public Interval()
            {
                start = 0;
                end = 0;
            }

            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            var ans = new List<Interval>();
            int i = 0;
            // add all the intervals ending before newInterval starts
            //第一步， 添加newInterval 之前的 intervals
            while (i < intervals.Count && intervals[i].end < newInterval.start)
                ans.Add(intervals[i++]);

            // merge all overlapping intervals to one considering newInterval
            //第二部 添加 交叉的
            while (i < intervals.Count && intervals[i].start <= newInterval.end)
            {
                newInterval = new Interval( // we could mutate newInterval here also
                        Math.Min(newInterval.start, intervals[i].start),
                        Math.Max(newInterval.end, intervals[i].end));
                i++;
            }
            ans.Add(newInterval); // add the union of intervals we got

            //第三部 ，添加后面的
            while (i < intervals.Count) ans.Add(intervals[i++]);

            return ans;
        }
    }
}
