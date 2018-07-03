using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Pascal_s_Triangle_II
    {
        public IList<int> GetRow(int rowIndex)
        {
            var ans = new int[rowIndex + 1];
            ans[0] = 1;
            for (int i = 1; i < rowIndex + 1; i++)
                for (int j = i; j >= 1; j--)
                    ans[j] += ans[j - 1];
            return ans;
        }
    }
}
