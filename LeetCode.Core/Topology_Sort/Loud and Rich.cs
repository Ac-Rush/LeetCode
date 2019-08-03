using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Topology_Sort
{

    /*
     *
 Explanation:
The description is not easy to understand.
In fact it's a basic dfs traversal problem.
For every people, call a sub function dfs to compare the quiet with others, who is richer than him.
Also we will note this answer to avoid repeated calculation.

Time Complexity:
O(richer.length),
Sub function dfs traverse every people only once, and every richer is traversed only one once.
     *
     */
    class Loud_and_Rich
    {
        Dictionary<int, List<int>> richer2 = new Dictionary<int, List<int>>();
        private int[] res;
        public int[] LoudAndRich(int[][] richer, int[] quiet)
        {
            int n = quiet.Length;
            res = new int[n];
            for (int i = 0; i < n; ++i) richer2[i]= new List<int>();
            foreach (int[] v in richer) richer2[v[1]].Add(v[0]);
            for (int i = 0; i < n; i++)
            {
                res[i] = -1;
            }
            for (int i = 0; i < n; i++) dfs(i, quiet);
            return res;
        }

        int dfs(int i, int[] quiet)
        {
            if (res[i] >= 0) return res[i];
            res[i] = i;
            foreach (int j in richer2[i]) if (quiet[res[i]] > quiet[dfs(j, quiet)]) res[i] = res[j];
            return res[i];
        }
        
    }
}
