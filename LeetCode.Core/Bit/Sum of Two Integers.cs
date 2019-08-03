using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Sum_of_Two_Integers
    {

        /*
         
            ^ tricks
Use ^ to remove even exactly same numbers and save the odd, or save the distinct bits and remove the same.

Sum of Two Integers
Use ^ and & to add two integers
    */
        public int GetSum(int a, int b)
        {
            return b == 0 ? a : GetSum(a ^ b, (a & b) << 1); //be careful about the terminating condition;
        }
    }
}
