using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Degree_of_an_Array
    {
        public int FindShortestSubArray(int[] nums)
        {
            if (nums.Length == 0 || nums == null) return 0;
            var map = new Dictionary<int, int[]>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map[nums[i]] =  new int[] { 1, i, i };  // the first element in array is degree, second is first index of this key, third is last index of this key
                }
                else
                {
                    int[] temp = map[nums[i]];
                    temp[0]++;
                    temp[2] = i;
                }
            }
            int degree = int.MinValue, res = int.MaxValue;
            foreach (int[] value in map.Values)
            {
                if (value[0] > degree)
                {
                    degree = value[0];
                    res = value[2] - value[1] + 1;
                }
                else if (value[0] == degree)
                {
                    res = Math.Min(value[2] - value[1] + 1, res);
                }
            }
            return res;
        }
    }
}
