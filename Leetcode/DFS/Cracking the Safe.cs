using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    /// <summary>
    /// 这是我的答案， 前面答案的 n-1长度 加一位来凑 下个答案，要回溯，去重
    /// </summary>
    public class Cracking_the_Safe_my 
    {
        HashSet<String> seen;
        StringBuilder ans;
        public string CrackSafe(int n, int k)
        {
            if (n == 1 && k == 1) return "0";
            seen = new HashSet<String>();
            int M = (int)Math.Pow(k, n );
            ans = new StringBuilder();
            String start = new string('0', n-1);

            ans.Append(start);
            dfs(start, k, M);
            return ans.ToString();
        }

        public bool dfs(String node, int k, int total)
        {
            if (seen.Count == total) return true;
            for (int x = 0; x < k; ++x)
            {
                String nei = node + x;
                if (!seen.Contains(nei))
                {
                    seen.Add(nei);

                    ans.Append(x);
                    if (dfs(nei.Substring(1), k, total) == false)
                    {
                        seen.Remove(nei);
                        ans.Remove(ans.Length - 1, 1);
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }


    class Cracking_the_Safe_2
    {
        HashSet<String> seen;
        StringBuilder ans;
        public string CrackSafe(int n, int k)
        {
            int M = (int)Math.Pow(k, n - 1);
            int[] P = new int[M * k];
            for (int i = 0; i < k; ++i)
                for (int q = 0; q < M; ++q)
                    P[i * M + q] = q * k + i;

            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < M * k; ++i)
            {
                int j = i;
                while (P[j] >= 0)
                {
                    ans.Append((j / M));
                    int v = P[j];
                    P[j] = -1;
                    j = v;
                }
            }

            for (int i = 0; i < n - 1; ++i)
                ans.Append("0");
            return ans.ToString();
        }

        public void dfs(String node, int k)
        {
            for (int x = 0; x < k; ++x)
            {
                String nei = node + x;
                if (!seen.Contains(nei))
                {
                    seen.Add(nei);
                    dfs(nei.Substring(1), k);
                    ans.Append(x);
                }
            }
        }
    }
}
