using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Walls_and_Gates
    {
        /// <summary>
        /// Time complexity : O(mn)O(mn).
        /// 范洪 式搜索  所有 0开始 同时填充
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates(int[,] rooms)
        {
            if (rooms.Length == 0 ) return;
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < rooms.GetLength(0); i++)
            {
                for (int j = 0; j < rooms.GetLength(1); j++)
                {
                    if (rooms[i,j] == 0) queue.Enqueue(new int[] { i, j });  //看来是一起走， 从0 开始走
                }
            }
            while (queue.Any())
            {
                int[] top = queue.Dequeue();
                int row = top[0], col = top[1];
                if (row > 0 && rooms[row - 1,col] == int.MaxValue)  //只处理 inf的情况
                {
                    rooms[row - 1,col] = rooms[row,col] + 1;
                    queue.Enqueue(new int[] { row - 1, col });
                }
                if (row < rooms.GetLength(0) - 1 && rooms[row + 1,col] == int.MaxValue)
                {
                    rooms[row + 1,col] = rooms[row,col] + 1;
                    queue.Enqueue(new int[] { row + 1, col });
                }
                if (col > 0 && rooms[row,col - 1] == int.MaxValue)
                {
                    rooms[row,col - 1] = rooms[row,col] + 1;
                    queue.Enqueue(new int[] { row, col - 1 });
                }
                if (col < rooms.GetLength(1) - 1 && rooms[row,col + 1] == int.MaxValue)
                {
                    rooms[row,col + 1] = rooms[row,col] + 1;
                    queue.Enqueue(new int[] { row, col + 1 });
                }
            }
        }

      
    }
}
