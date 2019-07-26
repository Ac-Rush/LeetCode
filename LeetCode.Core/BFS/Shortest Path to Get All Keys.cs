using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Shortest_Path_to_Get_All_Keys
    {
        /*
         Use Bit to represent the keys.
 Use State to represent visited states.

     */
        public class State
        {
            // 钥匙， x, y
            public int keys, i, j;
            public State(int keys, int i, int j)
            {
                this.keys = keys;
                this.i = i;
                this.j = j;
            }
        }
        int[,] dirs = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        public int ShortestPathAllKeys(string[] grid)
        {
            //[x,y]是 start点                                        //max key 最多的数量
            int x = -1, y = -1, m = grid.Length, n = grid[0].Length, max = -1;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char c = grid[i][j];
                    if (c == '@')
                    {
                        x = i;
                        y = j;
                    }
                    if (c >= 'a' && c <= 'f')
                    {// 最多6把key
                        max = Math.Max(c - 'a' + 1, max);
                    }
                }
            }
            State start = new State(0, x, y);
            Queue<State> q = new Queue<State>();
            var visited = new HashSet<string>();
            visited.Add(0 + " " + x + " " + y);
            q.Enqueue(start);
            int step = 0;

            //经典  BFS
            while (q.Any())
            {
                int size = q.Count;
                while (size-- > 0)
                {
                    State cur = q.Dequeue();
                    if (cur.keys == (1 << max) - 1)  //所有钥匙都有了   11111
                    {
                        return step;
                    }
                    for (int k = 0; k < dirs.GetLength(0); k++)
                    {
                        int i = cur.i + dirs[k,0];
                        int j = cur.j + dirs[k,1];
                        int keys = cur.keys;
                        if (i >= 0 && i < m && j >= 0 && j < n) //check 边界
                        {
                            char c = grid[i][j];
                            if (c == '#')  //check 墙
                            {
                                continue;
                            }
                            if (c >= 'a' && c <= 'f')  //如果是 key
                            {
                                keys |= 1 << (c - 'a');
                            }
                            if (c >= 'A' && c <= 'F' && ((keys >> (c - 'A')) & 1) == 0)  //如果是锁， 并且没有钥匙 跳过
                            {
                                continue;
                            }
                            if (!visited.Contains(keys + " " + i + " " + j))  //visited 是状态，BFS里面的 visited是状态的 visited
                            {
                                visited.Add(keys + " " + i + " " + j);
                                q.Enqueue(new State(keys, i, j));
                            }
                        }
                    }
                }
                step++;
            }
            return -1;
        }
    }
}
