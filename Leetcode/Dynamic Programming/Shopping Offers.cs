using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Shopping_Offers
    {
        /// <summary>
        /// Approach #2 Using Recursion with memoization [Accepted]
        /// </summary>
        /// <param name="price"></param>
        /// <param name="special"></param>
        /// <param name="needs"></param>
        /// <returns></returns>
        public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
        {
            var map = new Dictionary<IList<int>, int>();
            return shopping(price, special, needs, map);
        }

        public int shopping(IList<int> price, IList<IList<int>> special, IList<int> needs, Dictionary<IList<int>, int> map)
        {
            if (map.ContainsKey(needs))
                return map[needs];
            int j = 0, res = dot(needs, price);
            foreach (var s in special)
            {
                var clone = new List<int>(needs);
                for (j = 0; j < needs.Count; j++)
                {
                    int diff = clone[j] - s[j];
                    if (diff < 0)
                        break;
                    clone[j] = diff;
                }
                if (j == needs.Count)
                    res = Math.Min(res, s[j] + shopping(price, special, clone, map));
            }
            map[needs] = res;
            return res;
        }

        public int dot(IList<int> a, IList<int> b)
        {
            int sum = 0;
            for (int i = 0; i < a.Count; i++)
            {
                sum += a[i] * b[i];
            }
            return sum;
        }
    }
}
