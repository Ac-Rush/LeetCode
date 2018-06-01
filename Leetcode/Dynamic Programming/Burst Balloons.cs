using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Burst_Balloons
    {
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

            int [,] store = new int[nums.Length, nums.Length];
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
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
