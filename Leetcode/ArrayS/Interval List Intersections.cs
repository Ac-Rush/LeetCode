using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Interval_List_Intersections
    {
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var ans = new List<int[]>();
            for (int i = 0, j = 0; i < A.Length && j < B.Length;)
            {
                if (A[i][1]< B[j][0]) ++i;
                else if (B[j][1] < A[i][0]) ++j;
                else
                {
                    //不用去重新调节 intersect 以后的剩余区间， 太麻烦
                    ans.Add(new int[]{ Math.Max(A[i][0], B[j][0]), Math.Min(A[i][1], B[j][1]) });
                    if (A[i][1] < B[j][1]) ++i;
                    else ++j;
                }
            }
            return ans.ToArray();
        }
    }
}
