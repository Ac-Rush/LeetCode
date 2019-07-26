using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    //重要
    class Target_Sum
    {
        /// <summary>
        /// 2D DP
        /// dp[i, sum] 表示，前i+1个数，可以组成sum的 方式总数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int S)
        {
            var n = nums.Length;
            var dp = new int[n, 2001];
            dp[0, nums[0] + 1000] = 1;
            dp[0, -nums[0] + 1000] += 1;
            for (int i = 1; i < n; i++)
            {
                for (int sum = -1000; sum <= 1000; sum++)
                {
                    if (dp[i - 1, sum + 1000] > 0) 
                    {
                        dp[i, sum + nums[i] + 1000] += dp[i - 1, sum + 1000];
                        dp[i, sum - nums[i] + 1000] += dp[i - 1, sum + 1000];
                    }
                }
            }
            return S > 1000 ? 0 : dp[n - 1, S + 1000];
        }

        /// <summary>
        /// 1D DP  ， 这个比记忆化搜索快多了 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int FindTargetSumWays2(int[] nums, int S)
        {
            var n = nums.Length;
            var dp = new int[ 2001];
            dp[nums[0] + 1000] = 1;
            dp[-nums[0] + 1000] += 1;
            for (int i = 1; i < n; i++)
            {
                int[] next = new int[2001];   //复制 next数组 来实现变成2行的 DP
                for (int sum = -1000; sum <= 1000; sum++)
                {
                    if (dp[ sum + 1000] > 0)
                    {
                        next[ sum + nums[i] + 1000] += dp[sum + 1000];
                        next[sum - nums[i] + 1000] += dp[sum + 1000];
                    }
                }
                dp = next;
            }


            return S > 1000 ? 0 : dp[S + 1000];
        }
    }


    class Target_Sum_DFS
    {
        private int count = 0;
        public int FindTargetSumWays(int[] nums, int S)
        {
            DFS(nums, S, 0, 0);
            return count;
        }

        private void DFS(int[] nums, int S, int curIndex, int cur)
        {
            if (curIndex == nums.Length)
            {
                if (cur == S)
                {
                    count++;  // 这么 计数不太好 Memo 换成了 下面的DFS2
                    //记忆化搜索是递归树，每个节点需要有返回值， 否则没法改成memo
                }
                return;
            }

            DFS(nums, S, curIndex + 1, cur + nums[curIndex]);
            DFS(nums, S, curIndex + 1, cur - nums[curIndex]);
        }
    }

    class Target_Sum_DFS2
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            return DFS(nums, S, 0, 0);
        }

        private int DFS(int[] nums, int S, int curIndex, int cur)
        {
            if (curIndex == nums.Length)
            {
                if (cur == S)
                {
                    return 1;
                }
                return 0;
            }

            var add = DFS(nums, S, curIndex + 1, cur + nums[curIndex]);
            var minus =  DFS(nums, S, curIndex + 1, cur - nums[curIndex]);
            return add + minus;
        }
    }

    class Target_Sum_DFS_Memo
    {
        private Dictionary<string, int> dict = new Dictionary<string, int>();
        public int FindTargetSumWays(int[] nums, int S)
        {
            return DFS(nums, S, 0, 0);
        }

        private int DFS(int[] nums, int S, int curIndex, int cur)
        {
            if (curIndex == nums.Length)
            {
                if (cur == S)
                {
                    return 1;
                }
                return 0;
            }
            var key = curIndex +"-" + cur;
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }

            var add = DFS(nums, S, curIndex + 1, cur + nums[curIndex]);
            var minus = DFS(nums, S, curIndex + 1, cur - nums[curIndex]);
            dict[key] = add + minus;
            return dict[key];
        }
    }
}
