using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Word_Break
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            bool[] f = new bool[s.Length + 1];
            var set = new HashSet<string>();
            foreach (var word in wordDict)
            {
                set.Add(word);
            }
            f[0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (f[j] && set.Contains(s.Substring(j, i-j)))
                    {
                        f[i] = true;
                        break;
                    }
                }
            }

            return f[s.Length];
        }
    }
}
