using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_Words_in_a_String
    {
        public string ReverseWords(string s)
        {
            var sb = new StringBuilder();
            var wordArr = s.Split(' ');

            for (int i = wordArr.Length - 1; i >= 0; i--)
            {
                var word = wordArr[i].Trim();
                sb.Append(word);
                if (word.Length != 0)
                    sb.Append(" ");

            }

            return sb.ToString().Trim();
        }

        
    }
}
