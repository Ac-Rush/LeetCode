using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Topology_Sort
{

    /// <summary>
    /// my solution ，一次过
    /// </summary>
    class Find_Eventual_Safe_States
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            var ans = new  List<int>();
            var n = graph.Length;
            var outDegree = new int[n];
            var inEdge = new Dictionary<int, List<int>>();
            var queue = new Queue<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                outDegree[i] = graph[i].Length;
                foreach (var dest in graph[i])
                {
                    if (!inEdge.ContainsKey(dest))
                    {
                        inEdge[dest] = new List<int>();
                    }
                    inEdge[dest].Add(i);
                }
            }

            for (int i = 0; i < outDegree.Length; i++)
            {
                if (outDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var dest = queue.Dequeue();
                ans.Add(dest);
                if (inEdge.ContainsKey(dest))
                {
                    foreach (var inNode in inEdge[dest])
                    {
                        if (--outDegree[inNode] == 0)
                        {
                            queue.Enqueue(inNode);
                        }
                    }
                }
            }

            return ans.OrderBy(i => i).ToList();
        }
    }
}
