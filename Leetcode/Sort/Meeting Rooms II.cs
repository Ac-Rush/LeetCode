using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Meeting_Rooms_II
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
        public int MinMeetingRooms(Interval[] intervals)
        {
            if (null == intervals) return 0;
            if (intervals.Length <= 1) return intervals.Length;

            int[] startTimes = new int[intervals.Length];
            int[] endTimes = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                Interval curr = intervals[i];
                startTimes[i] = curr.start;
                endTimes[i] = curr.end;
            }
            System.Array.Sort(startTimes);
            System.Array.Sort(endTimes);

            int minMeetingRooms = 0;
            int endTimesIterator = 0;
            for (int i = 0; i < startTimes.Length; i++)
            {
                minMeetingRooms++;       //Increment the room for the current meeting that is starting.
                                         //Check if startTime of current meeting is after endTime of meeting that is suppose to end first.
                if (startTimes[i] >= endTimes[endTimesIterator])
                {
                    minMeetingRooms--;   //since one meeting ended, a room got empty.
                    endTimesIterator++;  //move to the next endTime.
                }
            }
            return minMeetingRooms;
        }
    }
}
