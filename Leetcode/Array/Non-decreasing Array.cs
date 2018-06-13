using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Non_decreasing_Array
    {
        public bool CheckPossibility(int[] nums)
        {
            int? index = null;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i -1])
                {
                    if (index != null)
                    {
                        return false;
                    }
                    else
                    {
                        index = i - 1;
                    }


                }
            }
            return index == null || index.Value ==0 || index.Value == nums.Length-2 || nums[index.Value -1]<=nums[index.Value +1] || nums[index.Value] <= nums[index.Value+2];
        }
    }
}
