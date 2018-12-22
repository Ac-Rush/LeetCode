using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Robot_Return_to_Origin
    {
        public bool JudgeCircle(string moves)
        {
            var l = 0;
            var u = 0;
            foreach (var m in moves)
            {
                switch (m)
                {
                    case 'U': u++; break;
                    case 'D': u--; break;
                    case 'L': l--; break;
                    case 'R': l++; break;
                }
            }
            return l == 0 && u == 0;
        }
    }
}
