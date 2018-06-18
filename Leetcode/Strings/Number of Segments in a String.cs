using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Number_of_Segments_in_a_String
    {
        public int CountSegments(string s)
        {
            
            return s.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Length ;
        }
    }
}
