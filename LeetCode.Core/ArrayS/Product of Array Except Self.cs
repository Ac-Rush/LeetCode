using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Product_of_Array_Except_Self
    {
        /// <summary>
        ///  这个是 dp， 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            res[0] = 1;
            for (int i = 1; i < n; i++)  //左边的乘机
            {
                res[i] = res[i - 1] * nums[i - 1];
            }
            int right = 1;  //右边的乘机
            for (int i = n - 1; i >= 0; i--)
            {
                res[i] *= right;
                right *= nums[i];
            }
            return res;
        }
    }
}
