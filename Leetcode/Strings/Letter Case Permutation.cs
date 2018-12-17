using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Letter_Case_Permutation
    {
        public IList<string> LetterCasePermutation(string S)
        {
            var result = new List<string>();
            DFS(result, string.Empty, S, 0);
            return result;

        }
        private void DFS(IList<string> result, string current, string S, int index)
        {
            if (index == S.Length)
            {
                result.Add(new String(current));
                return;
            }
            if (char.IsDigit(S[index]))
            {
                DFS(result, current + S[index], S, index + 1);
            }
            else
            {
                DFS(result, current + char.ToLower(S[index]), S, index + 1);
                DFS(result, current + char.ToUpper(S[index]), S, index + 1);
            }
        }
    }
}
