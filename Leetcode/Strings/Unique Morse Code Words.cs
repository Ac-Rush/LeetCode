using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Unique_Morse_Code_Words
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            var morse = new string[] {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};

            var set = new HashSet<string>();
            foreach (var word in words)
            {
                var sb = new StringBuilder();
                foreach (var c in word)
                {
                    sb.Append(morse[c - 'a']);
                }
                set.Add(sb.ToString());
            }
            return set.Count;
        }
    }
}
