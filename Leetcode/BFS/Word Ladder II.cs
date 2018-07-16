using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    /// <summary>
    /// 超时
    /// </summary>
    class Word_Ladder_II
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<String> reached = new HashSet<String>();
            reached.Add(beginWord);
            var wordDict = new HashSet<string>(wordList);
            //  wordDict.add(endWord);
            var ans = new List<IList<string>>();
            Dfs(ans, new List<string>() {beginWord}, beginWord, endWord, wordDict, new HashSet<string>() );
            ans.Sort( (a,b)=> a.Count.CompareTo(b.Count));
            if (ans.Count > 0)
            {
                ans = ans.Where(x => x.Count == ans[0].Count).ToList();
            }
            return ans;
        }

        private void Dfs(List<IList<string>> ans, List<string> curt, string beginWord, string endWord, HashSet<string> wordDict,
            HashSet<string> visited)
        {
            if (beginWord.Equals(endWord))
            {
                ans.Add(new List<string>(curt));
            }
            for (int i = 0; i < beginWord.Length; i++)
            {
                char[] chars = beginWord.ToCharArray();
                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    chars[i] = ch;
                    String word = new String(chars);
                    if (!visited.Contains(word) && wordDict.Contains(word))
                    {
                        visited.Add(word);
                        curt.Add(word);
                        Dfs(ans,curt, word,endWord,wordDict,visited);
                        curt.RemoveAt(curt.Count -1);
                        visited.Remove(word);
                    }
                   
                }
            }
        }
    }

    /*
     
        1). Use BFS to find the shortest distance between start and end, tracing the distance of crossing nodes from start node to end node, and store node's next level neighbors to HashMap;

2). Use DFS to output paths with the same distance as the shortest distance from distance HashMap: compare if the distance of the next level node equals the distance of the current node + 1.
    */

    class Word_Ladder_II_2
    {
        public IList<IList<string>> FindLadders(string start, string end, IList<string> wordList)
        {
            HashSet<String> dict = new HashSet<String>(wordList);
            List<IList<String>> res = new List<IList<String>>();
            Dictionary<String, List<String>> nodeNeighbors = new Dictionary<String, List<String>>();// Neighbors for every node
            Dictionary<String, int> distance = new Dictionary<String, int>();// Distance of every node from the start node
            List<String> solution = new List<String>();

            dict.Add(start);
            bfs(start, end, dict, nodeNeighbors, distance);
            dfs(start, end, dict, nodeNeighbors, distance, solution, res);
            return res;
        }
       // BFS: Trace every node's distance from the start node (level by level).
private void bfs(String start, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance)
        {
            foreach (String str in dict)
                nodeNeighbors[str] =  new List<String>();

            Queue<String> queue = new Queue<String>();
            queue.Enqueue(start);
            distance[start] =0 ;

            while (queue.Any())
            {
                int count = queue.Count;
                bool foundEnd = false;
                for (int i = 0; i < count; i++)
                {
                    String cur = queue.Dequeue();
                    int curDistance = distance[cur];
                   var neighbors = getNeighbors(cur, dict);

                    foreach (String neighbor in neighbors)
                    {
                        nodeNeighbors[cur].Add(neighbor);
                        if (!distance.ContainsKey(neighbor))
                        {// Check if visited
                            distance[neighbor] =  curDistance + 1;
                            if (end.Equals(neighbor))// Found the shortest path
                                foundEnd = true;
                            else
                                queue.Enqueue(neighbor);
                        }
                    }
                }

                if (foundEnd)
                    break;
            }
        }
        // Find all next level nodes.    
        private List<String> getNeighbors(String node, HashSet<String> dict)
        {
            var res = new List<String>();
            var chs = node.ToCharArray();

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                for (int i = 0; i < chs.Length; i++)
                {
                    if (chs[i] == ch) continue;
                    char old_ch = chs[i];
                    chs[i] = ch;
                    var word = new string(chs);
                    if (dict.Contains(word))
                    {
                        res.Add(word);
                    }
                    chs[i] = old_ch;
                }

            }
            return res;
        }

        // DFS: output all paths with the shortest distance.
        private void dfs(String cur, String end, HashSet<String> dict, Dictionary<String, List<String>> nodeNeighbors, Dictionary<String, int> distance, List<String> solution, List<IList<String>> res)
        {
            solution.Add(cur);
            if (end.Equals(cur))
            {
                res.Add(new List<String>(solution));
            }
            else
            {
                foreach (String next in nodeNeighbors[cur])
                {
                    if (distance[next] == distance[cur] + 1)
                    {
                        dfs(next, end, dict, nodeNeighbors, distance, solution, res);
                    }
                }
            }
            solution.RemoveAt(solution.Count - 1);
        }
    }
}
