using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    class Flood_Fill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;
            Dfs(image, sr, sc, image[sr][sc], newColor);
            return image;
        }
        private void Dfs(int[][] image, int sr, int sc, int oldColor, int newColor)
        {
            if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[0].Length || image[sr][sc] != oldColor)
            {
                return;
            }
            image[sr][sc] = newColor;
            Dfs(image, sr + 1, sc, oldColor, newColor);
            Dfs(image, sr, sc + 1, oldColor, newColor);
            Dfs(image, sr - 1, sc, oldColor, newColor);
            Dfs(image, sr, sc - 1, oldColor, newColor);
        }
    }
}
