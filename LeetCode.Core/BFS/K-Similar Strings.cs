using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    /// <summary>
    /// 简单粗暴的 BFS + 剪枝
    /// </summary>
    class K_Similar_Strings
    {
        public int KSimilarity(string A, string B)
        {
            if (A.Equals(B)) return 0;
            var vis = new HashSet<String>();
            Queue<String> q = new Queue<String>();
            q.Enqueue(A);
            vis.Add(A);
            int res = 0;
            //经典 BFS
            while (q.Any())
            {
                res++;
                var count = q.Count;
                while (count-- > 0)
                {
                    String s = q.Dequeue();
                    int i = 0;
                    while (s[i] == B[i]) i++;
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j] == B[j] || s[i] != B[j]) continue;  //剪枝
                        String temp = swap(s, i, j);
                        if (temp.Equals(B)) return res;
                        if (vis.Add(temp)) q.Enqueue(temp);
                    }
                }
            }
            return res;
        }

        public String swap(String s, int i, int j)
        {
            char[] ca = s.ToCharArray();
            char temp = ca[i];
            ca[i] = ca[j];
            ca[j] = temp;
            return new String(ca);
        }
    }
}
