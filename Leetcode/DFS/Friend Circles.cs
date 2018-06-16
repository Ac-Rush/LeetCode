using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Friend_Circles
    {
        public int FindCircleNum(int[,] M)
        {
            var r = M.GetLength(0);
            var visited = new bool[r];

            var count = 0;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                if (visited[i] == false)
                {
                    count++;
                    Visit(M,i,visited);
                }
            }
            return count;
        }

        public void Visit(int[,] M, int r, bool[] visited)
        {
            visited[r] = true;
            for (int i =0; i < M.GetLength(0) ; i++)
            {
                if (r != i && visited[i] == false && M[r,i] == 1) // my bug: miss " && M[r,i] == 1"
                {
                    Visit(M, i , visited);
                }
            }
        }
    }
}
