using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    class Valid_Word_Square_my
    {
        public bool ValidWordSquare(IList<string> words)
        {
            if (words == null || words.Count == 0) return false;
            var r = words.Count;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j >= r || words[j].Length <= i) return false; //my bug 需要越界check
                    if (words[i][j] != words[j][i]) return false;
                }
            }
            return true;
        }
    }

    class Valid_Word_Square_2
    {
        public bool ValidWordSquare(IList<string> words)
        {
            if (words == null || words.Count == 0) return false;
            var r = words.Count;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j >= r || words[j].Length <= i) return false; //my bug 需要越界check
                    if (words[i][j] != words[j][i]) return false;
                }
            }
            return true;
        }
    }
}
