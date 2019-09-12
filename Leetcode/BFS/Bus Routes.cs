using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Bus_Routes
    {
        /// <summary>
        /// 建图  +经典 BFS
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="S"></param>
        /// <param name="T"></param>
        /// <returns></returns>
        public int NumBusesToDestination(int[][] routes, int S, int T)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> q = new Queue<int>();
            var map = new Dictionary<int, HashSet<int>>();  // <stop, buses>
            int ret = 0;

            if (S == T) return 0;

            for (int i = 0; i < routes.Length; i++)
            {
                foreach (int station in routes[i])
                {
                    if (!map.ContainsKey(station))
                    {
                        map[station] = new HashSet<int>();
                    }
                    map[station].Add(i); 
                }
            }

            //经典 BFS
            q.Enqueue(S);
            while (q.Any())
            {
                var len = q.Count;
                ret++;
                while (len-- >0)
                {
                    int cur = q.Dequeue();
                    var buses = map[cur];
                    foreach (var bus in  buses)
                    {
                        if (visited.Contains(bus)) continue;
                        visited.Add(bus);
                        foreach (var station in routes[bus])  //遍历 bus的每一个车站
                        {
                            if (station == T) return ret;
                            q.Enqueue(station);
                        }
                    }
                }
            }
            return -1;
        }

    }
}
