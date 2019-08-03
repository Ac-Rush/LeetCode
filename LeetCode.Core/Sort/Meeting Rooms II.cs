using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    /// <summary>
    /// 重要题目
    /// </summary>
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


    class Meeting_Rooms_II_2
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
        /*
         * 
         * 
         * 
         
       |_____|  |_________|
           |_______|   |______|

  
  start|   |    |      |  
  end        |     |      |    |

    */
        public int MinMeetingRooms(Interval[] intervals)
        {
            int[] startTimes = new int[intervals.Length];
            int[] endTimes = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                startTimes[i] = intervals[i].start;
                endTimes[i] = intervals[i].end;
            }
            System.Array.Sort(startTimes);
            System.Array.Sort(endTimes);

            int rooms = 0;
            int endsItr = 0;
            for (int i = 0; i < startTimes.Length; i++)
            {  //每次 I移动都相当于开始了一个新的会议。
                if (startTimes[i] < endTimes[endsItr])  //  如果新的会议的开始时间小于 最早结束的时间， 那么会议室要加一
                    rooms++;
                else
                    endsItr++;   //否则， 就可以吧新的会议安排到这个结束的房间里，并且移动 endIndex.
            }
            return rooms;
        }
    }


    class Meeting_Rooms_II_3
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
        /*
         * 
         * 
         * 
         
       |_____|  |_________|
           |_______|   |______|

  
  start|   |    |      |  
  end        |     |      |    |

    */
        public int MinMeetingRooms(Interval[] intervals)
        {
            return 1;
        }
    }
}
