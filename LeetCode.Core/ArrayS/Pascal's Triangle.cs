using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Pascal_s_Triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var ans = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                if (i == 0)
                {
                    ans.Add(new List<int> { 1 });
                }
                else
                {
                    var list = new List<int> { 1 };
                    var bottom = ans.Last();
                    for (int j = 0; j < bottom.Count - 1; j++)
                    {
                        list.Add(bottom[j] + bottom[j + 1]);
                    }
                    list.Add(1);
                    ans.Add(list);
                }
            }
            return ans;
        }
    }
}
