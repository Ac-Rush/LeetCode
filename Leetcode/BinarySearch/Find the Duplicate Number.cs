using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Find_the_Duplicate_Number
    {

        /// <summary>
        /// 技巧性太强
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicate(int[] nums)
        {
            if (nums.Length > 1)
            {
                int slow = nums[0];
                int fast = nums[nums[0]];
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                }

                fast = 0;
                while (fast != slow)
                {
                    fast = nums[fast];
                    slow = nums[slow];
                }
                return slow;
            }
            return -1;
        }


        public int findDuplicate2(int[] nums)
        {
            // Find the intersection point of the two runners.
            int tortoise = nums[0];
            int hare = nums[0];
            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            // Find the "entrance" to the cycle.
            int ptr1 = nums[0];
            int ptr2 = tortoise;
            while (ptr1 != ptr2)
            {
                ptr1 = nums[ptr1];
                ptr2 = nums[ptr2];
            }

            return ptr1;
        }
    }
}
