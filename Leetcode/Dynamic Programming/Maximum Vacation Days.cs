using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// 超时
    /// </summary>
    class Maximum_Vacation_Days_DFS
    {
        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            return dfs(flights, days, 0, 0);
        }
        public int dfs(int[,] flights, int[,] days, int cur_city, int weekno)
        {
            if (weekno == days.GetLength(1))
                return 0;
            int maxvac = 0;
            for (int i = 0; i < flights.GetLength(1); i++)
            {
                if (flights[cur_city, i] == 1 || i == cur_city)
                {
                    int vac = days[i,weekno] + dfs(flights, days, i, weekno + 1);
                    maxvac = Math.Max(maxvac, vac);
                }
            }
            return maxvac;
        }
    }


    /// <summary>
    /// 其实我觉得 DP就是由 递归或搜索树推出来的， 然后找重复，并且用 memo来记录，以便重复利用， 来减少 时间复杂度
    /// </summary>
    class Maximum_Vacation_Days_DFS_memo
    {
        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            int[,] memo = new int[flights.GetLength(0),days.GetLength(1)];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = int.MinValue;
                }
            }
            return dfs(flights, days, 0, 0, memo);
        }
        public int dfs(int[,] flights, int[,] days, int cur_city, int weekno, int[,] memo)
        {
            if (weekno == days.GetLength(1))
                return 0;
            if (memo[cur_city,weekno] != int.MinValue)
                return memo[cur_city, weekno];
            int maxvac = 0;
            for (int i = 0; i < flights.GetLength(1); i++)
            {
                if (flights[cur_city, i] == 1 || i == cur_city)
                {
                    int vac = days[i, weekno] + dfs(flights, days, i, weekno + 1, memo);
                    maxvac = Math.Max(maxvac, vac);
                }
            }
            memo[cur_city, weekno] = maxvac;
            return maxvac;
        }
    }

    class Maximum_Vacation_Days_DP
    {
        /// <summary>
        /// 但前的假 只依赖以后的 不依赖之前的
        /// </summary>
        /// <param name="flights"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public int MaxVacationDays(int[,] flights, int[,] days)
        {
            if (days.Length == 0 || flights.Length == 0) return 0;
            int[,] dp = new int[days.GetLength(0),days.GetLength(1) + 1];
            for (int week = days.GetLength(1) - 1; week >= 0; week--)
            {
                for (int cur_city = 0; cur_city < days.GetLength(0); cur_city++)
                {
                    dp[cur_city,week] = days[cur_city,week] + dp[cur_city,week + 1];
                    for (int dest_city = 0; dest_city < days.GetLength(0); dest_city++)
                    {
                        if (flights[cur_city,dest_city] == 1)
                        {
                            dp[cur_city,week] = Math.Max(days[dest_city,week] + dp[dest_city,week + 1], dp[cur_city,week]);
                        }
                    }
                }
            }
            return dp[0,0];
        }
    }
}
