using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SlidingWindow
{
    class Permutation_in_String
    {
        /// <summary>
        /// https://leetcode.com/problems/permutation-in-string/discuss/102590/8-lines-slide-window-solution-in-Java
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            int[] count = new int[128];
            for (int i = 0; i < s1.Length; i++) count[s1[i]]--;
            for (int l = 0, r = 0; r < s2.Length; r++)
            {
                if (++count[s2[r]] > 0)  //如果有一个不在 s1中的字字母
                    while (--count[s2[l++]] != 0) { /* do nothing */} // 移动i 恢复count[] // 恢复后 l = r+1
                else if ((r - l + 1) == s1.Length) return true;
            }
            return s1.Length == 0;
        }
    }
}
