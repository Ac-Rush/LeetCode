using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    public class Is_Graph_Bipartite
    {
        public static bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            int[] colors = new int[n];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = -1;
            }

            for (int i = 0; i < n; i++)
            {              //This graph might be a disconnected graph. So check each unvisited node.
                if (colors[i] == -1 && !validColor(graph, colors, 0, i))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool validColor(int[][] graph, int[] colors, int color, int node)
        {
            if (colors[node] != -1)
            {
                return colors[node] == color;
            }
            colors[node] = color;
            foreach (int next in graph[node])
            {
                if (!validColor(graph, colors, 1 - color, next))
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// wrong ans 都不在的时候不能随意分  不对
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite___Wrong(int[][] graph)
        {
            var setA = new HashSet<int>();
            var setB = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    var node = graph[i][j];
                    if ((setA.Contains(i) && setA.Contains(node)) || (setB.Contains(i) && setB.Contains(node)))
                    {
                        return false;
                    }
                    if (setA.Contains(i))
                    {
                        setB.Add(node);
                    }
                    else if (setB.Contains(i))
                    {
                        setA.Add(node);
                    }
                    else
                    {
                        if (setA.Contains(node))
                        {
                            setB.Add(i);
                        }
                        else
                        {
                            setA.Add(i);
                        }
                    }
                }
            }
            return true;
        }
    }
}
