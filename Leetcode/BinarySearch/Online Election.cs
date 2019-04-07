using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Strings;

namespace Leetcode.BinarySearch
{
    public class TopVotedCandidate
    {

        Dictionary<int, int> m = new Dictionary<int,  int>();
        int[] time;
        /// <summary>
        /// 初始化，用m记录 某时刻的lead, 下面用binary seach 去找比扎个小的那个时刻
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="times"></param>
        public TopVotedCandidate(int[] persons, int[] times)
        {
            int n = persons.Length, lead = -1;
            Dictionary<int, int> count = new Dictionary<int, int>();
            time = times;
            for (int i = 0; i < n; ++i)
            {
                if (!count.ContainsKey(persons[i]))
                {
                    count[persons[i]] = 0;
                }

                count[persons[i]]++;
                if (i == 0 || count[persons[i]] >= count[lead]) lead = persons[i];
                m[times[i]]= lead;
            }
        }

        public int Q1(int t)
        {
            var l = 0;
            var h = time.Length -1;
            while (l <= h)
            {
                var mid = (l + h) / 2;
                if (time[mid] > t)
                {
                    h = mid -1;
                }
                else if(time[mid] < t)
                {
                    l = mid + 1;
                }else
                {
                    
                    return m[time[mid]];
                }
            }

            return m[time[h]];
        }
        public int Q2(int t)
        {
            var l = 0;
            var h = time.Length;
            while (l < h)
            {
                var mid = (l + h) / 2;
                if (time[mid] > t)
                {
                    h = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return m[time[l - 1]];
        }


        public int Q_(int t)
        {
            int i = System.Array.BinarySearch(time, t);
            return i < 0 ? m[time[-i - 2]] : m[time[i]];
        }
    }
}
