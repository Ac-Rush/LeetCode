using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Image_Smoother
    {
        public int[,] ImageSmoother(int[,] M)
        {
            int R = M.GetLength(0), C = M.GetLength(1);
            var ans = new int[R,C];

            for (int r = 0; r < R; ++r)
                for (int c = 0; c < C; ++c)
                {
                    int count = 0;
                    for (int nr = r - 1; nr <= r + 1; ++nr)
                        for (int nc = c - 1; nc <= c + 1; ++nc)
                        {
                            if (0 <= nr && nr < R && 0 <= nc && nc < C)
                            {
                                ans[r,c] += M[nr,nc];
                                count++;
                            }
                        }
                    ans[r,c] /= count;
                }
            return ans;
        }
    }
}
