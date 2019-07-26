using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Word_Ladder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        { // Use queue to help BFS
            HashSet<String> reached = new HashSet<String>();
            reached.Add(beginWord);
            var wordDict = new HashSet<string>(wordList);
          //  wordDict.add(endWord);
            int distance = 1;
            while (!reached.Contains(endWord))
            {
                var toAdd = new HashSet<String>();
                foreach (String each in reached)
                {
                    for (int i = 0; i < each.Length; i++)
                    {
                        char[] chars = each.ToCharArray();
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            chars[i] = ch;
                            String word = new String(chars);
                            if (wordDict.Contains(word))
                            {
                                toAdd.Add(word);
                                wordDict.Remove(word);
                            }
                        }
                    }
                }
                distance++;
                if (toAdd.Count == 0) return 0;
                reached = toAdd;
            }
            return distance;
        }
    }

    class Word_Ladder_My
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        { // Use queue to help BFS
            HashSet<String> reached = new HashSet<String>();
            reached.Add(beginWord);
            var wordDict = new HashSet<string>(wordList);
            //  wordDict.add(endWord);
            int distance = 1;
            while (!reached.Contains(endWord))
            {
                var toAdd = new HashSet<String>();
                foreach (String each in reached)
                {
                    for (int i = 0; i < each.Length; i++)
                    {
                        char[] chars = each.ToCharArray();
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            chars[i] = ch;
                            String word = new String(chars);
                            if (wordDict.Contains(word))
                            {
                                toAdd.Add(word);
                                wordDict.Remove(word);
                            }
                        }
                    }
                }
                distance++;
                if (toAdd.Count == 0) return 0;
                reached = toAdd;
            }
            return distance;
        }
    }
}
