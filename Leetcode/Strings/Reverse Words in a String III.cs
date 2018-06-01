using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_Words_in_a_String_III
    {
        public string ReverseWords(string s)
        {
            if (s == null)
            {
                return null;
            }
            var segments = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < segments.Length; index++)
            {
                var segment = segments[index];
                segments[index] = new string(segment.Reverse().ToArray());
            }
            return string.Join(" ", segments);
        }
    }
}
