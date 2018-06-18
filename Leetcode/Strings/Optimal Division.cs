using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Optimal_Division
    {
        public string OptimalDivision(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0] + "";
            if (nums.Length == 2)
                return nums[0] + "/" + nums[1];
            StringBuilder res = new StringBuilder(nums[0] + "/(" + nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                res.Append("/" + nums[i]);
            }
            res.Append(")");
            return res.ToString();
        }
    }
}
