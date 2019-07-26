using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Triangle
    { 
        //还是自底向上 比较直观 方便
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            for (int i = triangle.Count -2; i >=0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    triangle[i][j] = triangle[i][j] + Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
                }
            }
            return triangle[0][0];
        }
    }
}
