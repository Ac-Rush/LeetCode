using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class The_Maze_DFS
    {
        public bool HasPath(int[,] maze, int[] start, int[] destination)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            return DFS(maze, start, destination, visited);
        }

        private bool DFS(int[,] maze, int[] start, int[] destination, bool[,] visited)
        {
            if (visited[start[0],start[1]])
                return false;
            if (start[0] == destination[0] && start[1] == destination[1])
                return true;
            visited[start[0], start[1]] = true;
            int r = start[1] + 1, l = start[1] - 1, u = start[0] - 1, d = start[0] + 1;
            while (r < maze.GetLength(1) && maze[start[0],r] == 0) // right
                r++;
            if (DFS(maze, new int[] { start[0], r - 1 }, destination, visited))
                return true;
            while (l >= 0 && maze[start[0],l] == 0) //left
                l--;
            if (DFS(maze, new int[] { start[0], l + 1 }, destination, visited))
                return true;
            while (u >= 0 && maze[u,start[1]] == 0) //up
                u--;
            if (DFS(maze, new int[] { u + 1, start[1] }, destination, visited))
                return true;
            while (d < maze.GetLength(0) && maze[d,start[1]] == 0) //down
                d++;
            if (DFS(maze, new int[] { d - 1, start[1] }, destination, visited))
                return true;
            return false;
        }
    }

    class The_Maze_BFS
    {
        public bool HasPath(int[,] maze, int[] start, int[] destination)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            var dirs = new int[,] { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(start);
            visited[start[0],start[1]] = true;
            while (queue.Any())
            {
                int[] s = queue.Dequeue();
                if (s[0] == destination[0] && s[1] == destination[1])
                    return true;
                for (int i = 0 ; i < dirs.GetLength(0) ; i++)
                {
                    int x = s[0] + dirs[i,0];
                    int y = s[1] + dirs[i, 1];
                    while (x >= 0 && y >= 0 && x < maze.GetLength(0) && y < maze.GetLength(1) && maze[x,y] == 0)
                    {
                        x += dirs[i, 0];
                        y += dirs[i, 1];
                    }
                    if (!visited[x - dirs[i, 0],y - dirs[i, 1]])
                    {
                        queue.Enqueue(new int[] { x - dirs[i, 0], y - dirs[i, 1] });
                        visited[x - dirs[i, 0], y - dirs[i, 1]] = true;
                    }
                }
            }
            return false;
        }

        private bool DFS(int[,] maze, int[] start, int[] destination, bool[,] visited)
        {
            if (visited[start[0], start[1]])
                return false;
            if (start[0] == destination[0] && start[1] == destination[1])
                return true;
            visited[start[0], start[1]] = true;
            int r = start[1] + 1, l = start[1] - 1, u = start[0] - 1, d = start[0] + 1;
            while (r < maze.GetLength(1) && maze[start[0], r] == 0) // right
                r++;
            if (DFS(maze, new int[] { start[0], r - 1 }, destination, visited))
                return true;
            while (l >= 0 && maze[start[0], l] == 0) //left
                l--;
            if (DFS(maze, new int[] { start[0], l + 1 }, destination, visited))
                return true;
            while (u >= 0 && maze[u, start[1]] == 0) //up
                u--;
            if (DFS(maze, new int[] { u + 1, start[1] }, destination, visited))
                return true;
            while (d < maze.GetLength(0) && maze[d, start[1]] == 0) //down
                d++;
            if (DFS(maze, new int[] { d - 1, start[1] }, destination, visited))
                return true;
            return false;
        }
    }
}
