using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Multiply_Strings
    {
        public string Multiply(string num1, string num2)
        {
            int m = num1.Length, n = num2.Length;
            int[] pos = new int[m + n];//一共有这么多位

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    // `num1[i] * num2[j]` will be placed at indices `[i + j`, `i + j + 1]` 
                    int mul = (num1[i] - '0') * (num2[j] - '0');
                    int p1 = i + j, p2 = i + j + 1;
                    int sum = mul + pos[p2];

                    pos[p1] += sum / 10;
                    pos[p2] = (sum) % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int p in pos) if (!(sb.Length == 0 && p == 0)) sb.Append(p);
            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}
