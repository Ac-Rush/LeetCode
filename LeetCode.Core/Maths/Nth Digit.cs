using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Nth_Digit
    {
        //1. find the number where the digit will be in
        //2. find the index within the number where the digit will be
        //3. return the digit
        public int FindNthDigit(int n)
        {
            int i = 1, curWid = 1;
            long cur = 1;
            while (i <= n)
            {
                if (i + cur * 9 * curWid >= n)
                {
                    long numb = cur + (long)((n - i) / curWid);
                    int ind = (n - i) % curWid;
                    return int.Parse(numb.ToString()[ind].ToString());
                }
                else
                {
                    i += (int)cur * 9 * curWid;
                    cur *= 10;
                    curWid += 1;
                }
            }
            return 0;
        }
    }
}
