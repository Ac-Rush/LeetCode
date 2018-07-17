using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    class Max_Chunks_To_Make_Sorted_II
    {
        public int MaxChunksToSorted(int[] arr)
        {
            int n = arr.Length;
            int[] maxOfLeft = new int[n];
            int[] minOfRight = new int[n];

            maxOfLeft[0] = arr[0];
            for (int i = 1; i < n; i++)
            {
                maxOfLeft[i] = Math.Max(maxOfLeft[i - 1], arr[i]);  //统计 左边最大
            }

            minOfRight[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                minOfRight[i] = Math.Min(minOfRight[i + 1], arr[i]);  //统计右边最小
            }

            int res = 0;
            for (int i = 0; i < n - 1; i++)
            {
                //这里注意 必须是前一个和后一个
                if (maxOfLeft[i] <= minOfRight[i + 1]) res++;  //如果这个点 左边最大的要小于右边最小的， 那么 就可以是一组
            }

            return res + 1;
        }
    }
}
