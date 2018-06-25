using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Rectangle_Area
    {
        int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            int left = Math.Max(A, E), right = Math.Max(Math.Min(C, G), left);
            int bottom = Math.Max(B, F), top = Math.Max(Math.Min(D, H), bottom);
            return (C - A) * (D - B)  + (G - E) * (H - F) - (right - left) * (top - bottom);
        }
    }
}
