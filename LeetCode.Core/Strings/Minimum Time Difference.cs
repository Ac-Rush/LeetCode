using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Minimum_Time_Difference
    {
        /// <summary>
        /// Verbose Java Solution, Bucket
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(List<String> timePoints)
        {
            bool[] mark = new bool[24 * 60];
            foreach (String time in timePoints)
            {
                String[] t = time.Split(':');
                int h = int.Parse(t[0]);
                int m = int.Parse(t[1]);
                if (mark[h * 60 + m]) return 0;
                mark[h * 60 + m] = true;
            }

            int prev = 0, min = int.MaxValue;
            int first = int.MaxValue, last = int.MaxValue;
            for (int i = 0; i < 24 * 60; i++)
            {
                if (mark[i])
                {
                    if (first != int.MaxValue)
                    {
                        min = Math.Min(min, i - prev);
                    }
                    first = Math.Min(first, i);
                    last = Math.Max(last, i);
                    prev = i;
                }
            }

            min = Math.Min(min, (24 * 60 - last + first));

            return min;
        }


        /// <summary>
        ///  my solution 
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifferenceMy(IList<string> timePoints)
        {
            var mints = new List<int>();
            foreach (var time in timePoints)
            {
                var setments = time.Split(':');
                mints.Add(int.Parse(setments[0]) * 60 + int.Parse(setments[1]));
            }
            mints.Sort();

            var min = int.MaxValue;
            for (int i = 1; i < mints.Count; i++)
            {
                var diff = mints[i] - mints[i - 1];
                diff = Math.Min(diff, 24 * 60 - diff);
                min = Math.Min(min, diff);
            }
            min = Math.Min(mints.First() - mints.Last() + 24*60, min); /// mmy bug 是循环的
            return min;
        }
    }
}
