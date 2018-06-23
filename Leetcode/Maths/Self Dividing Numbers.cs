using System.Collections.Generic;

namespace Leetcode.Maths
{
    class Self_Dividing_Numbers
    {
        public IList<int> SelfDividingNumbers(int left, int right)
        {
            var result = new List<int>();
            for (int i = left; i <= right; i++)
            {
                if (IsSelfDividingNumber(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        private bool IsSelfDividingNumber(int m)
        {
            var n = m;
            while (n > 1)
            {
                var div = n % 10;
                if (div == 0)
                {
                    return false;
                }
                if (m % div != 0)
                {
                    return false;
                }
                n = n / 10;
            }
            return true;
        }
    }
}
