using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Dungeon_Game
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            if (dungeon == null || dungeon.Length == 0 || dungeon[0].Length == 0) return 0;

            int m = dungeon.Length;
            int n = dungeon[0].Length;
            var health = new int[m,n];
            health[m - 1,n - 1] = Math.Max(1 - dungeon[m - 1][n - 1], 1);

            for (int i = m - 2; i >= 0; i--)
            {
                health[i,n - 1] = Math.Max(health[i + 1,n - 1] - dungeon[i][n - 1], 1);
            }

            for (int j = n - 2; j >= 0; j--)
            {
                health[m - 1,j] = Math.Max(health[m - 1,j + 1] - dungeon[m - 1][j], 1);
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    int down = Math.Max(health[i + 1,j] - dungeon[i][j], 1);
                    int right = Math.Max(health[i,j + 1] - dungeon[i][j], 1);
                    health[i,j] = Math.Min(right, down);
                }
            }

            return health[0,0];
        }

    }


    class Dungeon_GameMy
    {
        public int CalculateMinimumHP(int[][] dungeon)
        {
            if (dungeon == null || dungeon.Length == 0 || dungeon[0].Length == 0) return 0;

            int m = dungeon.Length;
            int n = dungeon[0].Length;
            var health = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                health[i] = int.MaxValue;
            }
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    health[j] = Math.Min(health[j], health[j + 1]) - dungeon[i][j];
                }
            }
            return health[0];
        }

    }
}
