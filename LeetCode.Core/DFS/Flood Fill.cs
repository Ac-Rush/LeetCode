using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Flood_Fill
    {
        private int[,] dirs= new int[,] { { 1, 0 }, { 0, 1 }, {0,-1}, {-1,0} };
        public int[,] FloodFill(int[,] image, int sr, int sc, int newColor)
        {
            int color = image[sr,sc];
            if (color != newColor)  //my bug , stack over flow，如果相同该死循环了
            {
                if (0 <= sr && sr < image.GetLength(0) && 0 <= sc && sc < image.GetLength(1))
                {
                    DfsFloodFill(image, sr, sc, newColor);
                }
            }
            return image;
        }

        public void DfsFloodFill(int[,] image, int sr, int sc, int newColor)
        {
            int oldColor = image[sr, sc];
            image[sr, sc] = newColor;
            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                var r = sr + dirs[i, 0];
                var c = sc + dirs[i, 1];
                if (0 <= r && r < image.GetLength(0) && 0 <= c && c < image.GetLength(1)
                    && image[r, c] == oldColor)
                {
                    DfsFloodFill(image, r, c, newColor);
                }
            }
        }
    }
}
