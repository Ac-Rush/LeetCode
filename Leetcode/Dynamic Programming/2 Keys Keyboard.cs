using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class _2_Keys_Keyboard
    {
        /// <summary>
        /// 素数分解问题
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinSteps(int n)
        {
            int ans = 0, d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    ans += d;
                    n /= d;
                }
                d++;
            }
            return ans;
        }
        private int FindGCD(int number1, int number2)
        {
            //base case
            if (number2 == 0)
            {
                return number1;
            }
            return FindGCD(number2, number1 % number2);
        }
    }

    
    }
