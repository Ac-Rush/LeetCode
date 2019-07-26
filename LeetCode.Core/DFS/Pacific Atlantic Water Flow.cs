using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Pacific_Atlantic_Water_Flow
    {
        int[,] dir = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        public IList<int[]> PacificAtlantic(int[,] matrix)
        {
            List<int[]> res = new List<int[]>();
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (matrix == null || n == 0 || m == 0)
            {
                return res;
            }
            var pacific = new bool[n,m];
            var atlantic = new bool[n, m];

            Queue<int[]> pQueue = new Queue<int[]>();
            Queue<int[]> aQueue = new Queue<int[]>();

            //初始化
            for (int i = 0; i < n; i++)
            { //Vertical border
                pQueue.Enqueue(new int[] { i, 0 });
                aQueue.Enqueue(new int[] { i, m - 1 });  //大西洋是 右边一列
                pacific[i,0] = true;
                atlantic[i,m - 1] = true;
            }

            //初始化
            for (int i = 0; i < m; i++)
            { //Horizontal border
                pQueue.Enqueue(new int[] { 0, i });
                aQueue.Enqueue(new int[] { n - 1, i });//大西洋是 下面一行
                pacific[0,i] = true;
                atlantic[n - 1,i] = true;
            }

            bfs(matrix, pQueue, pacific);
            bfs(matrix, aQueue, atlantic);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pacific[i,j] && atlantic[i,j])
                        res.Add(new int[] { i, j });
                }
            }
            return res;
        }
        public void bfs(int[,] matrix, Queue<int[]> queue, bool[,] visited)
        {
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            while (queue.Any())  //从已经能到 大西洋或太平洋的点开始遍历
            {
                int[] cur = queue.Dequeue();
                for (int i = 0; i <dir.GetLength(0); i++)
                {
                    int x = cur[0] + dir[i,0];
                    int y = cur[1] + dir[i,1];
                    //高的往低的流。
                    if (x < 0 || x >= n || y < 0 || y >= m || visited[x,y] || matrix[x,y] < matrix[cur[0],cur[1]])
                    {
                        continue;
                    }
                    visited[x,y] = true;
                    queue.Enqueue(new int[] { x, y });
                }
            }
        }
    }
}
