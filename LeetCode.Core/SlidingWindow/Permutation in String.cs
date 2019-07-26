using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.SlidingWindow
{
    class Permutation_in_String
    {
        public bool CheckInclusion(string s1, string s2)
        {
            int[] count = new int[128];
            for (int i = 0; i < s1.Length; i++) count[s1[i]]--;
            for (int l = 0, r = 0; r < s2.Length; r++)
            {
                if (++count[s2[r]] > 0)  //如果有一个不在 s1中的字字母
                    while (--count[s2[l++]] != 0) { /* do nothing */} // 移动i 恢复count[]
                else if ((r - l + 1) == s1.Length) return true;
            }
            return s1.Length == 0;
        }
    }
}
