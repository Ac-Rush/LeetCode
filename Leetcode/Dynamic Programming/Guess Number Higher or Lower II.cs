using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// Approach #3 Using DP [Accepted]
    /// N^3的时间复杂度
    /// </summary>
    class Guess_Number_Higher_or_Lower_II_Dp_Better
    {
        public int GetMoneyAmount(int n)
        {
            var dp = new int[n + 1, n + 1];
            for (int len = 2; len <= n; len++) // 对于这种 range 来做的DP， 要根据 len 来 loop
            {
                for (int start = 1; start <= n - len + 1; start++)
                {
                    int minres = Int32.MaxValue;
                    for (int piv = start + (len - 1) / 2; piv < start + len - 1; piv++) //修改 开始点来判断
                    {
                        int res = piv + Math.Max(dp[start, piv - 1], dp[piv + 1, start + len - 1]);
                        minres = Math.Min(res, minres);
                    }
                    dp[start, start + len - 1] = minres;
                }
            }
            return dp[1, n];
        }

    }


    /// <summary>
    /// Approach #3 Using DP [Accepted]
    /// N^3的时间复杂度
    /// </summary>
    class Guess_Number_Higher_or_Lower_II_Dp
    {
        public int GetMoneyAmount(int n)
        {
            var dp = new int[n + 1,n + 1];
            for (int len = 2; len <= n; len++) // 对于这种 range 来做的DP， 要根据 len 来 loop
            {
                for (int start = 1; start <= n - len + 1; start++)
                {
                    int minres = Int32.MaxValue;
                    for (int piv = start; piv < start + len - 1; piv++)
                    {
                        int res = piv + Math.Max(dp[start,piv - 1], dp[piv + 1,start + len - 1]);
                        minres = Math.Min(res, minres);
                    }
                    dp[start,start + len - 1] = minres;
                }
            }
            return dp[1,n];
        }
       
    }

    /// <summary>
    /// Approach #3 Using DP [Accepted]
    /// N^3的时间复杂度
    /// </summary>
    class Guess_Number_Higher_or_Lower_II_Memo
    {
        private int?[,] memo;
        public int GetMoneyAmount(int n)
        {
            memo = new int?[n + 1,n + 1];
            return calculate(1, n);
        }
        public int calculate(int low, int high)
        {
            if (low >= high)
                return 0;
            if (memo[low, high] != null)
            {
                return memo[low, high].Value;
            }
            int minres = Int32.MaxValue;
            for (int i = low; i <= high; i++)
            {
                int res = i + Math.Max(calculate(i + 1, high), calculate(low, i - 1));  //构造递归解空间，遍历每个i， i+ (i+1, high) 还是 (low, i-1)
                minres = Math.Min(res, minres);
            }
            memo[low, high] = minres;
            return minres;
        }
    }

    /// <summary>
    /// 首先想的应该是暴力解法
    /// Approach #1 Brute Force [Time Limit Exceeded]
    /// N！时间复杂度
    /// </summary>
    class Guess_Number_Higher_or_Lower_II_BF
    {
        public int GetMoneyAmount(int n)
        {
            return calculate(1, n);
        }
        public int calculate(int low, int high)
        {
            if (low >= high)
                return 0;
            int minres = Int32.MaxValue;
            for (int i = low; i <= high; i++)
            {
                int res = i + Math.Max(calculate(i + 1, high), calculate(low, i - 1));  //构造递归解空间，遍历每个i， i+ (i+1, high) 还是 (low, i-1)
                minres = Math.Min(res, minres);
            }

            return minres;
        }
    }
}
