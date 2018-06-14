using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class Point
    {
      public int x;
      public int y;
      public Point() { x = 0; y = 0; }
      public Point(int a, int b) { x = a; y = b; }
  }
    class Max_Points_on_a_Line
    {

        public int MaxPoints(Point[] points)
        {
            if (points.Length < 2) return points.Length;
            int max = 2;
            foreach (Point p1 in points)
            {
                var slopes = new Dictionary<int,int>();
                int localMax = 0;
                foreach (Point p2 in points)
                {
                    int num = p2.y - p1.y;
                    int den = p2.x - p1.x;

                    // pairing functions only work with non-negative integers
                    // we store the sign in a separate variable
                    int sign = 1;
                    if ((num > 0 && den < 0) || (num < 0 && den > 0)) sign = -1;
                    num = Math.Abs(num);
                    den = Math.Abs(den);

                    // pairing functions represent a pair of any two integers uniquely;
                    // they can be used as hash functions for any sequence of integers;
                    // therefore, a pairing function from 1/2 doesn't equal to that from 3/6
                    // even though the slope 1/2 and 3/6 is the same.
                    // => we need to convert each fraction to its simplest form, i.e. 3/6 => 1/2
                    int gcd = GCD(num, den);
                    num = gcd == 0 ? num : num / gcd;
                    den = gcd == 0 ? den : den / gcd;

                    // We can use Cantor pairing function pi(k1, k2) = 1/2(k1 + k2)(k1 + k2 + 1) + k2
                    // and include the sign
                    int m = sign * (num + den) * (num + den + 1) / 2 + den;
                    if (slopes.ContainsKey(m)) slopes[m]++;
                    else slopes[m] = 1;
                    if (m == 0) continue;

                    localMax = Math.Max(slopes[m], localMax);
                }
                max = Math.Max(max, localMax + slopes[0]);
            }
            return max;

        }

        public int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }

        /// <summary>
        /// wrong anwser 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints3(Point[] points)
        {
            if (points == null || points.Length <= 1)
            {
                return points.Length;
            }
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    AddPoint(points[i], points[j], dict);
                }
            }
            var max = dict.Values.Max();
            return (int)(Math.Sqrt(2*max + 0.25) + 0.5);
        }

        private void AddPoint(Point p1, Point p2, Dictionary<string, int> dict)
        {

            if (p1.x == p2.x && p1.y == p2.y)
            {
                for (int i = 0; i < dict.Keys.Count; i++)
                {
                    AddKey(dict, dict.Keys.ElementAt(i));
                }
            }
            if (p1.x == p2.x)
            {
                var key = $"X {p1.x}";
                AddKey(dict, key);
            }
            else if (p1.x < p2.x)
            {
                var slope = ((double) (p2.y - p1.y))/(p2.x - p1.x);
                if (slope == 0)
                {
                    AddKey(dict, $"Y {p1.y}");
                }
                else
                {
                    AddKey(dict, $"{slope} {p1.y - slope * p1.x}");
                }
            }
            else
            {
                AddPoint(p2, p1, dict);
            }
        }

        private void AddKey(Dictionary<string, int> dict, string key)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = 0;
            }
            dict[key]++;
        }
    }
}
