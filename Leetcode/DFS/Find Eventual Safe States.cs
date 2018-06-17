using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Find_Eventual_Safe_States
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            int N = graph.Length;
            int[] color = new int[N];
            List<int> ans = new List<int>();

            for (int i = 0; i < N; ++i)
                if (dfs(i, color, graph))
                    ans.Add(i);
            return ans;
        }

        // colors: WHITE 0, GRAY 1, BLACK 2;
        public bool dfs(int node, int[] color, int[][] graph)
        {
            if (color[node] > 0)
                return color[node] == 2;

            color[node] = 1;
            foreach (int nei in  graph[node])
            {
                if (!dfs(nei, color, graph))
                    return false;
            }

            color[node] = 2;
            return true;
        }
    }
}
