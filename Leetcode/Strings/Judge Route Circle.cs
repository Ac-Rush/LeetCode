using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Judge_Route_Circle
    {
        public bool JudgeCircle(string moves)
        {
            var h = 0;
            var v = 0;
            foreach (var move in moves)
            {
                switch (move)
                {
                    case 'L':
                        h--;
                        break;
                    case 'R':
                        h++;
                        break;
                    case 'U':
                        v++;
                        break;
                    case 'D':
                        v--;
                        break;
                }
            }
            return h == 0 && v == 0;

        }
    }
}
