using System;
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

        /*
         * Now one may ask. What about ‘(‘? What if s = ‘(()(()’ in which we need remove ‘(‘?
The answer is: do the same from right to left.
However a cleverer idea is: reverse the string and reuse the code!
         * 
         */
        public void remove(String s, List<String> ans, int last_i, int last_j, char[] par)
        {
            for (int stack = 0, i = last_i; i < s.Length; ++i)
            {
                if (s[i] == par[0]) stack++;  //计数模拟stack
                if (s[i] == par[1]) stack--;
                if (stack >= 0) continue; //合法的， continue
                for (int j = last_j; j <= i; ++j) // 得从 last_j 到i 去掉一个 par[1]
                    if (s[j] == par[1] && (j == last_j || s[j-1] != par[1])) // 这里还有去重 duplicate remove第一个
                        remove(s.Substring(0, j) + s.Substring(j + 1, s.Length - j -1), ans, i, j, par);
                return;  // return 也很关键，可以去重或是怎样
            }

            //其实是两种 情况 一种是 ( 多，，另一种是)多， 两种都要跑一变， 用reverse 来复用code
            String reversed = new string(s.Reverse().ToArray());
            if (par[0] == '(') // finished left to right
                remove(reversed, ans, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                ans.Add(reversed);
        }
    }
}
