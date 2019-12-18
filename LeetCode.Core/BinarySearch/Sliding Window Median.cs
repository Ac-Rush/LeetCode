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
            List<double> llist = new List<double>(); // 存放结果

            if (nums == null || nums.Length <= 0 || k <= 0) return llist.ToArray<double>(); // validation

            int liPos1 = (k >> 1);  // 第一个数， 右边的
            int liPos2 = liPos1 + (k & 1) - 1; //第二个数， 左边的

            List<double> llistSlid = new List<double>(); // k的数组

            for (int i = 0; i < nums.Length; ++i)
            {
                if (i >= k)
                {
                    llistSlid.Remove(nums[i - k]);
                }

                int liIndex = llistSlid.BinarySearch(nums[i]);  //二分查找
                if (liIndex < 0)
                {
                    liIndex = ~liIndex;  //  liIndex = -liIndex - 1;
                }
                llistSlid.Insert(liIndex, nums[i]); // 有序插入

                if (i >= k - 1)
                    llist.Add(liPos1 == liPos2 ? llistSlid[liPos1] : ((llistSlid[liPos1] + llistSlid[liPos2]) / 2));
            }

            return llist.ToArray<double>();
        }
    }
}
