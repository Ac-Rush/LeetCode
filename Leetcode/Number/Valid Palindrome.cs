using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    public class Valid_Palindrome
    {
        public static bool IsPalindrome(string s)
        {
            var start = 0;
            var end = s.Length - 1;
            s = s.ToLower();
            while (start < end)
            {
                while (!((s[start] >= 'a' && s[start] <= 'z') || s[start] >= '0' && s[start] <= '9') && start <end) start++;

                while (!((s[end] >= 'a' && s[end] <= 'z') || s[end] >= '0' && s[end] <= '9') && start < end) end--; //my bug
                if (start < end)
                {
                    if (s[start] != s[end])
                    {
                        return false;
                    }
                }
                start ++; //my bug
                end --;
            }
            return true;
        }

        public static bool IsPalindrome2(string s)
        {
            string actual = Regex.Replace(s,"[^A-Za-z0-9]", "").ToLower();
            string rev = new string(actual.Reverse().ToArray());
            return actual.Equals(rev);
        }


        public static bool IsPalindrome4(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                while (l < r && !char.IsLetterOrDigit(s[l])) l++;
                while (l < r && !char.IsLetterOrDigit(s[r])) r--;
                if (l < r && char.ToLower(s[l++]) != char.ToLower(s[r--])) return false;
            }
            return true;
        }
    }
}
