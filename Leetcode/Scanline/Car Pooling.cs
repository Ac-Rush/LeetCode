using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Scanline
{
    class Car_Pooling
    {
        /// <summary>
        /// 扫描线算法
        /// </summary>
        /// <param name="trips"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public bool CarPooling(int[][] trips, int capacity)
        {
            var stops = new SortedDictionary<int, int>();
            foreach (var trip in trips)
            {
                stops[trip[1]] = stops.ContainsKey(trip[1]) ? trip[0] + stops[trip[1]] : trip[0];
                stops[trip[2]] = stops.ContainsKey(trip[2]) ?  stops[trip[2]] - trip[0] : -trip[0];
            }
            var max = 0;
            foreach (var key in stops.Keys)
            {
                max += stops[key];
                if (max > capacity) return false;
            }
            return true;
        }
    }
}
