using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Palindrome_Permutation
    {
        /// <summary>
        /// goold my solution 一次就过
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CanPermutePalindrome(string s)
        {
            var count = new int[256];
            foreach (var c in s)
            {
                count[c]++;
            }
            var odd = 0;
            foreach (var n in count)
            {
                odd += n%2;
            }
            return odd <= 1;
        }
    }
}
