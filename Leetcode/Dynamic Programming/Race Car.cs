using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Race_Car
    {
        public int RaceCar(int target)
        {
            int[] dp = new int[target + 3];
            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0; dp[1] = 1; dp[2] = 4;

            for (int t = 3; t <= target; ++t)
            {
                int k = 32 - LeadingZeroes(t);
                if (t == (1 << k) - 1)
                {
                    dp[t] = k;
                    continue;
                }
                for (int j = 0; j < k - 1; ++j)
                    dp[t] = Math.Min(dp[t], dp[t - (1 << (k - 1)) + (1 << j)] + k - 1 + j + 2);
                if ((1 << k) - 1 - t < t)
                    dp[t] = Math.Min(dp[t], dp[(1 << k) - 1 - t] + k + 1);
            }

            return dp[target];
        }
        private int LeadingZeroes(int value)
        {
            return (32 - (Convert.ToString(value, 2).Length));
        }
    }

    class Race_Car_2
    {
        /*
    For the input 5, we can reach with only 7 steps: AARARAA. Because we can step back.

Let's say n is the length of target in binary and we have 2 ^ (n - 1) <= target < 2 ^ n
We have 2 strategies here:
1. Go pass our target , stop and turn back
We take n instructions of A.
1 + 2 + 4 + ... + 2 ^ (n-1) = 2 ^ n - 1
Then we turn back by one R instruction.
In the end, we get closer by n + 1 instructions.

2. Go as far as possible before pass target, stop and turn back
We take N - 1 instruction of A and one R.
Then we take m instructions of A, where m < n     


    */
        int[] dp = new int[10000];
        public int RaceCar(int t)
        {
            if (dp[t] > 0) return dp[t];
            int n = (int)(Math.Log(t) / Math.Log(2)) + 1; // == log2(t) + 1
            if (1 << n == t + 1) dp[t] = n; //如果正好到，
            else
            {
                dp[t] = RaceCar((1 << n) - 1 - t) + n + 1; //超过了， 转向  反向走多出的部分
                for (int m = 0; m < n - 1; ++m)  //或者不超过，走到n-1 
                    dp[t] = Math.Min(dp[t], RaceCar(t - (1 << (n - 1)) + (1 << m)) + n + m + 1);
            }
            return dp[t];
        }
        private int LeadingZeroes(int value)
        {
            return (32 - (Convert.ToString(value, 2).Length));
        }
    }
}
