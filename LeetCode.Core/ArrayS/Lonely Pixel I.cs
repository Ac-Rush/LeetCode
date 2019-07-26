using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Lonely_Pixel_I
    {
        public int FindLonelyPixel(char[,] picture)
        {
            Dictionary<int, int[]> rowMap = new Dictionary<int, int[]>();
            Dictionary<int, int[]> colMap = new Dictionary<int, int[]>();
            int cnt = 0;
            for (int i = 0; i < picture.GetLength(0); i++)
            {
                for (int j = 0; j < picture.GetLength(1); j++)
                {
                    if (picture[i, j] == 'B')  //如果是白色的 
                    {
                        if (!rowMap.ContainsKey(i)) rowMap[i] = new int[] { j, 0 };
                        if (!colMap.ContainsKey(j)) colMap[j] = new int[] { i, 0 };

                        rowMap[i][1]++;
                        colMap[j][1]++;

                        if (rowMap[i][1] == 1 && colMap[j][1] == 1)
                        {
                            cnt++;
                        }
                        else if (rowMap[i][1] == 2 && colMap[rowMap[i][0]][1] == 1)
                        {
                            cnt--;
                            colMap[rowMap[i][0]][1]++;
                        }
                        else if (colMap[j][1] == 2 && rowMap[colMap[j][0]][1] == 1)
                        {
                            cnt--;
                            rowMap[colMap[j][0]][1]++;
                        }
                        else
                        {
                            rowMap[i][1]++;
                            colMap[j][1]++;
                        }
                    }
                }
            }

            return cnt;
        }
    }

    class Lonely_Pixel_I_2
    {
        public int FindLonelyPixel(char[,] picture)
        {
             int n = picture.GetLength(0), m = picture.GetLength(1);

            int[] rowCount = new int[n], colCount = new int[m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (picture[i,j] == 'B') { rowCount[i]++; colCount[j]++; }

            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (picture[i,j] == 'B' && rowCount[i] == 1 && colCount[j] == 1) count++;

            return count;
        }
    }
}
