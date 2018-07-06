using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Heap
{
    class Find_K_Pairs_with_Smallest_Sums
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<int[]> list = new List<int[]>();

            k = Math.Min(k, nums1.Length * nums2.Length);
            int[] idx = new int[Math.Min(k, nums1.Length)]; // 这个装的是  index[i] 表示 nums1 里的 i找到了 nums2 里的 index[i] 配对

            while (list.Count < k)
            {
                // find next smallest pair
                int minPairIndex = -1;
                for (int i = 0; i < idx.Length; i++)
                {
                    // skip num1 elems that have already used all their pairs
                    if (idx[i] < nums2.Length)
                    {
                        if (minPairIndex == -1 || nums1[i] + nums2[idx[i]] < nums1[minPairIndex] + nums2[idx[minPairIndex]])
                        {
                            minPairIndex = i;
                        }
                    }
                }

                list.Add(new int[] { nums1[minPairIndex], nums2[idx[minPairIndex]] });
                idx[minPairIndex]++;//指向下一个
            }

            return list;
        }
    }

    /// <summary>
    /// c# 没有 PQ 如何去重
    /// //嘎嘎 my work around； 
    ///  之前是这样的new int[] { nums1[i], nums2[0], 0  }   {第一个数， 第二个数， 第二个数的下标}
    ///  变成了new int[] { nums1[i], nums2[0], 0 ,i }  增加了 第一个数的下标， 这样根据第一个数的下标去重就可以了
    /// </summary>
    class Find_K_Pairs_with_Smallest_Sums_wrong
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var ans = new List<int[]>();
            if (nums1.Length == 0 || nums2.Length == 0 || k == 0) return ans;
            var heap = new SortedSet<int[]>(Comparer<int[]>.Create((a, b) =>
            {
                var result = a[0] + a[1] - b[0] - b[1];
                if (result == 0)
                {
                    return a[3] - b[3];
                }
                return result;
            }));

            for (int i = 0; i < nums1.Length && i < k; i++) heap.Add(new int[] { nums1[i], nums2[0], 0 , i });
            while (k-- > 0 && heap.Any())
            {
                int[] cur = heap.Min;
                ans.Add(new int[] { cur[0], cur[1] });
                heap.Remove(cur);
                if (cur[2] == nums2.Length - 1) continue;
                heap.Add(new int[] { cur[0], nums2[cur[2] + 1], cur[2] + 1 , cur[3] });
            }
            return ans;
        }
    }
}
