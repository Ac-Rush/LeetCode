using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Burst_Balloons3Dp
    {
        /// <summary>
        /// 从 devide concor 推到了 memorization 的DP方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxCoins(int[] nums)
        {

            int[] fullNums = new int[nums.Length + 2]; // defensive coding

            fullNums[0] = 1;
            fullNums[nums.Length + 1] = 1;

            for (int index = 1; index <= nums.Length; index++)
            {
                fullNums[index] = nums[index - 1];
            }

            var n = fullNums.Length;
            int[,] dp = new int[n,n];
            for (int k = 2; k < n; ++k)
                for (int left = 0; left < n - k; ++left)
                {
                    int right = left + k;
                    for (int i = left + 1; i < right; ++i)
                        dp[left,right] = Math.Max(dp[left,right],
                        nums[left] * nums[i] * nums[right] + dp[left,i] + dp[i,right]);
                }

            return dp[0,n - 1];
        }

        private int GetStore(int begin, int end, int[,] store, int[] fullNums)
        {
            if (begin > end) return 0;
            if (store[begin, end] > 0) return store[begin, end];

            for (int pos = begin; pos <= end; ++pos)
            {
                int leftCoin = GetStore(begin, pos - 1, store, fullNums);
                int midCoin = fullNums[begin - 1] * fullNums[pos] * fullNums[end + 1];
                int rightCoin = GetStore(pos + 1, end, store, fullNums);
                int coin = leftCoin + midCoin + rightCoin;
                if (coin > store[begin, end]) store[begin, end] = coin;
            }
            return store[begin, end];
        }
    }


    class Burst_Balloons2
    {
        /// <summary>
        /// 从 devide concor 推到了 memorization 的DP方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxCoins(int[] nums)
        {
            //倒推， 从 N! 到了 2^N 到了 n^2
            int[] fullNums = new int[nums.Length + 2]; // defensive coding

            fullNums[0] = 1;
            fullNums[nums.Length + 1] = 1;

            for (int index = 1; index <= nums.Length; index++)
            {
                fullNums[index] = nums[index - 1];
            }
            int[,] store = new int[nums.Length + 1, nums.Length + 1];
            return GetStore(1, fullNums.Length - 2, store, fullNums);
        }

        private int GetStore(int begin, int end, int[,] store, int[] fullNums)
        {
            if (begin > end) return 0;
            if (store[begin, end] >0) return store[begin, end];

            for (int pos = begin; pos <= end; ++pos)
            {
                int leftCoin = GetStore(begin, pos - 1, store, fullNums);
                int midCoin = fullNums[begin - 1] * fullNums[pos] * fullNums[end + 1]; /// 中间的是最后一个爆的， 而 [begin, pos -1]   [pos +1, end] 都已经爆了， 所以当前乘以fullNums[begin - 1]* fullNums[end + 1] 
                int rightCoin = GetStore(pos + 1, end, store, fullNums);
                int coin = leftCoin + midCoin + rightCoin;
                if (coin > store[begin, end]) store[begin, end] = coin;
            }
            return store[begin, end];
        }
    }


    class Burst_Balloons
    {
        /// <summary>
        /// 从 devide concor 推到了 memorization 的DP方法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxCoins(int[] nums)
        {
            //倒推， 从 N! 到了 2^N 到了 n^2
            int [] fullNums = new int[nums.Length + 2]; // defensive coding

            fullNums[0] = 1;
            fullNums[nums.Length + 1] = 1;

            for (int index = 1; index <= nums.Length; index++)
            {
                fullNums[index] = nums[index -1];
            }

            int [,] store = new int[nums.Length  +1 , nums.Length + 1];
            for (int i = 0; i <= nums.Length; i++)
            {
                for (int j = 0; j <= nums.Length; j++)
                {
                    store[i, j] = -1;
                }
            }
            return GetStore(1, fullNums.Length -2 , store ,fullNums );
        }

        private int GetStore(int begin, int end, int[,] store, int[] fullNums)
        {
            if (begin > end) return 0;
            if (store[begin, end] != -1) return store[begin, end];

            for (int pos = begin; pos <= end; ++pos)
            {
                int leftCoin = GetStore(begin, pos - 1, store, fullNums);
                int midCoin = fullNums[begin - 1]*fullNums[pos]*fullNums[end + 1];
                int rightCoin = GetStore(pos + 1, end, store, fullNums);
                int coin = leftCoin + midCoin + rightCoin;
                if (coin > store[begin, end]) store[begin, end] = coin;
            }
            return store[begin, end];
        }
    }
}
