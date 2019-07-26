using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Find_the_Duplicate_Number
    {
       
        public int FindDuplicate(int[] nums)
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
        /// <summary>
        /// The main idea is the same with problem Linked List Cycle II,https://leetcode.com/problems/linked-list-cycle-ii/.
        /// Use two pointers the fast and the slow. The fast one goes forward two steps each time,
        /// while the slow one goes only step each time. They must meet the same item when slow==fast.
        /// In fact, they meet in a circle, the duplicate number must be the entry point of the circle when visiting the array from nums[0].
        /// Next we just need to find the entry point. We use a point(we can use the fast one before) to visit form begining with one step each time,
        /// do the same job to slow. When fast==slow, they meet at the entry point of the circle. The easy understood code is as follows.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        int FindDuplicate3(int[] nums)
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
    }
}
