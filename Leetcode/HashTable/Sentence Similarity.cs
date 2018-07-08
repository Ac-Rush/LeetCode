using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Sentence_Similarity
    {
        /// <summary>
        /// 这个比较容易，  follow up 是Sentence Similarity II 需要用  并查集
        /// Sentence_Similarity_II_DSU
        /// https://leetcode.com/problems/sentence-similarity-ii/description/
        /// </summary>
        /// <param name="words1" ref="Sentence_Similarity_II_DSU.cs"></param>
        /// <param name="words2"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs)
        {
            if (words1.Length != words2.Length) return false;
            var dict = new Dictionary<string, HashSet<string>>();  //bug ，之前是 dictionary<string, string> 可能有1对多
            for (int i = 0; i < pairs.GetLength(0); i++) //init
            {
                if (!dict.ContainsKey(pairs[i, 0]))
                {
                    dict[pairs[i, 0]] = new HashSet<string>();
                }
                dict[pairs[i, 0]].Add(pairs[i, 1]);
                if (!dict.ContainsKey(pairs[i, 1]))
                {
                    dict[pairs[i, 1]] = new HashSet<string>();
                }
                dict[pairs[i, 1]].Add(pairs[i, 0]);
            }
            for (int i = 0; i < words1.Length; i++)
            {
                if(words1[i].Equals(words2[i])) continue; //my bug 少了这个判断
                if (!dict.ContainsKey(words1[i]) || !dict[words1[i]].Contains(words2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
