using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Loud_and_Rich
    {
        List<int>[] graph;
        int[] answer;
        int[] quiet;
        public int[] LoudAndRich(int[][] richer, int[] quiet)
        {
            int N = quiet.Length;
            graph = new List<int>[N];
            answer = new int[N];
            this.quiet = quiet;

            for (int node = 0; node < N; ++node)
                graph[node] = new List<int>();

            foreach (int[] edge in richer)
                graph[edge[1]].Add(edge[0]);

            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = -1;
            }
            for (int node = 0; node < N; ++node)
                dfs(node);
            return answer;
        }
        public int dfs(int node)
        {
            if (answer[node] == -1)
            {
                answer[node] = node;
                foreach (int child in graph[node])
                {
                    int cand = dfs(child);
                    if (quiet[cand] < quiet[answer[node]])
                        answer[node] = cand;
                }
            }
            return answer[node];
        }
    }
}
