using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Rotated_Digits
    {
        public int RotatedDigits(int N)
        {
            int count = 0;
            for (int i = 1; i <= N; i++)
            {
                if (isValid(i)) count++;
            }
            return count;
        }
        public bool isValid(int N)
        {
            /*
             Valid if N contains ATLEAST ONE 2, 5, 6, 9
             AND NO 3, 4 or 7s
             */
            bool validFound = false;
            while (N > 0)
            {
                if (N % 10 == 2) validFound = true;
                if (N % 10 == 5) validFound = true;
                if (N % 10 == 6) validFound = true;
                if (N % 10 == 9) validFound = true;
                if (N % 10 == 3) return false;
                if (N % 10 == 4) return false;
                if (N % 10 == 7) return false;
                N = N / 10;
            }
            return validFound;
        }


        /// <summary>
        /// dp solution 
        /// Using a int[] for dp.
       /// dp[i] = 0, invalid number
///dp[i] = 1, valid and same number
///dp[i] = 2, valid and different number
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int rotatedDigits(int N)
        {
            int[] dp = new int[N + 1];
            int count = 0;
            for (int i = 0; i <= N; i++)
            {
                if (i < 10)
                {
                    if (i == 0 || i == 1 || i == 8) dp[i] = 1;
                    else if (i == 2 || i == 5 || i == 6 || i == 9)
                    {
                        dp[i] = 2;
                        count++;
                    }
                }
                else
                {
                    int a = dp[i / 10], b = dp[i % 10];
                    if (a == 1 && b == 1) dp[i] = 1;
                    else if (a >= 1 && b >= 1)
                    {
                        dp[i] = 2;
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
