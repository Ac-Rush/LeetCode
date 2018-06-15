using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class Brick_Wall
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="wall"></param>
        /// <returns></returns>
        public  int LeastBricks(IList<IList<int>> wall)
        {
            var dict = new Dictionary<int, int>(); // <index, count>
            foreach (var level in wall)
            {
                var index = 0;
                for (int i = 0; i < level.Count; i++)
                {
                    if (i != level.Count - 1)
                    {
                        var n = level[i];
                        index += n;
                        if (!dict.ContainsKey(index))
                        {
                            dict[index] = 0;
                        }
                        dict[index]++;
                    }
                }
            }
            var max = dict.Count == 0 ? 0 : dict.Values.Max();
            return wall.Count - max;
        }
    }
}
