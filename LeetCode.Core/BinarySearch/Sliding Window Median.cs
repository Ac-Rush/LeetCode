using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Sliding_Window_Median
    {
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            List<double> llist = new List<double>();

            if (nums != null && nums.Length > 0 && k > 0)
            {
                int liPos1 = (k >> 1);
                int liPos2 = liPos1 + (k & 1) - 1;

                List<double> llistSlid = new List<double>();

                for (int i = 0; i < nums.Length; ++i)
                {
                    if (i >= k)
                    {
                        llistSlid.Remove(nums[i - k]);
                    }

                    int liIndex = llistSlid.BinarySearch(nums[i]);
                    if (liIndex < 0)
                    {
                        liIndex = ~liIndex;
                    }
                    llistSlid.Insert(liIndex, nums[i]);

                    if (i >= k - 1)
                        llist.Add(liPos1 == liPos2 ? llistSlid[liPos1] : ((llistSlid[liPos1] + llistSlid[liPos2]) / 2));
                }
            }

            return llist.ToArray<double>();
        }
    }
}
