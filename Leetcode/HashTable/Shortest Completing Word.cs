using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Shortest_Completing_Word
    {
        public String shortestCompletingWord(String licensePlate, String[] words)
        {
            int[] target = count(licensePlate);
            String ans = "";
            foreach (String word in words)
                if ((word.Length < ans.Length || ans.Length == 0) && dominates(count(word), target))
                    ans = word;
            return ans;
        }

        public bool dominates(int[] count1, int[] count2)
        {
            for (int i = 0; i < 26; ++i)
                if (count1[i] < count2[i])
                    return false;
            return true;
        }

        public int[] count(string word)
        {
            int[] ans = new int[26];
            foreach (char letter in word)
            {
                int index = char.ToLower(letter) - 'a';
                if (0 <= index && index < 26)
                    ans[index]++;
            }
            return ans;
        }

        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            String target = licensePlate.ToLower();
            int[] charMap = new int[26];
            // Construct the character map
            for (int i = 0; i < target.Length; i++)
            {
                if (char.IsLetter(target[i])) charMap[target[i] - 'a']++;
            }
            int minLength = int.MaxValue;
            String result = null;
            for (int i = 0; i < words.Length; i++)
            {
                String word = words[i].ToLower();
                if (Matches(word, charMap) && word.Length < minLength)
                {
                    minLength = word.Length;
                    result = words[i];
                }
            }
            return result;
        }

        private bool Matches(String word, int[] charMap)
        {
            int[] targetMap = new int[26];
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsLetter(word[i])) targetMap[word[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (charMap[i] != 0 && targetMap[i] < charMap[i]) return false;
            }
            return true;
        }
    }
}
