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
                for (int j = 0; j < routes[i].Length; j++)
                {
                    if (!map.ContainsKey(routes[i][j]))
                    {
                        map[routes[i][j]] = new HashSet<int>();
                    }
                    map[routes[i][j]].Add(i); 
                }
            }

            //经典 BFS
            q.Enqueue(S);
            while (q.Any())
            {
                int len = q.Count;
                ret++;
                for (int i = 0; i < len; i++)
                {
                    int cur = q.Dequeue();
                    var buses = map[cur];
                    foreach (int bus in  buses)
                    {
                        if (visited.Contains(bus)) continue;
                        visited.Add(bus);
                        for (int j = 0; j < routes[bus].Length; j++)  //遍历 bus的每一个车站
                        {
                            if (routes[bus][j] == T) return ret;
                            q.Enqueue(routes[bus][j]);
                        }
                    }
                }
            }
            return -1;
        }

    }
}
