using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    using System;
    public class Interval
    {
      public int start;
      public int end;
      public Interval() { start = 0; end = 0; }
     public Interval(int s, int e) { start = s; end = e; }
  }
   public class Merge_Intervals
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static IList<Interval> Merge(IList<Interval> intervals)
        {
            var orderIntervals = intervals.OrderBy(item => item.start).ToArray(); //my bug intervals.OrderBy 不改变原数组顺序
            var result = new List<Interval>();
            for (int i = 0; i < orderIntervals.Length;)
            {
                var end = orderIntervals[i].end;
                int j = i +1;
                while (j < orderIntervals.Length && end >= orderIntervals[j].start)
                {
                    end =Math.Max(end, orderIntervals[j++].end) ; //my bug end 需要保持最大
                }
                result.Add(new Interval(orderIntervals[i].start, end));
                i = j;
            }
            return result;
        }
    }
}
