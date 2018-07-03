using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{
    class Positions_of_Large_Groups
    {
        public IList<IList<int>> LargeGroupPositions(string S)
        {
            var result = new List<IList<int>>();
            var count = 1;
            for(int i = 1; i < S.Length; i++)
            {
                if(S[i] == S[i - 1])
                {
                    count++;
                }else
                {
                    if(count >= 3)
                    {
                        result.Add(new List<int> { i - 1 - count, i - 1 });
                    }
                    count = 1;
                }
            }
            if (count >= 3)
            {
                result.Add(new List<int> { S.Length - 1 - count, S.Length - 1 });
            }
            return result;
        }
    }
}
