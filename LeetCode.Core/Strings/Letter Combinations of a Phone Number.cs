using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    /// <summary>
    /// my solution
    /// </summary>
    class Letter_Combinations_of_a_Phone_Number
    {
        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (digits.Length == 0)
            {
                return result;
            }
            var dict = new Dictionary<int, string>
            {
                [2] = "abc", [3] = "def", [4]="ghi", [5] ="jkl",
                [6]="mno", [7]= "pqrs" , [8]="tuv" ,[9] ="wxyz"
            };
            Dfs(result, string.Empty, digits, 0, dict);
            return result;

        }

        private void Dfs(IList<string> result, string curt, string digits, int pos, Dictionary<int, string> dict)
        {
            if (pos == digits.Length)
            {
                result.Add(curt);
                return;
            }
            foreach (var c in dict[digits[pos] - '0'])
            {
                Dfs(result, curt + c, digits, pos +1, dict);
            }
        }
    }
}
