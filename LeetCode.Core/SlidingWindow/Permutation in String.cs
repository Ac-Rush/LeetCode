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
        /// Now, we have an invalid substring with either invalid char or invalid number of chars.
        /// How to remove the invalid char and continue our scan? We use a left index ("l" in above code) to remove chars in the holes in the same order
        /// we filled them into the holes. We stop removing chars until the only sticking out block is fixed - it has a value of 0 after fixing. 
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
                    //remove the invalid char
                    while (--count[s2[l++]] != 0 /* <0 也可以*/ ) { /* do nothing */} // 移动i(remove the invalid char) 使得i的位置填满  e.g. {"adc" "dcda"}   d重复了，i就得移动到c
                else if ((r - l + 1) == s1.Length) return true;
            }
            return s1.Length == 0;
        }
    }
}
