using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Majority_Element
    {
        /// <summary>
        /// 太巧妙
        /// 两两相消
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int count = 0;
            int? candidate = null;
            
            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                }
                count += (num == candidate) ? 1 : -1;
            }

            return candidate.Value;
        }
    }
}
