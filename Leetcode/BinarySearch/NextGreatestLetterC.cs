using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class NextGreatestLetterC
    {
        /// <summary>
        /// template
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            if (target >= letters[letters.Length - 1] || target < letters[0])
            {
                return letters[0];
            }

            int start = 0;
            int end = letters.Length - 1;

            while (start + 1 < end)
            {
                var mid = start + (end - start) / 2;
                if (letters[mid] == target)
                {
                    start = mid;
                }
                else if (letters[mid] < target)
                {
                    start = mid;
                }
                else
                {
                    end = mid;
                }
            }
            if (letters[end] <= target)
            {
                return letters[end + 1];
            }
            else if (letters[start] <= target)
            {
                return letters[end];
            }
            return letters[start];
        }

        /// <summary>
        /// find the first large than
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter2(char[] letters, char target)
        {
            int lo = 0, hi = letters.Length; //技巧性太强
            while (lo < hi)
            {
                int mi = lo + (hi - lo) / 2;
                if (letters[mi] <= target) lo = mi + 1;
                else hi = mi;
            }
            return letters[lo % letters.Length];
        }

        /// <summary>
        /// common way 
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter3(char[] letters, char target)
        {
            if (target >= letters[letters.Length - 1] || target < letters[0])
            {
                return letters[0];
            }
            int lo = 0, hi = letters.Length - 1; //技巧性太强
            while (lo < hi)
            {
                int mi = lo + (hi - lo) / 2;
                if (letters[mi] <= target) lo = mi + 1;
                else hi = mi;
            }
            return letters[lo];
        }
    }
}
