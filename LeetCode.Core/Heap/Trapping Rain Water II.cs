using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    /// <summary>
    /// 我的答案，  就是 Trapping Rain Water  的升级版本，
    /// 相似点， 在 Trapping Rain Water 1中， 两端是墙， 而在2中 是个口字型的围墙。
    /// 1. 用到了 PQ, 用 r,c去重 item int[3] {height, x, y}
    /// 2. 每次在 PQ里面取出最小， 查周边四个点， //这里用到了 visited数组来防重，
    /// 3. 取出最小的，依次计算周围地个点， 然后再把四个点加入到 PQ里面
    /// </summary>
    public class Trapping_Rain_Water_II
    {
        private int[,] dir = new int[,] { {1,0}, {0,1}, {-1,0}, {0, -1} };
        public int TrapRainWater(int[,] heightMap)
        {
            var r = heightMap.GetLength(0);
            var c = heightMap.GetLength(1);
            var seen = new int[r, c];
            if (r <= 2 || c <= 2) return 0;
            var heap = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
            {
                var result = a[0].CompareTo(b[0]);
                if (result == 0)
                {
                    return (a[1]*c + a[2]).CompareTo(b[1]*c + b[2]);
                }
                return result;
            }));
            for (int i = 0; i < c; i++)  //第一行
            {  
                heap.Add(new int[] {heightMap[0, i], 0, i});
                seen[0, i] = 1;
            }
            for(int i= 1; i < r ; i ++)  //右边一列   //my bug was  i> r
            {
                heap.Add(new int[] { heightMap[i, c-1], i, c-1 });
                seen[i, c - 1] = 1;
            }
            for (int i = c-2; i>=0; i--)  //下面一行
            {
                heap.Add(new int[] { heightMap[r-1, i], r-1, i });
                seen[r - 1, i] = 1;
            }
            for (int i = r - 2; i >= 1; i--) //右边一列
            {
                heap.Add(new int[] { heightMap[i,0], i,0});
                seen[i, 0] = 1;
            }
            int res = 0;
            while (heap.Any())
            {
                var cell = heap.Min;
                heap.Remove(cell);
                for (int i = 0; i < dir.GetLength(0); i++)
                {
                    int row = cell[1] + dir[i,0];
                    int col = cell[2] + dir[i, 1];
                    if (row >= 0 && row <r && col >= 0 && col < c && seen[row,col] != 1)
                    {
                        seen[row, col] = 1;
                        res += Math.Max(0, cell[0] - heightMap[row,col]);
                        heap.Add(new int[] {Math.Max(heightMap[row, col], cell[0]), row, col});
                    }
                }
            }
            return res;
        }
    }
}
