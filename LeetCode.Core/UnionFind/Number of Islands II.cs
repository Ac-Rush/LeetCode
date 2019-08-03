using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.UnionFind
{
    class Number_of_Islands_II
    {
        class UnionFind
        {
            int count; // # of connected components
            int[] parent;
            int[] rank;

            public UnionFind(char[,] grid)
            { // for problem 200
                count = 0;
                int m = grid.GetLength(0);
                int n = grid.GetLength(1);
                parent = new int[m * n];
                rank = new int[m * n];
                for (int i = 0; i < m; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (grid[i,j] == '1')
                        {
                            parent[i * n + j] = i * n + j;
                            ++count;
                        }
                        rank[i * n + j] = 0;
                    }
                }
            }

            public UnionFind(int N)
            { // for problem 305 and others
                count = 0;
                parent = new int[N];
                rank = new int[N];
                for (int i = 0; i < N; ++i)
                {
                    parent[i] = -1;
                    rank[i] = 0;
                }
            }

            public bool isValid(int i)
            { // for problem 305
                return parent[i] >= 0;
            }

            public void setParent(int i)
            {
                parent[i] = i;
                ++count;
            }

            public int find(int i)
            { // path compression
                if (parent[i] != i) parent[i] = find(parent[i]);
                return parent[i];
            }

            public void union(int x, int y)
            { // union with rank
                int rootx = find(x);
                int rooty = find(y);
                if (rootx != rooty)
                {
                    if (rank[rootx] > rank[rooty])
                    {
                        parent[rooty] = rootx;
                    }
                    else if (rank[rootx] < rank[rooty])
                    {
                        parent[rootx] = rooty;
                    }
                    else
                    {
                        parent[rooty] = rootx; rank[rootx] += 1;
                    }
                    --count;
                }
            }

            public int getCount()
            {
                return count;
            }
        }

        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {
            List<int> ans = new List<int>();
            UnionFind uf = new UnionFind(m * n);
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int r = positions[i,0], c = positions[i, 1];
                List<int> overlap = new List<int>();

                if (r - 1 >= 0 && uf.isValid((r - 1) * n + c)) overlap.Add((r - 1) * n + c);
                if (r + 1 < m && uf.isValid((r + 1) * n + c)) overlap.Add((r + 1) * n + c);
                if (c - 1 >= 0 && uf.isValid(r * n + c - 1)) overlap.Add(r * n + c - 1);
                if (c + 1 < n && uf.isValid(r * n + c + 1)) overlap.Add(r * n + c + 1);

                int index = r * n + c;
                uf.setParent(index);
                foreach (int j in overlap) uf.union(j, index);
                ans.Add(uf.getCount());
            }

            return ans;
        }
    }


    class Number_of_Islands_II_2
    {
        int[,] dirs = { { 0, 1 }, { 1, 0 }, { -1, 0 }, { 0, -1 } };
        public IList<int> NumIslands2(int m, int n, int[,] positions)
        {
            List<int> ans = new List<int>();
            int count = 0;                      // number of islands
            int[] roots = new int[m * n];       // one island = one tree
            for (int i = 0; i < roots.Length; i++)
            {
                roots[i] = -1;
            }
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int root = n * positions[i, 0] + positions[i, 1];     // assume new point is isolated island
                roots[root] = root;             // add new island
                count++;

                for (int j = 0; j < dirs.GetLength(0); j++)
                {
                    int x = positions[i, 0] + dirs[j,0];
                    int y = positions[i, 1] + dirs[j, 1];
                    int nb = n * x + y;
                    if (x < 0 || x >= m || y < 0 || y >= n || roots[nb] == -1) continue;

                    int rootNb = findIsland(roots, nb);
                    if (root != rootNb)
                    {        // if neighbor is in another island
                        roots[root] = rootNb;   // union two islands 
                        root = rootNb;          // current tree root = joined tree root
                        count--;
                    }
                }

                ans.Add(count);
            }

            return ans;
        }
        public int findIsland(int[] roots, int id)
        {
            while (id != roots[id]) id = roots[id];
            return id;
        }
    }
}
