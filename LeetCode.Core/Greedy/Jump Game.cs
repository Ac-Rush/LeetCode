using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Jump_Game_BackTracking
    {
        //递归求解  超时
        //O(2^N)
        public bool CanJump(int[] nums)
        {
            return canJumpFromPosition(0, nums);
        }
        public bool canJumpFromPosition(int position, int[] nums)
        {
            if (position == nums.Length - 1)
            {
                return true;
            }

            int furthestJump = Math.Min(position + nums[position], nums.Length - 1);
            for (int nextPosition = position + 1; nextPosition <= furthestJump; nextPosition++)
            {
                if (canJumpFromPosition(nextPosition, nums))
                {
                    return true;
                }
            }

            return false;
        }
    }


    class Jump_Game_BackTracking_Memo
    {
        //递归求解 + memo 超时
        //O(N^2)
        public bool CanJump(int[] nums)
        {
            var canJump = new bool?[nums.Length];
            return canJumpFromPosition(0, nums, canJump);
        }
        public bool canJumpFromPosition(int position, int[] nums, bool?[] canJump)
        {
            if (canJump[position] != null)
            {
                return canJump[position].Value;
            }
            if (position == nums.Length - 1)
            {
                return true;
            }

            int furthestJump = Math.Min(position + nums[position], nums.Length - 1);
            for (int nextPosition = position + 1; nextPosition <= furthestJump; nextPosition++)
            {
                if (canJumpFromPosition(nextPosition, nums, canJump))
                {
                    canJump[position] = true;
                    return true;
                }
            }
            canJump[position] = false;
            return false;
        }
    }

    class Jump_Game_DP
    {
        //dp  bottom up 
        //O(N^2)
        enum Index
        {
            GOOD, BAD, UNKNOWN
        }
        public bool CanJump(int[] nums)
        {
            Index[] memo = new Index[nums.Length];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = Index.UNKNOWN;
            }
            memo[memo.Length - 1] = Index.GOOD;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int furthestJump = Math.Min(i + nums[i], nums.Length - 1);
                for (int j = i + 1; j <= furthestJump; j++)
                {
                    if (memo[j] == Index.GOOD)
                    {
                        memo[i] = Index.GOOD;
                        break;
                    }
                }
            }

            return memo[0] == Index.GOOD;
        }
        
    }


    class Jump_Game_GreeD
    {
        //贪心
        // O(n)O(n)
        /// <summary>
        /// 从后往前， 更新 lastPos， 如果 从i能够跳到lastPos， lastPos跟新成 i
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public bool CanJump(int[] nums)
        {
            int lastPos = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastPos)
                {
                    lastPos = i;
                }
            }
            return lastPos == 0;
        }

        /// <summary>
        /// 这个好理解
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        bool canJump2(int[] A, int n)
        {
            int i = 0;
            for (int reach = 0; i < n && i <= reach; ++i)
                reach = Math.Max(i + A[i], reach);
            return i == n;
        }

    }

    class Jump_Game_GreeD2
    {
        //贪心
        // O(n)O(n)
        /// <summary>
        /// 从后往前， 更新 lastPos， 如果 从i能够跳到lastPos， lastPos跟新成 i
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>

        public bool CanJump(int[] nums)
        {
            if (nums.Length <= 1) return true;
            int curMax = nums[0]; // to mark the last element in a level
            int level = 1, i = 1;  //注意初始化
            while (i <= curMax)
            {
                if (curMax >= nums.Length - 1) return true;
                int furthest = curMax; // to mark the last element in the next level
                for (; i <= curMax; i++)
                {
                    furthest = Math.Max(furthest, nums[i] + i);
                }
                level++;
                curMax = furthest;  //每一步能走多远
            }
            return false; // if i < curMax, i can't move forward anymore (the last element in the array can't be reached)
        }

    }
}
