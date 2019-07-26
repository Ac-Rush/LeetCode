using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DAC
{
    //时间复杂度 O(n) ~ O(N^2)
    class Score_of_Parentheses
    {
        public int ScoreOfParentheses(string S)
        {
            return Helper(S, 0, S.Length-1);
        }

        private int Helper(string s, int l, int r)
        {
            if (r - l == 1) return 1;
            int b = 0;
            for (int i = l; i < r; i++)
            {
                if (s[i] == '(') b++;
                if (s[i] == ')') b--;
                if (b == 0)
                    //找到左边平衡的
                    return Helper(s, l, i) + Helper(s, i + 1, r);
            }
            //整个是平衡的
            return 2*Helper(s, l + 1, r - 1);
        }
    }

    //时间复杂度 O(N)Count Cores
    class Score_of_Parentheses_2
    {
        /// <summary>
        /// https://blog.csdn.net/qq2667126427/article/details/80793443
        /// 这个真棒
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public int ScoreOfParentheses(string S)
        {
            int ans = 0, bal = 0;
            for (int i = 0; i < S.Length; ++i)
            {
                if (S[i] == '(')
                {
                    bal++;  //数左括号的个数
                }
                else
                {
                    bal--;
                    if (S[i - 1] == '(')
                        ans += 1 << bal;
                }
            }

            return ans;
        }

    }
}
