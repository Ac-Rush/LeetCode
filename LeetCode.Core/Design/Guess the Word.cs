using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    class Guess_the_Word
    {
        internal class Master
        {
            public int Guess(string word)
            {
                return 1;
            }
        }
        public void FindSecretWord(string[] wordlist, Master master)
        {
            for (int i = 0, x = 0; i < 10 && x < 6; ++i)
            {
                String guess = wordlist[new Random().Next(wordlist.Length)];
                x = master.Guess(guess);
                List<String> wordlist2 = new List<String>();
                foreach (String w in wordlist) if (match(guess, w) == x) wordlist2.Add(w);
                wordlist = wordlist2.ToArray();
            }
        }
        public int match(String a, String b)
        {
            int matches = 0;
            for (int i = 0; i < a.Length; ++i) if (a[i] == b[i]) matches++;
            return matches;
        }
    }
}
