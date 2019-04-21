using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    class Integer_to_Roman
    {
        public string IntToRoman(int num)
        {
            int[] val = new int[13] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] dict = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            string ret = "";
            for (int i = 0; i < 13; i++)
            {
                if (num >= val[i])
                {
                    int count = num / val[i];
                    num %= val[i];
                    for (int j = 0; j < count; j++)
                    {
                        ret += dict[i];
                    }
                }
            }
            return ret;
        }
    }
}
