using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Perfect_Squares_DP
    {
        /// <summary>
        /// 我就觉得这个是个 DP的问题
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            // cntPerfectSquares[i] = the least number of perfect square numbers 
            // which sum to i. Note that cntPerfectSquares[0] is 0.
            var dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                // For each i, it must be the sum of some number (i - j*j) and 
                // a perfect square number (j*j).
                dp[i] = int.MaxValue;
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] =
                        Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }

            return dp[n];
        }

        bool is_square(int n)
        {
            int sqrt_n = (int)(Math.Sqrt(n));
            return (sqrt_n * sqrt_n == n);
        }
    }

    class Perfect_Squares_BFS
    {
        /// <summary>
        /// BFS, 按层遍历， count ++， 找到结果退出
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            if (n < 2)
            {
                return n;
            }

            var list = new List<int>();

            var i = 1;
            while (i*i <= n)
            {
                list.Add(i*i);
                i += 1;
            }
            var cnt = 0;
            var toCheck = new HashSet<int>() {n};  //用 set更好，估计会去重
            while (toCheck.Any())
            {
                cnt += 1;
                var temp = new HashSet<int>();
                foreach (var x in toCheck)
                {
                    foreach (var y in list)
                    {
                        if (x == y)
                        {
                            return cnt;
                        }
                        if (x < y)
                        {
                            break;

                        }
                        temp.Add(x - y);
                    }
                }
                toCheck = temp;
            }
            return cnt;

        }
    }

    class Perfect_Squares_Math
    {
        public int NumSquares(int n)
        {
            if (is_square(n))
            {
                return 1;
            }

            // The result is 4 if and only if n can be written in the 
            // form of 4^k*(8*m + 7). Please refer to 
            // Legendre's three-square theorem.
            while ((n & 3) == 0) // n%4 == 0  
            {
                n >>= 2;
            }
            if ((n & 7) == 7) // n%8 == 7
            {
                return 4;
            }

            // Check whether 2 is the result.
            int sqrt_n = (int)(Math.Sqrt(n));
            for (int i = 1; i <= sqrt_n; i++)
            {
                if (is_square(n - i * i))
                {
                    return 2;
                }
            }

            return 3;
        }

        bool is_square(int n)
        {
            int sqrt_n = (int)(Math.Sqrt(n));
            return (sqrt_n * sqrt_n == n);
        }
    }
}
