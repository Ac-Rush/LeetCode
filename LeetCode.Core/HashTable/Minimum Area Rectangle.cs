using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Core.HashTable
{
    class Minimum_Area_Rectangle
    {
        public int MinAreaRect(int[][] points)
        {
            var map = new Dictionary<int, HashSet<int>>();
            foreach (int[] p in points)
            {
                if (!map.ContainsKey(p[0]))
                {
                    map[p[0]] =  new HashSet<int>();
                }
                map[p[0]].Add(p[1]);
            }
            int min = int.MaxValue;
            foreach (int[] p1 in points)
            {
                foreach (int[] p2 in points)
                {
                    if (p1[0] == p2[0] || p1[1] == p2[1]) // 注意这个过滤
                    { // if have the same x or y
                        continue;
                    }
                    if (map[p1[0]].Contains(p2[1]) && map[p2[0]].Contains(p1[1]))
                    { // find other two points
                        min = Math.Min(min, Math.Abs(p1[0] - p2[0]) * Math.Abs(p1[1] - p2[1]));
                    }
                }
            }
            return min == int.MaxValue ? 0 : min;
        }
    }
}
