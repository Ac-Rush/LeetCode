using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
    /*
     
        The idea is try to replace every "++" in the current string s to "--" and see if the opponent can win or not, if the opponent cannot win, great, we win!

For the time complexity, here is what I thought, let's say the length of the input string s is n,
there are at most n - 1 ways to replace "++" to "--" (imagine s is all "+++..."), once we replace one "++", there are at most (n - 2) - 1 ways to do the replacement, it's a little bit like solving the N-Queens problem, the time complexity is (n - 1) x (n - 3) x (n - 5) x ..., so it's O(n!!), double factorial.
    */
    class Flip_Game_II
    {
        public bool CanWin(String s)
        {
            if (s == null || s.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '+'  && s[i+1] == '+')  // back tracking 每一组可能的都去试试，
                {
                    String t = s.Substring(0, i) + "--" + s.Substring(i + 2);

                    if (!CanWin(t))
                    {
                        return true;  //如果有一组成功就返回 true
                    }
                }
            }

            return false;  //如果都不行就返回 false
        }
    }
}
