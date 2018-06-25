using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Largest_Triangle_Area
    {
        
        public double LargestTriangleArea(int[][] points)
        {
            int N = points.Length;
            double ans = 0;
            for (int i = 0; i < N; ++i)
                for (int j = i + 1; j < N; ++j)
                    for (int k = j + 1; k < N; ++k)
                        ans = Math.Max(ans, area(points[i], points[j], points[k]));
            return ans;
        }

        public double area(int[] P, int[] Q, int[] R)
        {
            return 0.5 * Math.Abs(P[0] * Q[1] + Q[0] * R[1] + R[0] * P[1]
                                 - P[1] * Q[0] - Q[1] * R[0] - R[1] * P[0]);
        }
    }
}
