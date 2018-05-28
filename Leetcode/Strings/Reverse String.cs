using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_String
    {
        

        public string ReverseString2(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
