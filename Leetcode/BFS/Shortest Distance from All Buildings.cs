using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Shortest_Distance_from_All_Buildings
    {
        /*
        
        Traverse the matrix. For each building, use BFS to compute the shortest distance from each '0' to
this building. After we do this for all the buildings, we can get the sum of shortest distance
from every '0' to all reachable buildings. This value is stored
in 'distance[][]'. For example, if grid[2][2] == 0, distance[2][2] is the sum of shortest distance from this block to all reachable buildings.
Time complexity: O(number of 1)O(number of 0) ~ O(m^2n^2) 
        
         Algorithm:

BFS starting from each building
do level traversal. Add the level(i.e. distance) to the 2-D distance array
optimization: change each land to mark (initially 0, then -1, -2, ...) so it can skip lands one of the previous buildings can't reach. By doing so we don't need the array visited[,]
         */
        public int ShortestDistance(int[,] grid)
        {
            // direction 的数组
            int[] dx = new int[] { -1, 1, 0, 0 };
            int[] dy = new int[] { 0, 0, -1, 1 };
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int[,] dist = new int[m, n];  // 到所有 build的 最短距离  
            int mark = 0;  //作用就是 visited数组的作用   这个太棒了

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == 1) //从 buildings 出发 而不是从 空地出发
                    {
                        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>(); // 求最短距离 用 BFS
                        queue.Enqueue(new Tuple<int, int>(i, j));
                        int level = 1;
                        while (queue.Count > 0)  //这样写是 因为要 一圈一圈的遍历 ， 因为这一圈 len相同
                        {
                            int size = queue.Count;
                            for (int k = 0; k < size; k++) //遍历这层里面的每个元素
                            {
                                var tuple = queue.Dequeue();
                                for (int l = 0; l < dx.Length; l++)  //遍历四个方向
                                {
                                    int x = dx[l] + tuple.Item1;  //就新的 x,y
                                    int y = dy[l] + tuple.Item2;
                                    if (x >= 0 && x < m && y >= 0 && y < n && grid[x, y] == mark)  //越界check，  mark是 Visited数组的作用
                                    {
                                        dist[x, y] += level;   //距离数组 加上这段距离
                                        grid[x, y]--;  //修改这个值，以便 下一次再用
                                        queue.Enqueue(new Tuple<int, int>(x, y));
                                    }
                                }
                            }
                            level++;
                        }
                        mark--; // this line should be in if block
                    }

                }
            }

            int minDist = -1; // this is the value which should be returned if no solution
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == mark)  //遍历 0的点  ， 这时候 0 是 mark， 
                    {
                        minDist = minDist < 0 ? dist[i, j] : Math.Min(minDist, dist[i, j]);  //遍历 求最小
                    }
                }
            }
            return minDist;
        }
    }
}
