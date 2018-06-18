using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_String_II
    {
        public string ReverseStr(string s, int k)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length;)
            {
                var len = Math.Min(k, s.Length - i);
                sb.Append(s.Substring(i, len).Reverse().ToArray()); // my bug was   sb.Append(s.Substring(i, len).Reverse());
                i += len;
                len = Math.Min(k, s.Length - i);
                sb.Append(s.Substring(i, len));
                i += len;
            }
            return sb.ToString();
        }
    }
}
