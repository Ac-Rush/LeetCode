using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Perfect_Rectangle
    {
        /// <summary>
        /// 太牛了
        /// 编码，算面积 用 set，去掉点
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool IsRectangleCover(int[,] rectangles)
        {
            if (rectangles.GetLength(0) == 0 || rectangles.GetLength(1) == 0) return false;

            int x1 = int.MaxValue;
            int x2 = int.MinValue;
            int y1 = int.MaxValue;
            int y2 = int.MinValue;

            HashSet<String> set = new HashSet<String>();
            int area = 0;


            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                x1 = System.Math.Min(x1, rectangles[i, 0]);
                y1 = System.Math.Min(y1, rectangles[i, 1]);
                x2 = System.Math.Max(x2, rectangles[i, 2]);
                y2 = System.Math.Max(y2, rectangles[i, 3]);

                area += (rectangles[i, 2] - rectangles[i, 0]) * (rectangles[i, 3] - rectangles[i, 1]);
                String s1 = rectangles[i, 0] + " " + rectangles[i, 1];
                String s2 = rectangles[i, 0] + " " + rectangles[i, 3];
                String s3 = rectangles[i, 2] + " " + rectangles[i, 3];
                String s4 = rectangles[i, 2] + " " + rectangles[i, 1];
                if (!set.Add(s1)) set.Remove(s1);
                if (!set.Add(s2)) set.Remove(s2);
                if (!set.Add(s3)) set.Remove(s3);
                if (!set.Add(s4)) set.Remove(s4);
            }

            if (!set.Contains(x1 + " " + y1) || !set.Contains(x1 + " " + y2) || !set.Contains(x2 + " " + y1) || !set.Contains(x2 + " " + y2) || set.Count != 4) return false;

            return area == (x2 - x1) * (y2 - y1);
        }

        public bool IsRectangleCoverMy(int[,] rectangles)
        {
            int left = int.MaxValue, bottom = int.MaxValue;
            int right = int.MinValue, top = int.MinValue;

            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                left = System.Math.Min(left, rectangles[i, 0]);
                bottom = System.Math.Min(bottom, rectangles[i, 1]);
                right = System.Math.Max(right, rectangles[i, 2]);
                top = System.Math.Max(top, rectangles[i, 3]);
            }

            var map = new int[top - bottom + 1, right - left + 1];
            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                for (int j = rectangles[i, 0]; j <= rectangles[i, 2]; j++)
                {
                    for (int k = rectangles[i, 1]; k < rectangles[i, 3]; k++)
                    {
                        if (map[k - rectangles[i, 1], j - rectangles[i, 0]] == 1)
                        {
                            return false;
                        }
                        map[k - rectangles[i, 1], j - rectangles[i, 0]] = 1;
                    }
                }
            }
            return map.Cast<int>().All(m => m != 0);
        }
    }
}
