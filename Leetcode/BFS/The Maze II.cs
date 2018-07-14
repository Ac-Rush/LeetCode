using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    /// <summary>
    /// Time complexity : O(m*n*max(m,n))O(m∗n∗max(m,n)). Time complexity : O(m*n*\text{max}(m,n))O(m∗n∗max(m,n)). C
    /// </summary>
    class The_Maze_II_BFS
    {
        //这个不能用 visited数组了， 因为找最优， 用长度来剪枝
        public int ShortestDistance(int[,] maze, int[] start, int[] destination)
        {
            var distance = new int[maze.GetLength(0), maze.GetLength(1)];
            for (int i = 0; i < distance.GetLength(0); i++)
            {
                for (int j = 0; j < distance.GetLength(1); j++)
                {
                    distance[i, j] = Int32.MaxValue;
                }
            }
            distance[start[0],start[1]] = 0;
            var dirs = new int[,] { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new []{start[0], start[1]});

            while (queue.Any())
            {
                int[] s = queue.Dequeue();
                
                
                for (int i = 0; i < dirs.GetLength(0); i++)
                {
                    int count = 0;
                    int x = s[0] + dirs[i, 0];
                    int y = s[1] + dirs[i, 1];
                    while (x >= 0 && y >= 0 && x < maze.GetLength(0) && y < maze.GetLength(1) && maze[x, y] == 0)
                    {
                        count++;
                        x += dirs[i, 0];
                        y += dirs[i, 1];
                    }
                    if (distance[s[0],s[1]] + count < distance[x - dirs[i, 0], y - dirs[i, 1]])
                    {
                        distance[x - dirs[i, 0], y - dirs[i, 1]] = distance[s[0], s[1]] + count;
                        queue.Enqueue(new int[] { x - dirs[i, 0], y - dirs[i, 1] });
                    }
                }
            }
            return distance[destination[0], destination[1]] == int.MaxValue ? -1 : distance[destination[0], destination[1]];
        }
    }


    /// <summary>
    /// Time complexity : O\big(mn*log(mn)\big)O(mn∗log(mn))
    /// </summary>
    class The_Maze_II_dijkstra
    {
        public int ShortestDistance(int[,] maze, int[] start, int[] destination)
        {
            var distance = new int[maze.GetLength(0), maze.GetLength(1)];
            for (int i = 0; i < distance.GetLength(0); i++)
            {
                for (int j = 0; j < distance.GetLength(1); j++)
                {
                    distance[i, j] = Int32.MaxValue;
                }
            }
            distance[start[0], start[1]] = 0;
            dijkstra(maze, start, distance);

            return distance[destination[0], destination[1]] == int.MaxValue ? -1 : distance[destination[0], destination[1]];
        }

        public void dijkstra(int[,] maze, int[] start, int[,] distance)
        {
            var dirs = new int[,] { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
            SortedSet<int[]> queue = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
            {
                var result = a[2] - b[2];
                if (result == 0)
                {
                    return (a[0]*maze.GetLength(1) + a[2]).CompareTo(b[0] * maze.GetLength(1) + b[2]);
                }
                return a[2] - b[2];
            }));
            queue.Add(new int[] { start[0], start[1], 0 });
            while (queue.Any())
            {
                int[] s = queue.Min;
                queue.Remove(s);
                if (distance[s[0],s[1]] < s[2]) //剪枝？》
                    continue;

                for (int i = 0; i < dirs.GetLength(0); i++)
                {
                    int count = 0;
                    int x = s[0] + dirs[i, 0];
                    int y = s[1] + dirs[i, 1];
                    while (x >= 0 && y >= 0 && x < maze.GetLength(0) && y < maze.GetLength(1) && maze[x, y] == 0)
                    {
                        count++;
                        x += dirs[i, 0];
                        y += dirs[i, 1];
                    }
                    if (distance[s[0], s[1]] + count < distance[x - dirs[i, 0], y - dirs[i, 1]])
                    {
                        distance[x - dirs[i, 0], y - dirs[i, 1]] = distance[s[0], s[1]] + count;
                        queue.Add(new int[] { x - dirs[i, 0], y - dirs[i, 1], distance[x - dirs[i, 0], y - dirs[i, 1]] });
                    }
                }
            }
        }
    }
}
