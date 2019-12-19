using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.UnionFind
{
    /// <summary>
    /// 最小生成树 贪心算法
    /// </summary>
    class Optimize_Water_Distribution_in_a_Village
    {
        int[] uf;
        public int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
        {
            uf = new int[n + 1];
            List<int[]> edges = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                uf[i + 1] = i + 1; //初始化 union found
                edges.Add(new int[] { 0, i + 1, wells[i] });  // 虚拟边， 合并一起计算，  从0（没这个点） 和本点 的权重是 wells[i]
            }
            foreach (int[] p in pipes)
            {
                edges.Add(p);
            }
            edges.Sort((a,b)=>a[2].CompareTo(b[2]));

            int res = 0;
            foreach (int[] e in edges)
            {
                int x = find(e[0]), y = find(e[1]);  // 判断是否在同一个连同图
                if (x != y)  // 如果不是同一个， 需要连起来
                {
                    res += e[2];
                    uf[x] = y; //union found 连起来
                    --n;
                }
            }
            return res;
        }

        private int find(int x)
        {
            if (x != uf[x]) uf[x] = find(uf[x]);
            return uf[x];
        }
    }
}
