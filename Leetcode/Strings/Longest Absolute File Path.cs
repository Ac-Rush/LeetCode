using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Longest_Absolute_File_Path
    {
        public int LengthLongestPath(string input)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0); // "dummy" length
            int maxLen = 0;
            foreach (String s in input.Split('\n'))
            {
                int lev = s.LastIndexOf("\t") + 1; // number of "\t"
                while (lev + 1 < stack.Count) stack.Pop(); // find parent
                int len = stack.Peek() + s.Length - lev + 1; // remove "/t", add"/"
                stack.Push(len);
                // check if it is file
                if (s.Contains(".")) maxLen = Math.Max(maxLen, len - 1);
            }
            return maxLen;
        }
    }
}
