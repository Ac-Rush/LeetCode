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
            HashSet<int> visited = new HashSet<int>();// 这个是对bus去重
            Queue<int> q = new Queue<int>();
            var map = new Dictionary<int, HashSet<int>>();  // <stop, buses>
            if (S == T) return 0;
            for (int i = 0; i < routes.Length; i++)
            {
                foreach(var stat in routes[i])
                {
                    if (!map.ContainsKey(stat))
                    {
                        map[stat] = new HashSet<int>();
                    }
                    map[stat].Add(i);
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
                        foreach(var stat in routes[bus])//遍历 bus的每一个车站
                        {
                            q.Enqueue(stat);
                        }
                    }
                }
                ans++; // BFS 下一步
            }
            return -1;
        }

    }
}
