using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Knight_Probability_in_Chessboard
    {
        public double KnightProbability(int N, int K, int r, int c)
        {
            var map = new double[N, N];
            map[r, c] = 1;
            int[] dr = new int[] { 2, 2, 1, 1, -1, -1, -2, -2 };
            int[] dc = new int[] { 1, -1, 2, -2, 2, -2, 1, -1 };

            for (;K > 0; K--)
            {
                var map2 = new double[N, N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            int cr = i + dr[k];
                            int cc = j + dc[k];
                            if (0 <= cr && cr < N && 0 <= cc && cc < N)
                            {
                                map2[cr, cc] += map[i, j]/8.0;
                            }
                        }
                    }
                }
                map = map2;
            }
            double ans = 0;
            foreach (var p in map)
            {
                ans += p;
            }
            return ans;
        }
    }
}
