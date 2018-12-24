using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    class Ugly_Number
    {
        public bool IsUgly(int num)
        {
            while (num > 1 && num % 5 == 0) num /= 5;
            while (num > 1 && num % 3 == 0) num /= 3;
            while (num > 1 && num % 2 == 0) num /= 2;
            return num == 1;
        }

        public bool IsUgly2(int num)
        {
            for (int i = 2; i < 6 && num > 0; i++)
                while (num % i == 0)
                    num /= i;
            return num == 1;
        }
    }
}
