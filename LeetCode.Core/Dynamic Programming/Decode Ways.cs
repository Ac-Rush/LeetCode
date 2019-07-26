using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Decode_Ways
    {
        public int NumDecodings(string s)
        {
            if (s.Length ==0 || s[0] == '0') return 0;
            // r2: decode ways of s[i-2] , r1: decode ways of s[i-1] 
            int r1 = 1, r2 = 1;

            for (int i = 1; i < s.Length; i++)
            {
                // zero voids ways of the last because zero cannot be used separately
                if (s[i] == '0') r1 = 0;

                // possible two-digit letter, so new r1 is sum of both while new r2 is the old r1
                if (s[i - 1] == '1' || s[i - 1] == '2' && s[i] <= '6')
                {
                    r1 = r2 + r1; //r1 表示当前，r1 就等于之前的 r1 和 r2的和
                    r2 = r1 - r2; // r2就等于 之前的r1
                }

                // one-digit letter, no new way added
                else
                {
                    r2 = r1;  //否则更新 r2
                }
            }

            return r1;
        }


        public int NumDecodings2(string s)
        {
            int n = s.Length, first = 1, second = 1;
            if (n == 0 || s[0] == '0') return 0;
            for (int i = 1; i < n; i++)
            {

                if (s[i] == '0') second = 0;
                if (s[i] <= '6' && s[i - 1] == '2' || s[i - 1] == '1') // my bug 
                {
                    second = first + second;  //这样替换 不需要中间变量
                    first = second - first;
                }
                else
                {
                    first = second;  //my bug
                }
            }
            return second;
        }
    }
}
