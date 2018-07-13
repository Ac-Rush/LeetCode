using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class The_Maze_DFS
    {
        int[,] dirs = new int[,] { { 0, 1 }, { 0, -1 }, {1,0}, {-1,0} };
        public bool HasPath(int[,] maze, int[] start, int[] destination)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            return DFS(maze, start[0], start[1], destination[0], destination[1], visited);
        }

        private bool DFS(int[,] maze, int sx, int sy, int dx, int dy, bool[,] visited)
        {
            return false;
            /*
            if (visited[sx, sy])
                return false;
            if (sx == dx && sy == dy)
            {
                return true;
            }
            visited[sx, sy] = true;
            var hasPath = false;
            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                var xx = sx + dirs[i, 0];
                var yy = sy + dirs[i, 1];
                var index = xx*maze.GetLength(1) + yy;
                if (xx >= 0 && xx < maze.GetLength(0) && yy >= 0 && yy < maze.GetLength(1) && maze[xx, yy] == 0 &&
                    !visted.Contains(index))
                {
                    visted.Add(index);
                    if (DFS(maze, xx, yy, dx, dy, visted)) return true;
                    visted.Remove(index);
                }
            }
            return false;
            */
        }
    }
}
