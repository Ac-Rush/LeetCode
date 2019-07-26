using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Backspace_String_Compare
    {
        // two pointer 的解法 不错
        public bool BackspaceCompare(string S, string T)
        {
            int i = S.Length - 1, j = T.Length - 1;
            int skipS = 0, skipT = 0; //记录需要 skip多少次


            while (i >= 0 || j >= 0)
            { // While there may be chars in build(S) or build (T)
                while (i >= 0)
                { // Find position of next possible char in build(S)
                    if (S[i] == '#') { skipS++; i--; }
                    else if (skipS > 0) { skipS--; i--; }
                    else break;
                }
                while (j >= 0)
                { // Find position of next possible char in build(T)
                    if (T[j] == '#') { skipT++; j--; }
                    else if (skipT > 0) { skipT--; j--; }
                    else break;
                }
                // If two actual characters are different
                if (i >= 0 && j >= 0 && S[i] != T[j])
                    return false;
                // If expecting to compare char vs nothing
                if ((i >= 0) != (j >= 0))
                    return false;
                i--; j--;
            }
            return true;
        }
    }
}
