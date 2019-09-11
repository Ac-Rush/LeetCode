using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.BFS
{
    class Sliding_Puzzle2
    {
        public int SlidingPuzzle(int[][] board)
        {
            string target = "123450";
            string start = "";
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    start += board[i][j];
                }
            }
            HashSet<string> visited = new HashSet<string>();
            // all the positions 0 can be swapped to
            // 方向, 比如0个 可以和1和3的换
            List<int[]> dirs = new List<int[]>  { new int []{ 1, 3 }, new int []{ 0, 2, 4 },new int []{ 1, 5 },
                                         new int []{ 0, 4 }, new int []{ 1, 3, 5 }, new int []{ 2, 4 } };
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);
            visited.Add(start);
            int res = 0;
            while (queue.Count > 0)
            {
                // level count, has to use size control here, otherwise not needed
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    String cur = queue.Dequeue();
                    if (cur.Equals(target))
                    {
                        return res;
                    }
                    int zero = cur.IndexOf('0'); // 找到0
                    // swap if possible
                    foreach (int dir in dirs[zero])
                    {
                        String next = swap(cur, zero, dir);
                        if (visited.Contains(next))
                        {
                            continue;
                        }
                        visited.Add(next);
                        queue.Enqueue(next);

                    }
                }
                res++;
            }
            return -1;
        }

        private String swap(String str, int i, int j)
        {
            StringBuilder sb = new StringBuilder(str);
            sb[i] = str[j];
            sb[j] = str[i];
            return sb.ToString();
        }
    }
}
