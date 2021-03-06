﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    public  class Most_Common_Word
    {
        public  static string MostCommonWord(string paragraph, string[] banned)
        {
            paragraph = paragraph + '.';  //my bug
            var dict = new Dictionary<string, int>();
            var bannedSet = new HashSet<string>();
            foreach (var b in banned)
            {
                bannedSet.Add(b.ToLower());
            }
            String ans = "";
            int ansfreq = 0;
            StringBuilder word = new StringBuilder();
            foreach (char c in paragraph)
            {
                if (char.IsLetter(c))
                {
                    word.Append(char.ToLower(c));
                }
                else if (word.Length > 0)
                {
                    var finalword = word.ToString();
                    if (!bannedSet.Contains(finalword))
                    {
                        if (!dict.ContainsKey(finalword))
                        {
                            dict[finalword] = 0;
                        }
                        dict[finalword]++;
                        if (dict[finalword] > ansfreq)
                        {
                            ans = finalword;
                            ansfreq = dict[finalword];
                        }
                    }
                    word = new StringBuilder();
                }
            }

            return ans;
        }


        public static string MostCommonWord2(string paragraph, string[] banned)
        {
            var p = Regex.Replace(paragraph, "[^a-zA-Z0-9 ]+", " ", RegexOptions.Compiled).ToLower().Split(' ')
                .Where(c => !string.IsNullOrEmpty(c));
            return p.Where(x => !banned.ToList().Contains(x)).GroupBy(y => y).OrderByDescending(z => z.Count())
                .Select(g => new {Id = g.Key}).First().Id;
        }
    }
}
