using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    /// <summary>
    /// my solution
    /// </summary>
    class MagicDictionary
    {
        private Dictionary<int, List<string>> map = new Dictionary<int, List<string>>();
        public MagicDictionary()
        {

        }

        /** Build a dictionary through a list of words */
        public void BuildDict(string[] dict)
        {
            foreach (var word in dict)
            {
                var len = word.Length;
                if (!map.ContainsKey(len))
                {
                    map[len] = new List<string>();
                }
                map[len].Add(word);
            }
        }

        /** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
        public bool Search(string word)
        {
            var len = word.Length;
            if (map.ContainsKey(len))
            {
                foreach (var dic in map[len])
                {
                    int changes = 0;
                    for (int i= 0; i < dic.Length; i++)
                    {
                        if (dic[i] != word[i])
                        {
                            if (changes++ >= 1)
                            {
                                break;
                            }
                        }
                    }
                    if (changes == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
