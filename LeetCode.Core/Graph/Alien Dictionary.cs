using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Graph
{
    public class Alien_Dictionary
    {
        /// <summary>
        /// Topology Traversal.
        /// 拓扑排序， 统计入度 有向图
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string AlienOrder(string[] words)
        {
            String result = "";
            if (words == null || words.Length == 0) return result;
            var graph = new Dictionary<char, HashSet<char>>();
            var degree = new Dictionary<char, int>();
            foreach (var word in words)
            {
                foreach(var c in word)
                {
                    degree[c] = 0;
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                String cur = words[i];
                String next = words[i + 1];
                int length = Math.Min(cur.Length, next.Length);
                for (int j = 0; j < length; j++)
                {
                    char c1 = cur[j];
                    char c2 = next[j];
                    if (c1 != c2)
                    {
                        var set = new HashSet<char>();
                        if (graph.ContainsKey(c1)) set = graph[c1];
                        if (!set.Contains(c2))  //只有这样的情况才能知道顺序， "wrt"  "wrf"  只能知道 t 在 f 前面
                        {
                            set.Add(c2);
                            graph[c1]= set;
                            degree[c2]++;
                        }
                        break; //只有第一个有效， 要 break
                    }
                }
            }

            Queue<char> q = new Queue<char>();
            foreach (char c in degree.Keys)
            {
                if (degree[c] == 0) q.Enqueue(c);
            }
            while (q.Any())
            {
                char c = q.Dequeue();
                result += c;
                if (graph.ContainsKey(c))
                {
                    foreach (char c2 in graph[c])
                    {
                        if (--degree[c2] == 0) q.Enqueue(c2);
                    }
                }
            }
            if (result.Length != degree.Count) return "";
            return result;
        }
    }
}
