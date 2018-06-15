using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    /// <summary>
    /// Approach #2: Boundary Count [Accepted]
    /// </summary>
    class MyCalendarTwo
    {
        private readonly SortedDictionary<int, int> _delta;
        /// </summary>
        public MyCalendarTwo()
        {
            _delta = new SortedDictionary<int, int>();
        }

        public bool Book(int start, int end)
        {
            AddOrUpdate(start, 1);
            AddOrUpdate(end, -1);
            var count = 0;
            foreach (var item in _delta.Values)
            {
                count += item;
                if (count >= 3)
                {
                    AddOrUpdate(start, -1);
                    AddOrUpdate(end, 1);
                    if (_delta[start] == 0)
                        _delta.Remove(start);
                    return false;
                }
            }
            return true;
        }

        public void AddOrUpdate(int pos, int num)
        {
            if (!_delta.ContainsKey(pos))
            {
                _delta[pos] = 0;
            }
            _delta[pos] += num;
        }
    }


    class MyCalendarTwo2
    {
        List<int[]> calendar;
        List<int[]> overlaps;   //已经 dobule booked
        /// </summary>
        public MyCalendarTwo2()
        {
            overlaps = new List<int[]>();
            calendar = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            foreach (int[] iv in overlaps)
            {
                if (iv[0] < end && start < iv[1]) return false;
            }
            foreach (int[] iv in calendar)
            {
                if (iv[0] < end && start < iv[1])
                    overlaps.Add(new int[] { Math.Max(start, iv[0]), Math.Min(end, iv[1]) });
            }
            calendar.Add(new int[] { start, end });
            return true;
        }
    }
}
