using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Detect_Capital
    {
        public bool DetectCapitalUse(string word)
        {
            bool hasLower = false;
            var lastUpperIndex = 0; // my bug was -1
            
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] >= 'A' && word[i] <= 'Z')
                {
                    lastUpperIndex = i;
                    if (hasLower == true) return false;
                }
                else
                {
                    hasLower = true;
                    if (lastUpperIndex != 0)
                    {
                        return false;
                    }
                } 
            }
            return true;
        }
    }
}
