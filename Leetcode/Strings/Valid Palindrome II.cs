using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    public class Valid_Palindrome_II
    {
        public static  bool ValidPalindrome(String s)
        {
            int l = -1, r = s.Length;
            while (++l < --r)
                if (s[l] != s[r]) return isPalindromic(s, l, r + 1) || isPalindromic(s, l - 1, r);
            return true;
        }

        public static bool isPalindromic(String s, int l, int r)
        {
            while (++l < --r)
                if (s[l] != s[r]) return false;
            return true;
        }




        /// <summary>
        /// my solution 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindromeMy(string s)
        {
            if (IsValidPalindrome(s, 0, s.Length - 1))
            {
                return true;
            }
            for (int i = 0; i < s.Length; i++)
            {
                
                    if (IsValidPalindrome(s, 0, s.Length - 1 , i))
                    {
                        return true;
                    }
            }
            return false;
        }


        public static bool IsValidPalindrome(string s, int start, int end, int? skip=null)
        {
            while (start < end)
            {
                if (skip != null && start == skip.Value)
                {
                    start++;
                }
                if (skip != null && end == skip.Value)
                {
                    end--;
                }
                if (start < end && s[start++] != s[end--])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
