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
            //第二部 添加 交叉的， 
            while (i < intervals.Count && intervals[i].start <= newInterval.end)
            {
                //一个一个吞噬，生成新的 newInterval
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


    class Insert_Interval2
    {
        /// <summary>
        /// 分成三部分做
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int start = newInterval[0], end = newInterval[1];
            var ans = new List<int[]>();
            int i = 0;
            while (i < intervals.Length && intervals[i][1] < newInterval[0])
                ans.Add(intervals[i++]);
            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            ans.Add(newInterval);
            while (i < intervals.Length) ans.Add(intervals[i++]);

            return ans.ToArray();
        }
    }
}
