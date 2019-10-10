using LeetCode.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.Lib.Graph
{
    class DFS_C
    {
        public HashSet<T> DFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>(); // hashset 去重

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();  //DFS 用 Stack
            stack.Push(start); // 入栈 start

            while (stack.Count > 0) //判空
            {
                var vertex = stack.Pop(); //弹出

                if (visited.Contains(vertex)) // 判断是否 visited
                    continue;

                visited.Add(vertex); //标胶 visited

                foreach (var neighbor in graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor); // 入栈邻接点
            }

            return visited;
        }
    }
}
