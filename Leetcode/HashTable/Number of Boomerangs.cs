using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Number_of_Boomerangs
    {
        public int NumberOfBoomerangs(int[,] points)
        {
            var res = 0;
            var map = new Dictionary<int, int>();
            for (int i = 0; i < points.GetLength(0); i++)
            {
                for (int j = 0; j < points.GetLength(0); j++)
                {
                    if (i == j)
                        continue;

                    int d = getDistance(points,i,j);
                    if (!map.ContainsKey(d))
                    {
                        map[d] = 0;
                    }
                    map[d]++;
                }

                foreach (var val in map.Values)
                {
                    res += val * (val - 1);
                }

                map.Clear();
            }
            return res;
        }
        private int getDistance(int[,] points, int i ,int j)
        {
            return (int)Math.Pow(points[i, 0] - points[j, 0], 2) + (int)Math.Pow(points[i, 1] - points[j, 1], 2);
        }

    }
}
