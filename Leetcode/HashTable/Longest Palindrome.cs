using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Longest_Palindrome
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindrome(string s)
        {
            var set = new int[58];
            foreach (var c in s)
            {
                set[c - 'A']++;
            }
            var middle = false;
            var count =0;
            foreach (var c in set)
            {
                if (c%2 == 0)
                {
                    count += c;
                }
                else
                {
                    if (middle == false)
                    {
                        count += 1;
                        middle = true;
                    }
                    count += c - 1;
                }
            }
            return count;
        }
    }
}
