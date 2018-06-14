using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Top_K_Frequent_Words
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
             var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
                dict[word]++;
            }

            var bucket = new List<string>[words.Length +1];
            foreach (var word in dict.Keys)
            {
                var frquence = dict[word];
                if (bucket[frquence] == null)
                {
                    bucket[frquence] = new List<string>();
                }
                bucket[frquence].Add(word);
            }
            var result = new List<string>();
            for (int i = bucket.Length -1; i>=0 && k>0 ; i--)
            {
                if (bucket[i] != null)
                {
                    var temp = bucket[i].ToArray();
                    System.Array.Sort(temp, (x, y) => String.Compare(x, y));
                    if (k < temp.Length)
                    {
                        result.AddRange(temp.Take(k));
                        break;
                    }
                    result.AddRange(temp);
                    k -= temp.Length;
                }
            }
            return result;
        }



        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent2(string[] words, int k)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 0;
                }
                dict[word]++;
            }

            var bucket = new List<string>[words.Length + 1];
            List<String> candidates = new List<string>(dict.Keys);
            var result =candidates.OrderByDescending(x => dict[x]).ThenBy(x=>x);
            
            return result.Take(k).ToList();
        }

    }
}
