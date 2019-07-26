using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Goat_Latin
    {
        public string ToGoatLatin(string S)
        {
            var vowel = new HashSet<char>();
            foreach (char c in new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' })
                vowel.Add(c);

            int t = 1;
            StringBuilder ans = new StringBuilder();
            foreach (String word in S.Split(' '))
            {
                char first = word[0];
                if (vowel.Contains(first))
                {
                    ans.Append(word);
                }
                else
                {
                    ans.Append(word.Substring(1));
                    ans.Append(word.Substring(0, 1));
                }
                ans.Append("ma");
                for (int i = 0; i < t; i++)
                    ans.Append("a");
                t++;
                ans.Append(" ");
            }
            ans.Length--;
          
            return ans.ToString();
        }
    }
}
