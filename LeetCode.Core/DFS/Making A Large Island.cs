using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Making_A_Large_Island
    {
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, -1, 0, 1 };
        int[][] grid;
        int N;
        public int LargestIsland(int[][] grid)
        {
            this.grid = grid;
            N = grid.Length;
            var color = 1;
            var dict = new Dictionary<int, int>();// color -> area
            dict[0] = 0;  //有了这个初始值 下面就省去了 判断
            int ans = 0;
            for (int r = 0; r < N; ++r)
                for (int c = 0; c < N; ++c)
                    if (grid[r][c] == 1)
                    {
                        color++;
                        var area = GerArea(r, c, color);
                        dict[color] = area;
                        ans = Math.Max(ans, area);  //这个需要，如果全都是1
                    }
                        

            for (int r = 0; r < N; ++r)
                for (int c = 0; c < N; ++c)
                    if (grid[r][c] == 0)
                    {
                        var seen = new HashSet<int>();  // 用 hashset去重， 找周边四个连通分量
                        if (r > 0) seen.Add(grid[r -1][c]);
                        if (r < N -1) seen.Add(grid[r + 1][c]);
                        if (c > 0) seen.Add(grid[r ][c -1]);
                        if (c < grid[r].Length - 1) seen.Add(grid[r ][c + 1]);
                        int bns = 1;
                        foreach (int i in seen) bns += dict[i];
                        ans = Math.Max(ans, bns);
                    }

            return ans;
        }

        //求连通量的面积， 上色 求面积
        public int GerArea(int r, int c, int color)
        {
            if (r < 0 || c < 0 || r >= N || c >= N || grid[r][c] != 1) return 0;
            grid[r][c] = color;
            return 1 + GerArea(r + 1, c, color) + GerArea(r , c + 1, color)
                + GerArea(r -1, c, color) + GerArea(r , c -1 , color);

        }
    }
}
