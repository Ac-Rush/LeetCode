using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    class Redundant_Connection_II
    {
       public class OrbitResult
        {
            public int node;
            public HashSet<int> seen;

           public OrbitResult(int n, HashSet<int> s)
            {
                node = n;
                seen = s;
            }
        }

        HashSet<int> seen = new HashSet<int>();
        int MAX_EDGE_VAL = 1000;
        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            int N = edges.GetLength(0);
            Dictionary<int, int> parent = new Dictionary<int, int>();
            List<int[]> candidates = new List<int[]>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (parent.ContainsKey(edges[i,1]))
                {
                    candidates.Add(new int[] { parent[edges[i,1]], edges[i, 1]});
                    candidates.Add(new []{ edges[i, 0], edges[i, 1] });
                }
                else
                {
                    parent[edges[i, 1]] = edges[i, 0];
                }
            }

            int root = orbit(1, parent).node;
            if (candidates.Count == 0)
            {
               var cycle = orbit(root, parent).seen;
                int[] ans = new int[] { 0, 0 };
                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    if (cycle.Contains(edges[i,0]) && cycle.Contains(edges[i,1]))
                    {
                        ans = new[] { edges[i, 0], edges[i, 1] };
                    }
                }
                return ans;
            }

            var children = new Dictionary<int, List<int>>();
            foreach (int v in parent.Keys)
            {
                int pv = parent[v];
                if (!children.ContainsKey(pv))
                    children[pv] = new List<int>();
                children[pv].Add(v);
            }

            var seen = new bool[N + 1];
            seen[0] = true;
            Stack<int> stack = new Stack<int>();
            stack.Push(root);
            while (stack.Any())
            {
                int node = stack.Pop();
                if (!seen[node])
                {
                    seen[node] = true;
                    if (children.ContainsKey(node))
                    {
                        foreach (int c in children[node])
                            stack.Push(c);
                    }
                }
            }
            foreach (var b in seen) if (!b)
                    return candidates[0];
            return candidates[1];
        }
        public OrbitResult orbit(int node, Dictionary<int, int> parent)
        {
            HashSet<int> seen = new HashSet<int>();
            while (parent.ContainsKey(node) && !seen.Contains(node))
            {
                seen.Add(node);
                node = parent[node];
            }
            return new OrbitResult(node, seen);
        }
    }
}
