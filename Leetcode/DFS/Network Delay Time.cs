using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Network_Delay_Time
    {

        /// <summary>
        /// Approach #2: Dijkstra's Algorithm [Accepted]
        /// </summary>
        /// <param name="times"></param>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int NetworkDelayTime(int[,] times, int N, int K)
        {
            var graph = new Dictionary<int, List<int[]>>();
            for (int i = 0; i < times.GetLength(0); i++)
            {
                if (!graph.ContainsKey(times[i, 0]))
                    graph[times[i, 0]] = new List<int[]>();
                graph[times[i, 0]].Add(new int[] { times[i, 2], times[i, 1] });
            }
            foreach (int node in graph.Keys.ToArray())
            {
                var array = graph[node].ToArray();
                System.Array.Sort<int[]>(array, (a, b) => a[0] - b[0]);
                graph[node] = array.ToList();
            }
            dist = new Dictionary<int, int>();
            for (int node = 1; node <= N; ++node)
                dist[node] = int.MaxValue;

            dist[K]= 0;
            bool[] seen = new bool[N + 1];

            while (true)
            {
                int candNode = -1;
                int candDist = int.MaxValue;
                for (int i = 1; i <= N; ++i)
                {
                    if (!seen[i] && dist[i] < candDist)
                    {
                        candDist = dist[i];
                        candNode = i;
                    }
                }

                if (candNode < 0) break;
                seen[candNode] = true;
                if (graph.ContainsKey(candNode))
                    foreach (int[] info in graph[candNode] )
                        dist[info[0]] = Math.Min(dist[info[0]], dist[candNode] + info[1]);
            }

            int ans = 0;
            foreach (int cand in dist.Values)
            {
                if (cand == int.MaxValue) return -1;
                ans = Math.Max(ans, cand);
            }
            return ans;
        }


        /// <summary>
        /// Time Complexity: O(N^N + E \log E)O(N^N) 
        /// </summary>
        Dictionary<int, int> dist;
        public int NetworkDelayTime2(int[,] times, int N, int K)
        {
            var graph = new Dictionary<int, List<int[]>>();
            for (int i = 0; i < times.GetLength(0); i++)
            {
                if (!graph.ContainsKey(times[i,0]))
                    graph[times[i, 0]] = new List<int[]>();
                graph[times[i, 0]].Add(new int[] { times[i, 2], times[i, 1] });
            }
            foreach (int node in graph.Keys.ToArray())
            {
                var array = graph[node].ToArray();
                System.Array.Sort<int[]>(array, (a,b) => a[0] - b[0]);
                graph[node] = array.ToList();
            }
            dist = new Dictionary<int, int>();
            for (int node = 1; node <= N; ++node)
                dist[node]= int.MaxValue;

            dfs(graph, K, 0);
            int ans = 0;
            foreach (int cand in dist.Values)
            {
                if (cand == int.MaxValue) return -1;
                ans = Math.Max(ans, cand);
            }
            return ans;
        }

        public void dfs(Dictionary<int, List<int[]>> graph, int node, int elapsed)
        {
            if (elapsed >= dist[node]) return;
            dist[node] = elapsed;
            if (graph.ContainsKey(node))
                foreach (int[] info in graph[node])
                    dfs(graph, info[1], elapsed + info[0]);
        }
    }
}
