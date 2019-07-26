using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Bomb_Enemy
    {
        /// <summary>
        /// Walk through the matrix. At the start of each non-wall-streak (row-wise or column-wise), count the number of hits in that streak and remember it. O(mn) time, O(n) space.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MaxKilledEnemies(char[,] grid)
        {
            int m = grid.GetLength(0), n = m !=0 ? grid.GetLength(1) : 0;
            //rowhits  这一行当前位置可以炸死多少个
            int result = 0, rowhits = 0;
            var colhits = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   //行或列开始， 或是墙的开始 只需要往下或是右计算一次就好了
                    if (j == 0 || grid[i,j - 1] == 'W')
                    {
                        rowhits = 0; //如果是第一列  或是 左边是墙，  rowhits =0;
                        for (int k = j; k < n && grid[i,k] != 'W'; k++)  //计算右面可以炸死的， 
                            rowhits += grid[i,k] == 'E'? 1:0;
                    }
                    if (i==0 || grid[i - 1,j] == 'W')
                    {
                        colhits[j] = 0;  //如果是第一行，或上面是墙，  colhits[j] = 0
                        for (int k = i; k < m && grid[k,j] != 'W'; k++) //计算下面可以炸死的， 
                            colhits[j] += grid[k,j] == 'E' ? 1 : 0;
                    }
                    if (grid[i,j] == '0')
                        result = Math.Max(result, rowhits + colhits[j]);  //如果是 empty算下max
                }
            }
            return result;
        }
    }
}
