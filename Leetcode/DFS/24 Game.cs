using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    /// <summary>
    /// Easy to understand. Backtracking.
    /// 这个 24点 好像是 前后可以换序，所以才有以下答案
    /// </summary>
    class _24_Game
    {
        public bool JudgePoint24(int[] nums)
        {
            var A = nums.Select(v => (double) v).ToList();
            return solve(A);
        }

        private bool solve(List<double> nums)
        {
            if (nums.Count == 0) return false;
            if (nums.Count == 1) return Math.Abs(nums[0] - 24) < 1e-6;

            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 0; j < nums.Count; j++)
                {
                    if (i != j)
                    {
                        var nums2 = new List<double>();
                        for (int k = 0; k < nums.Count; k++) if (k != i && k != j)
                            {
                                nums2.Add(nums[k]);
                            }
                        for (int k = 0; k < 4; k++)
                        {
                            if (k < 2 && j > i) continue;
                            if (k == 0) nums2.Add(nums[i] + nums[j]);
                            if (k == 1) nums2.Add(nums[i] * nums[j]);
                            if (k == 2) nums2.Add(nums[i] -nums[j]);
                            if (k == 3)
                            {
                                if (nums[j] != 0)
                                {
                                    nums2.Add(nums[i] /nums[j]);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (solve(nums2)) return true;
                            nums2.RemoveAt(nums2.Count - 1);
                        }
                    }
                }
            }
            return false;
        }
    }
}
