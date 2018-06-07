using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Ones_and_Zeroes
    {
        /// <summary>
        /// 这个是我想出来的
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int findMaxForm(String[] strs, int m, int n)
        {
            int l = strs.Length;
            var dp = new int[l + 1,m + 1,n + 1];

            for (int i = 0; i < l + 1; i++)
            {
                int[] nums = new int[] { 0, 0 };
                if (i > 0)
                {
                    nums = calculate(strs[i - 1]);
                }
                for (int j = 0; j < m + 1; j++)
                {
                    for (int k = 0; k < n + 1; k++)
                    {
                        if (i == 0)
                        {
                            dp[i,j,k] = 0;
                        }
                        else if (j >= nums[0] && k >= nums[1])
                        {
                            dp[i,j,k] = Math.Max(dp[i - 1,j,k], dp[i - 1,j - nums[0],k - nums[1]] + 1);
                        }
                        else
                        {
                            dp[i,j,k] = dp[i - 1,j,k];
                        }
                    }
                }
            }

            return dp[l,m,n];
        }

        private int[] calculate(string str)
        {
            int[] res = new int[2];

            foreach (char ch in str)
            {
                if (ch == '0')
                {
                    res[0]++;
                }
                else if (ch == '1')
                {
                    res[1]++;
                }
            }

            return res;
        }


        /// <summary>
        /// 其实可以用三维来想
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindMaxForm(string[] strs, int m, int n)
        {
            var max = new int[m + 1,n + 1];
            for (int i = 0; i < strs.Length; i++)
            {
                String str = strs[i];

                int neededZero = 0;
                int neededOne = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '0')
                    {
                        neededZero++;
                    }
                    else
                    {
                        neededOne++;
                    }
                }

                var newMax = new int[m + 1,n + 1];

                for (int zero = 0; zero <= m; zero++)
                {
                    for (int one = 0; one <= n; one++)
                    {
                        if (zero >= neededZero && one >= neededOne)
                        {
                            int zeroLeft = zero - neededZero;
                            int oneLeft = one - neededOne;
                            newMax[zero,one] = Math.Max(1 + max[zeroLeft,oneLeft], max[zero,one]);
                        }
                        else
                        {
                            newMax[zero,one] = max[zero,one];
                        }
                    }
                }

                max = newMax;
            }
            return max[m,n];
        }
    }
}
