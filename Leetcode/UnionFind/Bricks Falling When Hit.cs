using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.UnionFind
{
    class Bricks_Falling_When_Hit
    {

        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            int R = grid.Length, C = grid[0].Length;
            int[] dr = { 1, 0, -1, 0 };
            int[] dc = { 0, 1, 0, -1 };

            var A = new int[R][];
            for (int r = 0; r < R; ++r)
                A[r] = (int[]) grid[r].Clone();
            foreach (int[] hit in hits)
                A[hit[0]][hit[1]] = 0;

            DSU dsu = new DSU(R * C + 1); //建立 DSU
            for (int r = 0; r < R; ++r)
            {
                for (int c = 0; c < C; ++c)
                {
                    if (A[r][c] == 1)  //如果是砖
                    {
                        int i = r * C + c;  // 二维坐标转1维 
                        if (r == 0)   //如果是最上层
                            dsu.union(i, R * C);  //R*C 默认是 最上层吧
                        if (r > 0 && A[r - 1][c] == 1)
                            dsu.union(i, (r - 1) * C + c);  //和上面的连
                        if (c > 0 && A[r][c - 1] == 1)
                            dsu.union(i, r * C + c - 1);//和左面的连
                    }
                }
            }
            int t = hits.Length;
            int[] ans = new int[t--];

            while (t >= 0)
            {
                int r = hits[t][0];
                int c = hits[t][1];
                int preRoof = dsu.top();
                if (grid[r][c] == 0)
                {
                    t--;
                }
                else
                {
                    int i = r * C + c;
                    for (int k = 0; k < 4; ++k)
                    {
                        int nr = r + dr[k];
                        int nc = c + dc[k];
                        if (0 <= nr && nr < R && 0 <= nc && nc < C && A[nr][nc] == 1)
                            dsu.union(i, nr * C + nc);
                    }
                    if (r == 0)
                        dsu.union(i, R * C);
                    A[r][c] = 1;
                    ans[t--] = Math.Max(0, dsu.top() - preRoof - 1);
                }
            }

            return ans;
        }

        class DSU
        {
            int[] parent;
            int[] rank;
            int[] sz;

            public DSU(int N)
            {
                parent = new int[N];
                for (int i = 0; i < N; ++i)
                    parent[i] = i;
                rank = new int[N];
                sz = new int[N];
                for (int i = 0; i < N; i++)
                {
                    sz[i] = 1;
                }
            }

            public int find(int x)
            {
                if (parent[x] != x) parent[x] = find(parent[x]);
                return parent[x];
            }

            public void union(int x, int y)
            {
                int xr = find(x), yr = find(y);
                if (xr == yr) return;

                if (rank[xr] < rank[yr])
                {
                    int tmp = yr;
                    yr = xr;
                    xr = tmp;
                }
                if (rank[xr] == rank[yr])
                    rank[xr]++;

                parent[yr] = xr;
                sz[xr] += sz[yr];
            }

            public int size(int x)
            {
                return sz[find(x)];
            }

            public int top()
            {
                return size(sz.Length - 1) - 1;
            }
        }
    }
}
