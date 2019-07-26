using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    public class TwoSumC
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return null;
            }
            var start = 0;
            var end = numbers.Length - 1;
            while (start + 1 < end)
            {
                if (numbers[start] + numbers[end] == target)
                {
                    return new[] { start + 1, end + 1 };
                }
                else if (numbers[start] + numbers[end] < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }

            if (numbers[start] + numbers[end] == target)
            {
                return new[] { start + 1, end + 1 };
            }
            return null;

        }


        public int[] TwoSum2(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return null;
            }
            var start = 0;
            var end = numbers.Length - 1;
            while (start < end)
            {
                if (numbers[start] + numbers[end] == target)
                {
                    return new[] { start + 1, end + 1 };
                }
                else if (numbers[start] + numbers[end] < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }


            return null;

        }
    }
}
