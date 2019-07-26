using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Flip_Game
    {
        public IList<string> GeneratePossibleNextMoves(string s)
        {
            var ans = new List<string>();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '+' && s[i + 1] == '+')  // back tracking 每一组可能的都去试试，
                {
                    String t = s.Substring(0, i) + "--" + s.Substring(i + 2);

                    ans.Add(t);
                }
            }
            return ans;
        }
    }
}
