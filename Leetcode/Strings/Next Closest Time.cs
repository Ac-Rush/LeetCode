using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Next_Closest_Time_Simulation
    {
        static int[] mins = { 600, 60, 10, 1 };
        public String nextClosestTime(String time)
        {
            int colon = time.IndexOf(':');
            int cur = int.Parse(time.Substring(0, colon)) * 60 + int.Parse(time.Substring(colon + 1));
            char[] next = new char[4];
            for (int i = 1, d = 0; i <= 1440 && d < 4; i++)
            {
                int m = (cur + i) % 1440;
                for (d = 0; d < 4; d++)
                {
                    next[d] = (char)('0' + m / mins[d]); m %= mins[d];
                    if (time.IndexOf(next[d]) == -1) break;
                }
            }
            return new String(next, 0, 2) + ':' + new String(next, 2, 2);
        }
    }

    /// <summary>
    /// 4个位置循环凑
    /// </summary>
    class Next_Closest_Time_Simulation_2
    {
        public String nextClosestTime(String time)
        {
            int start = 60 * int.Parse(time.Substring(0, 2));
            start += int.Parse(time.Substring(3));
            int ans = start;
            int elapsed = 24 * 60;
            var allowed = new HashSet<int>();
            foreach (char c in time) if (c != ':')
                {
                    allowed.Add(c - '0');
                }

            foreach (int h1 in allowed) foreach (int h2 in allowed) if (h1 * 10 + h2 < 24)
                    {
                        foreach (int m1 in allowed) foreach (int m2 in allowed) if (m1 * 10 + m2 < 60)
                                {
                                    int cur = 60 * (h1 * 10 + h2) + (m1 * 10 + m2);
                                    int candElapsed = cur > start ? cur - start : cur + 24*60 - start;
                                    if (0 < candElapsed && candElapsed < elapsed)
                                    {
                                        ans = cur;
                                        elapsed = candElapsed;
                                    }
                                }
                    }

            return String.Format("{0:D2}:{1:D2}", ans / 60, ans % 60);
        }
    }

}
