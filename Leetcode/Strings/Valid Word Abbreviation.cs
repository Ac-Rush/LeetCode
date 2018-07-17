using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Valid_Word_Abbreviation
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int i = 0, j = 0;
            while (i < word.Length && j < abbr.Length)
            {
                if (word[i] == abbr[j])
                {
                    ++i; ++j;
                    continue;
                }
                if (abbr[j] <= '0' || abbr[j] > '9')
                {
                    return false;
                }
                int start = j;
                var n = 0;
                while (j < abbr.Length && abbr[j] >= '0' && abbr[j] <= '9')
                {
                    n = n*10 + abbr[j] - '0';
                    ++j;
                }
                i += n;
            }
            return i == word.Length && j == abbr.Length;
        }
    }
}
