using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Sort
{
    class Largest_Number
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            var list = nums.Select(num => num.ToString()).ToList();
            list.Sort((a,b) => ((a+b).CompareTo(b+a)));
            if (list[nums.Length - 1].Equals("0"))
            {
                return "0";
            }
            var sb = new StringBuilder();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                sb.Append(list[i]);
            }
            
            return sb.ToString();
        }

        
    }
}
