using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Length_of_Last_Word
    {
        public int LengthOfLastWord(string s)
        {
            var setments = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (setments.Length == 0)
            {
                return 0;
            }
            return setments.Last().Length;
        }
    }
}
