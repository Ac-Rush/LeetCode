using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Maths
{
    class Nim_Game
    {
        public bool CanWinNim(int n)
        {
            return (n % 4 != 0);
        }
    }
}
