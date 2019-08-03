using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Top_K_Frequent_Elements
    {
        /// <summary>
        /// bucket sort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<int> TopKFrequent(int[] nums, int k)
        {

            List<int>[] bucket = new List<int>[nums.Length + 1];
            var frequencyMap = new Dictionary<int, int>();

            foreach (int n in nums)
            {
                if (!frequencyMap.ContainsKey(n))
                {
                    frequencyMap[n] = 0;
                }
                frequencyMap[n]++;
            }

            foreach (int key in frequencyMap.Keys)
            {
                int frequency = frequencyMap[key];
                if (bucket[frequency] == null)
                {
                    bucket[frequency] = new List<int>();
                }
                bucket[frequency].Add(key); //存进来就排序了
            }

            List<int> res = new List<int>();

            for (int pos = bucket.Length - 1; pos >= 0 && res.Count < k; pos--)
            {
                if (bucket[pos] != null)
                {
                    res.AddRange(bucket[pos]);
                }
            }
            return res;
        }
    }


    class Top_K_Frequent_Elements2
    {
        /// <summary>
        /// bucket sort
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<int> TopKFrequent(int[] nums, int k)
        {

            var dict = new Dictionary<int, int>();
            foreach (var n in nums)
            {
                if (!dict.ContainsKey(n))
                {
                    dict[n] = 0;
                }
                dict[n]++;
            }
            return dict.Keys.OrderByDescending(i => dict[i]).Take(k).ToList();
          
        }
    }
}
