using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class GuessNumberC
    {
        int guess(int num)
        {
            return 0;
        }
        public int GuessNumber(int n)
        {
            int start = 1;
            int end = n;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                int ret = guess(mid);
                if (ret == 0)
                {
                    return mid;
                }
                else if (ret == 1)
                {
                    start = mid + 1;

                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}
