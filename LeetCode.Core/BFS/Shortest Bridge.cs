
using System.Collections.Generic;

namespace LeetCode.Core.BFS
{
    /// <summary>
    /// Tag: BFS DFS 经典代码
    /// </summary>
    class Shortest_Bridge
    {
        public int ShortestBridge(int[][] A)
        {
            int m = A.Length, n = A[0].Length;
            var visited = new bool[m,n];
            var dirs = new int[][] { new int[]{ 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
            Queue<int[]> q = new Queue<int[]>();
            bool found = false;
            // 1. dfs to find an island, mark it in `visited`
            //找到并标记第一个岛，并把第一个岛的每个坐标入队
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i][j] == 1)
                    {
                        dfs(A, visited, q, i, j, dirs);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            // 2. bfs to expand this island， BFS 外探搜索
            int step = 0;
            while (q.Count>0)
            {
                int size = q.Count;
                while (size-- > 0)
                {
                    int[] cur = q.Dequeue();
                    foreach (int[] dir in dirs)
                    {
                        int i = cur[0] + dir[0];
                        int j = cur[1] + dir[1];
                        if (i >= 0 && j >= 0 && i < m && j < n && !visited[i,j])
                        {
                            if (A[i][j] == 1)
                            {
                                return step;
                            }
                            q.Enqueue(new int[] { i, j });
                            visited[i,j] = true;
                        }
                    }
                }
                step++;
            }
            return -1;
        }
        // DFS 
        private void dfs(int[][] A, bool[,] visited, Queue<int[]> q, int i, int j, int[][] dirs)
        {
            if (i < 0 || j < 0 || i >= A.Length || j >= A[0].Length || visited[i,j] || A[i][j] == 0)
            {
                return;
            }
            visited[i,j] = true;
            q.Enqueue(new int[] { i, j });
            foreach (int[] dir in dirs)
            {
                dfs(A, visited, q, i + dir[0], j + dir[1], dirs);
            }
        }
    }
}
