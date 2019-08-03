using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Unique_Morse_Code_Words
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            var codes = new string[]
            {
                ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
                ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
            };
            var set = new HashSet<string>();
            foreach (var w in words)
            {
                var sb = new StringBuilder();
                foreach (var c in w)
                {
                    sb.Append(codes[c - 'a']);
                }

                set.Add(sb.ToString());
            }

            return set.Count;
        }
    }
}
