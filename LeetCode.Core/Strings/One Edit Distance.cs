using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class One_Edit_Distance
    {
        /*
 * There're 3 possibilities to satisfy one edit distance apart: 
 * 
 * 1) Replace 1 char:
 	  s: a B c
 	  t: a D c
 * 2) Delete 1 char from s: 
	  s: a D  b c
	  t: a    b c
 * 3) Delete 1 char from t
	  s: a   b c
	  t: a D b c
 */
        public bool IsOneEditDistance(string s, string t)
        {
            for (int i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                if (s[i] != t[i])
                {
                    if (s.Length == t.Length) // s has the same length as t, so the only possibility is replacing one char in s and t  //情况1
                        return s.Substring(i + 1).Equals(t.Substring(i + 1));
                    else if (s.Length < t.Length) // t is longer than s, so the only possibility is deleting one char from t
                        return s.Substring(i).Equals(t.Substring(i + 1));
                    else // s is longer than t, so the only possibility is deleting one char from s
                        return t.Substring(i).Equals(s.Substring(i + 1));
                }
            }
            //All previous chars are the same, the only possibility is deleting the end char in the longer one of s and t 
            return Math.Abs(s.Length - t.Length) == 1;
        }
    }
}
