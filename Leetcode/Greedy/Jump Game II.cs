using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Greedy
{
    class Jump_Game_II
    {
        /// <summary>
        /// BFS  O（N）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            int curMax = 0; // to mark the last element in a level
            int level =0, i = 0;  //注意初始化
            while (i <= curMax)
            {
                int furthest = curMax; // to mark the last element in the next level
                for (; i <= curMax; i++)
                {
                    furthest = Math.Max(furthest, nums[i] + i);
                    if (furthest >= nums.Length - 1) return level +1;
                }
                level++;
                curMax = furthest;  //每一步能走多远
            }
            return -1; // if i < curMax, i can't move forward anymore (the last element in the array can't be reached)
        }
    }

    public class Jump_Game_II_My
    {
        /// <summary>
        /// BFS  O（N）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Jump(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            int curMax = nums[0]; // to mark the last element in a level
            int level = 1, i = 1;  //注意初始化
            while (i <= curMax)
            {
                if (curMax >= nums.Length - 1) return level;
                int furthest = curMax; // to mark the last element in the next level
                for (; i <= curMax; i++)
                {
                    furthest = Math.Max(furthest, nums[i] + i);
                }
                level++;
                curMax = furthest;  //每一步能走多远
            }
            return -1; // if i < curMax, i can't move forward anymore (the last element in the array can't be reached)
        }
    }
}
