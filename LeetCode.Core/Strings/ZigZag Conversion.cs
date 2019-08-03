using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class ZigZag_Conversion
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            var array = s.ToCharArray();
            var result = string.Empty;
            var deta = numRows * 2 - 2;
            for (int row = 0; row < numRows; row++)
            {
                var subDeta = (numRows - row - 1) * 2;
                var index = row;
                while (index < array.Length)
                {
                    result += array[index];
                    if (row == 0 || row == numRows - 1)
                    {
                        index += deta;
                    }
                    else
                    {
                        index += subDeta;
                        if (index < array.Length)
                        {
                            result += array[index];
                        }
                        index += deta - subDeta;
                    }
                }
            }
            return result;
        }
    }
}
