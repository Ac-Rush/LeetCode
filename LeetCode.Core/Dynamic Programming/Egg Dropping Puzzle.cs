using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{

    class Super_Egg_Drop
    {
        /*
         *
         * Drop eggs is a very classical problem.
Some people may come up with idea O(KN^2)
where dp[K][N] = 1 + max(dp[K - 1][i - 1],dp[K][N - i]) for i in 1...N.
However this idea is very brute force, for the reason that you check all possiblity.

So I consider this problem in a different way:
dp[M][K]means that, given K eggs and M moves,
what is the maximum number of floor that we can check.

The dp equation is:
dp[m][k] = dp[m - 1][k - 1] + dp[m - 1][k] + 1,
which means we take 1 move to a floor,
if egg breaks, then we can check dp[m - 1][k - 1] floors.
if egg doesn't breaks, then we can check dp[m - 1][k - 1] floors.

dp[m][k] is similar to the number of combinations and it increase exponentially to N
         */
        public int SuperEggDrop(int K, int N)
        {
            int[,] dp = new int[N + 1,K + 1];
            int m = 0;
            while (dp[m,K] < N)
            {
                ++m;
                for (int k = 1; k <= K; ++k)
                    dp[m,k] = dp[m - 1,k - 1] + dp[m - 1,k] + 1;
            }
            return m;
        }

        /*
         *
         *firstly, if we have k eggs and s steps to detect a building with Q(k, s) floors,

secondly, we use 1 egg and 1 step to detect one floor,
if egg break, we can use (k-1) eggs and (s-1) to detect with Q(k-1, s-1),
if egg isn't broken, we can use k eggs and (s-1) step to detech with Q(k, s-1),
So, Q(k, s) = 1 + Q(k, s-1) + Q(k-1, s-1);
         *
         * dp[i] is max floors we can use i eggs and s step to detect.
         */
        public int SuperEggDrop3(int K, int N)
        {
            int[] dp = new int[K+1];
            int step = 0;
            for (; dp[K] < N; step++)
            {
                for (int i = K; i > 0; i--)
                    dp[i] = (1 + dp[i] + dp[i - 1]);
            }
            return step;
        }

        /// <summary>
        /// 优化到一维
        /// </summary>
        /// <param name="K"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int SuperEggDrop2(int K, int N)
        {
            int[] dp = new int[K + 1];
            int m = 0;
            for (m = 0; dp[K] < N; ++m)
            for (int k = K; k > 0; --k)
                dp[k] += dp[k - 1] + 1;
            return m;
        }
    }

    class Egg_Dropping_Puzzle
    {
        /*
         * 1) Optimal Substructure:
            When we drop an egg from a floor x, there can be two cases (1) The egg breaks (2) The egg doesn’t break.

            1) If the egg breaks after dropping from xth floor, then we only need to check for floors lower than x with remaining eggs; so the problem reduces to x-1 floors and n-1 eggs
            2) If the egg doesn’t break after dropping from the xth floor, then we only need to check for floors higher than x; so the problem reduces to k-x floors and n eggs.
         * 
         *  k ==> Number of floors
            n ==> Number of Eggs
            eggDrop(n, k) ==> Minimum number of trials needed to find the critical
                    floor in worst case.
            eggDrop(n, k) = 1 + min{max(eggDrop(n - 1, x - 1), eggDrop(n, k - x)):     // 1+ 是因为已经试了一次了， 如果碎了：eggDrop(n - 1, x - 1)  如果没碎 eggDrop(n, k - x)
                 x in {1, 2, ..., k}}
         * 
         * 
         */


        /* Function to get minimum number of 
    trials needed in worst case with n 
    eggs and k floors */
        static int EggDrop(int n, int k)
        {
            // If there are no floors, then 
            // no trials needed. OR if there
            // is one floor, one trial needed.
            if (k == 1 || k == 0)
                return k;

            // We need k trials for one egg
            // and k floors
            if (n == 1)
                return k;

            int min = int.MaxValue;
            int x, res;

            // Consider all droppings from 
            //1st floor to kth floor and
            // return the minimum of these
            // values plus 1.
            for (x = 1; x <= k; x++)
            {
                res = Math.Max(EggDrop(n - 1, x - 1),
                               EggDrop(n, k - x));
                if (res < min)
                    min = res;
            }

            return min + 1;
        }


        /* Function to get minimum number of 
   trials needed in worst case with n
   eggs and k floors */
        static int eggDropDP(int n, int k)
        {

            /* A 2D table where entery eggFloor[i][j]
            will represent minimum number of trials
            needed for i eggs and j floors. */
            int[,] eggFloor = new int[n + 1, k + 1];
            int res;
            int i, j, x;

            // We need one trial for one floor and0
            // trials for 0 floors
            for (i = 1; i <= n; i++)
            {
                eggFloor[i, 1] = 1;
                eggFloor[i, 0] = 0;
            }

            // We always need j trials for one egg
            // and j floors.
            for (j = 1; j <= k; j++)
                eggFloor[1, j] = j;

            // Fill rest of the entries in table 
            // using optimal substructure property
            for (i = 2; i <= n; i++)
            {
                for (j = 2; j <= k; j++)
                {
                    eggFloor[i, j] = int.MaxValue;
                    for (x = 1; x <= j; x++)
                    {
                        res = 1 + Math.Max(eggFloor[i - 1, x - 1],
                                      eggFloor[i, j - x]);
                        if (res < eggFloor[i, j])
                            eggFloor[i, j] = res;
                    }
                }
            }

            // eggFloor[n][k] holds the result
            return eggFloor[n, k];

        }
    }
}
