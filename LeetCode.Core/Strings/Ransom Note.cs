using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Ransom_Note
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] arr = new int[26];
            foreach (var c in magazine)
            {
                arr[c - 'a']++;
            }
            foreach (var c in ransomNote)
            {
                if (arr[c - 'a']-- <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
