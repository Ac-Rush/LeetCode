using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.BFS
{
    class Cut_Off_Trees_for_Golf_Event
    {
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
        public int CutOffTree(IList<IList<int>> forest)
        {
            List<int[]> trees = new List<int[]>();
            for (int r = 0; r < forest.Count; ++r)
            {
                for (int c = 0; c < forest[r].Count; ++c)
                {
                    int v = forest[r][c];
                    if (v > 1) trees.Add(new int[] { v, r, c });  //value ,行，列
                }
            }
            trees.Sort(Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
            int ans = 0, sr = 0, sc = 0;
            foreach (int[] tree in trees)
            {
                int d = bfs(forest, sr, sc, tree[1], tree[2]);
                if (d < 0) return -1; // 没有结果
                ans += d;
                sr = tree[1]; sc = tree[2];
            }
            return ans;
        }

        public int bfs(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
        {
            int R = forest.Count, C = forest[0].Count;
            var queue = new Queue<int[]>();
            queue.Enqueue(new int[] { sr, sc, 0 }); // 入 当前节点
            var seen = new bool[R,C];
            seen[sr,sc] = true;
            while (queue.Any())
            {
                int[] cur = queue.Dequeue();
                if (cur[0] == tr && cur[1] == tc) return cur[2]; //结束条件
                for (int di = 0; di < 4; ++di)
                {
                    int r = cur[0] + dr[di];
                    int c = cur[1] + dc[di];
                    if (0 <= r && r < R && 0 <= c && c < C &&
                        !seen[r,c] && forest[r][c] > 0) // validate 
                    {
                        seen[r,c] = true;
                        queue.Enqueue(new int[] { r, c, cur[2] + 1 });
                    }
                }
            }
            return -1;
        }
    }
}
