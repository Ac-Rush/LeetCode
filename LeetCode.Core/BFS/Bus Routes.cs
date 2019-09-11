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
            var ans = 0;
            HashSet<int> visited = new HashSet<int>();
            Queue<int> q = new Queue<int>();
            var map = new Dictionary<int, HashSet<int>>();  // <stop, buses>
            if (S == T) return 0;
            for (int i = 0; i < routes.Length; i++)
            {
                for (int j = 0; j < routes[i].Length; j++)
                {
                    if (!map.ContainsKey(routes[i][j]))
                    {
                        map[routes[i][j]] = new HashSet<int>();
                    }
                    map[routes[i][j]].Add(i);
                }
            }
            q.Enqueue(S);
            while (q.Any())
            {
                var count = q.Count;
                while (count-- > 0)
                {
                    var station = q.Dequeue();
                    if (station == T) return ans;
                    var buses = map[station];
                    foreach (int bus in buses)
                    {
                        if (visited.Contains(bus)) continue;
                        visited.Add(bus);
                        for (int j = 0; j < routes[bus].Length; j++)  //遍历 bus的每一个车站
                        {
                            q.Enqueue(routes[bus][j]);
                        }
                    }
                }
                ans++;
            }
            return -1;
        }

    }
}
