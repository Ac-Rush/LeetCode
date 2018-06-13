﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinarySearch
{
    class Remove_Invalid_Parentheses
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            List<String> ans = new List<String>();
            remove(s, ans, 0, 0, new char[] { '(', ')' });
            return ans;
        }

        public void remove(String s, List<String> ans, int last_i, int last_j, char[] par)
        {
            for (int stack = 0, i = last_i; i < s.Length; ++i)
            {
                if (s[i] == par[0]) stack++;
                if (s[i] == par[1]) stack--;
                if (stack >= 0) continue;
                for (int j = last_j; j <= i; ++j)
                    if (s[j] == par[1] && (j == last_j || s[j-1] != par[1]))
                        remove(s.Substring(0, j) + s.Substring(j + 1, s.Length - j -1), ans, i, j, par);
                return;
            }
            String reversed = new string(s.Reverse().ToArray());
            if (par[0] == '(') // finished left to right
                remove(reversed, ans, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                ans.Add(reversed);
        }
    }
}
