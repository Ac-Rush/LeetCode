using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    public class Restore_IP_Addresses
    {
        IList<string> ans = new List<string>();
        public IList<string> RestoreIpAddresses(string s)
        {
            Dfs(s, new List<string>(), 0);
            return ans;
        }

        private void Dfs(string s, List<string> cur, int index)
        {
            if (index == s.Length && cur.Count == 4)
            {
                ans.Add(string.Join(".", cur));
                return;
            }
            if (index == s.Length || cur.Count == 4) return;
           // var seg = 0;
         //   for (int i = index; i < s.Length; i++)  my bug 不需要外面的 循环, 确实不需要 不然不对，因为如果又就可以不选
           
                for (int j = 1; j <= 3 && index+j<= s.Length; j++)
                {
                    var seg = s.Substring(index, j);
                    if (isValid(seg))
                    {
                        cur.Add(seg);
                        Dfs(s, cur, index + j);
                        cur.RemoveAt(cur.Count - 1);
                    }
                    else
                    {
                        return;
                    }
                }
            
        }
        public bool isValid(string s)
        {
            if (s.Length > 3 || s.Length == 0 || (s[0] == '0' && s.Length > 1) || int.Parse(s) > 255)
                return false;
            return true;
        }
    }
}
