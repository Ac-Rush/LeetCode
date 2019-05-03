using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    public class Substring_with_Concatenation_of_All_Words_Sliding_Window
    {
        /// <summary>
        /// 错误答案， 这个不是按单词为粒度的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var map = new int[256];
            int count = 0;
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    map[c]++;
                    count++;
                }
            }
            int start = 0, end = 0, length = count;

            while (end < s.Length)
            {
                if (map[s[end++]]-- > 0)
                    count--;
                if (count == 0 && end - start == length)
                {
                    result.Add(start);
                }
                if (end - start >= length && map[s[start++]]++ >= 0)
                {
                    count++;
                }
            }

            return result;
        }

        public static IList<int> FindSubstring2(string s, string[] words)
        {
            var counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                counts[word] = counts.ContainsKey(word) ? counts[word] + 1 : 1;
            }
            var indexes = new List<int>();
            if (words.Length == 0) return indexes;
            int n = s.Length, num = words.Length, len = words[0].Length;
            for (int i = 0; i < n - num * len + 1; i++)
            {
                var seen = new Dictionary<string, int>();
                int j = 0;
                while (j < num)
                {
                    var word = s.Substring(i + j * len, len);
                    if (counts.ContainsKey(word))
                    {
                        /*if (!seen.ContainsKey(word))
                        {
                            seen[word] = 0;
                        }
                        seen[word]++;
                        */
                        seen[word] = seen.ContainsKey(word) ? seen[word] + 1 : 1;
                        if (seen[word] > counts[word])
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
                if (j == num)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }
    }
}
