using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    /// <summary>
    /// 三种方法吧，
    /// 1. 最简单的 排序取k，
    /// 2. 用了 PQ,
    /// 3. 最好去用 K Select
    /// </summary>
    class K_Closest_Points_to_Origin
    {
        /// <summary>
        /// O(nLogn)
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int K)
        {
            return points.OrderBy(i => i[0] * i[0] + i[1] * i[1]).Take(K).ToArray();
        }
    }

    class K_Closest_Points_to_Origin_nlogk
    {
        /// <summary>
        /// O(nlogk)
        /// </summary>
        /// <param name="points"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int[][] KClosest(int[][] points, int K)
        {
            SortedSet<Tuple<int[], int>> pq = new SortedSet<Tuple<int[], int>>(Comparer<Tuple<int[], int>>.Create((a, b) =>
            {
                var da = a.Item1[0] * a.Item1[0] + a.Item1[1] * a.Item1[1];
                var db = b.Item1[0] * b.Item1[0] + b.Item1[1] * b.Item1[1];
                if (da == db)
                {
                    return a.Item2.CompareTo(b.Item2);
                }

                return da.CompareTo(db);
            }));
            int count = 0;
            for (int i = 0; i < points.Length; i++)
            {
                pq.Add(new Tuple<int[], int>(points[i], i));
                if (count == K)
                {
                    pq.Remove(pq.Max);
                }
                else
                {
                    count++;
                }

            }

            return pq.ToArray().Select(i => i.Item1).ToArray();
        }
    }
}
