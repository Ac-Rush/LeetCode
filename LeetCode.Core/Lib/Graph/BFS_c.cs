using LeetCode.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.Lib.Graph
{
    class BFS_c
    {
        /// <summary>
        /// <see cref="DFS_C"/> 区别就是一个用了队列 一个用了栈
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public HashSet<T> BFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }
    }
}
