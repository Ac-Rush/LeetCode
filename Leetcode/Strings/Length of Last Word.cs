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

        public int LengthOfLastWord2(string s)
        {
            var end = s.Length - 1;
            var length = 0;
            ///  while (end >= 0 && s[end--] == ' ') ;  my bug
            while (end >= 0 && s[end] == ' ') end--;
            while (end >= 0 && s[end--] != ' ') length++;
            return length;
        }
    }
}
