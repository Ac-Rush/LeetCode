using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{

    /// <summary>
    /// DFS O(N^2)
    /// </summary>
    public class Redundant_Connection_0
    {
        HashSet<int> seen = new HashSet<int>();
        int MAX_EDGE_VAL = 1000;
        public int[] FindRedundantConnection(int[,] edges)
        {
            //定义图
            List<int>[] graph = new List<int>[MAX_EDGE_VAL + 1];
            for (int i = 0; i <= MAX_EDGE_VAL; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                seen.Clear();
                if (graph[edges[i, 0]].Any() && graph[edges[i, 1]].Any() &&
                        HasPath(graph, edges[i, 0], edges[i, 1]))
                {
                    return new[] { edges[i, 0], edges[i, 1] };
                }
                graph[edges[i, 0]].Add(edges[i, 1]);
                graph[edges[i, 1]].Add(edges[i, 0]);
            }
            return null;
        }
        public bool HasPath(List<int>[] graph, int source, int target)
        {
            if (!seen.Contains(source))
            {
                seen.Add(source);
                if (source == target) return true;
                foreach (int nei in graph[source])
                {
                    if (HasPath(graph, nei, target)) return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Approach #2: Union-Find [Accepted]
    /// Time Complexity: O(N\alpha(N)) \approx O(N)O(Nα(N))≈O(N), 
    /// </summary>
    class Redundant_Connection_1
    {
        int MAX_EDGE_VAL = 1000;
        public int[] FindRedundantConnection(int[,] edges)
        {
            //1 定义图，  list<int> 的数组， 坐标是起点， 数组是neighbor
            DSU dsu = new DSU(MAX_EDGE_VAL + 1);
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (!dsu.union(edges[i, 0], edges[i, 1])) return   new[] { edges[i, 0], edges[i, 1] };
            }
            return null;
        }
        //Disjoint Set Union 
        public class DSU
        {
            int[] parent;
            int[] rank;

            public DSU(int sizeN)
            {
                parent = new int[sizeN];
                for (int i = 0; i < sizeN; i++) parent[i] = i;
                rank = new int[sizeN];
            }

            //dsu.find(node x), which outputs a unique id so that two nodes have the same id if and only if they are in the same connected component, and:
            public int find(int x)
            {
                if (parent[x] != x) parent[x] = find(parent[x]);// 这个就是图2，parent 就是它自己 就找到了根 
                return parent[x];
            }
            //dsu.union(node x, node y), which draws an edge (x, y) in the graph, connecting the components with id find(x) and find(y) together.
            /// <summary>
            /// Merges the sets represented by this node and the other node into a single set.
            /// Returns whether or not the nodes were disjoint before the union operation (i.e. if the operation had an effect).
            /// </summary>
            /// <returns>True when the union had an effect, false when the nodes were already in the same set.</returns>
            public bool union(int x, int y)
            {
                int px = find(x), py = find(y);
                if (px == py)  //如果相等，在一个联通增量里
                {
                    return false;
                }

                //插入并调整节点
                if (rank[px] < rank[py])
                {
                    parent[px] = py;
                }
                else if (rank[px] > rank[py])
                {
                    parent[py] = px;
                }
                else
                {
                    parent[py] = px;
                    rank[px]++;
                }
                return true;
            }
        }
    }
}
