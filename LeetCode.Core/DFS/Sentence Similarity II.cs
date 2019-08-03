using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Sentence_Similarity_II_DFS
    {
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs)
        {
            if (words1.Length != words2.Length)
            {
                return false;
            }

            var pairInfo = new Dictionary<string,HashSet<string>>();   //这个就是初始化图 
            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                if (!pairInfo.ContainsKey(pairs[i,0]))
                {
                    pairInfo[pairs[i,0]] =  new HashSet<string>();
                }
                if (!pairInfo.ContainsKey(pairs[i,1]))
                {
                    pairInfo[pairs[i, 1]] = new HashSet<string>();
                }
                pairInfo[pairs[i,0]].Add(pairs[i, 1]);   // pairs可以互查
                pairInfo[pairs[i, 1]].Add(pairs[i, 0]);

            }
            

            for (int i = 0; i < words1.Length; i++)
            {
                if (words1[i].Equals(words2[i])) continue;
                if (!pairInfo.ContainsKey(words1[i])) return false;
                if (!dfs(words1[i], words2[i], pairInfo, new HashSet<string>())) return false;    //Search the graph.
            }
            return true;
        }
        public bool dfs(String source, String target, Dictionary<string, HashSet<string>> pairInfo, HashSet<String> visited)
        {
            if (pairInfo[source].Contains(target)) return true;
            //visited去重

            visited.Add(source);
            foreach (String next in pairInfo[source]) //从邻居入手
            {
                if (!visited.Contains(next) && dfs(next, target, pairInfo, visited))
                {
                    return true;
                }
            }
          //  visited.Remove(source); //这个需要吗？ 这个不需要， 因为不是在找所有路径，如果是找所有路径 需要， 找一条就好
            return false;
        }
    }

    /// <summary>
    /// Disjoint Set Union (DSU) structure.
    /// 并查集
    /// </summary>
    class Sentence_Similarity_II_DSU
    {
        public class DSU
        {
            public  int[] parent;
            public DSU(int N)
            {
                parent = new int[N];
                for (int i = 0; i < N; ++i)
                    parent[i] = i;
            }
            public int find(int x)  //如果 x的 parent不是 x， 么就递归找
            {
                if (parent[x] != x) parent[x] = find(parent[x]);
                return parent[x];
            }
            public void union(int x, int y)
            {
                parent[find(x)] = find(y);
            }
        }
        public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs)
        {
            if (words1.Length != words2.Length) return false;
            Dictionary<string, int > index = new Dictionary<string, int>();
            int count = 0;
            DSU dsu = new DSU(2 * pairs.GetLength(0));
            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                if (!index.ContainsKey(pairs[i, 0]))
                {
                    index[pairs[i, 0]] = count++;
                }
                if (!index.ContainsKey(pairs[i, 1]))
                {
                    index[pairs[i, 1]] = count++;
                }
                dsu.union(index[pairs[i,0]], index[pairs[i, 1]]);

            }

            for (int i = 0; i < words1.Length; ++i)
            {
                String w1 = words1[i], w2 = words2[i];
                if (w1.Equals(w2)) continue;
                if (!index.ContainsKey(w1) || !index.ContainsKey(w2) ||
                        dsu.find(index[w1]) != dsu.find(index[w2]))
                    return false;
            }
            return true;
        }
        
    }
}
