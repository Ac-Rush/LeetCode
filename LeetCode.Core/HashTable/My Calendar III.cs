using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class MyCalendarThree
    {
        private readonly SortedDictionary<int, int> _delta;
        private int _maxRoom;
        /// </summary>
        public MyCalendarThree()
        {
            _delta = new SortedDictionary<int, int>();
            _maxRoom = 0;
        }

        public int Book(int start, int end)
        {
            AddOrUpdate(start, 1);
            AddOrUpdate(end, -1);
            var count = 0;
            foreach (var item in _delta.Values)
            {
                count += item;
                _maxRoom = Math.Max(_maxRoom, count); //bug, was out of foreach
            }
          
            return _maxRoom;
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
}
