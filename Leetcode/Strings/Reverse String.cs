using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_String
    {

        public void ReverseString(char[] s)
        {
            var l = 0;
            var r = s.Length - 1;
            while (l < r)
            {
                var t = s[l];
                s[l++] = s[r];
                s[r--] = t;
            }
        }
        public string ReverseString2(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
