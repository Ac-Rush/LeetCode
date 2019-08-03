using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.UnionFind
{
    class Surrounded_Regions
    {
        /// <summary>
        /// DFS 四边 上色问题
        /// 从四边开始 DFS 上色
        /// </summary>
        /// <param name="board"></param>
        public void Solve(char[,] board)
        {
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];

            for (int i = 0; i <= board.GetLength(1) - 1; i++) //第一行
                if (board[0, i] == 'O' && !visited[0, i])
                    MarkInvalid(0, i, board, visited);

            for (int i = 0; i <= board.GetLength(1) - 1; i++) // 最后一列
                if (board[board.GetLength(0) - 1, i] == 'O' && !visited[board.GetLength(0) - 1, i])
                    MarkInvalid(board.GetLength(0) - 1, i, board, visited);

            for (int i = 0; i <= board.GetLength(0) - 1; i++) // 第一列
                if (board[i, 0] == 'O' && !visited[i, 0])
                    MarkInvalid(i, 0, board, visited);

            for (int i = 0; i <= board.GetLength(0) - 1; i++) // 最后一行
                if (board[i, board.GetLength(1) - 1] == 'O' && !visited[i, board.GetLength(1) - 1])
                    MarkInvalid(i, board.GetLength(1) - 1, board, visited);

            for (int i = 0; i <= board.GetLength(0) - 1; i++)
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                    if (board[i, j] == '-')
                        board[i, j] = 'O';
                    else
                        board[i, j] = 'X';
        }

        private void MarkInvalid(int x, int y, char[,] board, bool[,] visited)
        {
            visited[x, y] = true;
            board[x, y] = '-';

            if (x - 1 > 0 && board[x - 1, y] != 'X' && !visited[x - 1, y])
                MarkInvalid(x - 1, y, board, visited);
            if (x + 1 < board.GetLength(0) - 1 && board[x + 1, y] != 'X' && !visited[x + 1, y])
                MarkInvalid(x + 1, y, board, visited);
            if (y - 1 > 0 && board[x, y - 1] != 'X' && !visited[x, y - 1])
                MarkInvalid(x, y - 1, board, visited);
            if (y + 1 < board.GetLength(1) && board[x, y + 1] != 'X' && !visited[x, y + 1])
                MarkInvalid(x, y + 1, board, visited);
        }
    }
}
