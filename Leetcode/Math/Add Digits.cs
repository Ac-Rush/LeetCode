using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Math
{
    class Add_Digits
    {
        public static int AddDigits(int num)
        {
            while (num < 10)
            {
                var temp = 0;
                while (num > 0)
                {
                    temp += num % 10;
                    num /= 10;
                }
                num = temp;
            }
            return num;
        }
    }
}
