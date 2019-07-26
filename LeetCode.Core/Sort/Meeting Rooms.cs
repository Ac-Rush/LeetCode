using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Meeting_Rooms
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
       /// <summary>
       /// my solution 一次过， 对数组按 start 排序
       /// </summary>
       /// <param name="intervals"></param>
       /// <returns></returns>
        public bool CanAttendMeetings(Interval[] intervals)
        {
            System.Array.Sort(intervals , (a,b ) => a.start.CompareTo(b.start));
         //   var temp = intervals.OrderBy(i => i.start).ToList();
            for (int i = 0; i < intervals.Length -1; i++)
            {
                if (intervals[i].end > intervals[i + 1].start)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
