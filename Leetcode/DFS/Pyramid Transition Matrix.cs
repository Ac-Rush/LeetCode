using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Pyramid_Transition_Matrix
    {
        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            var dict = new Dictionary<string , List<String>>();
            foreach (var allow in allowed)
            {
                if (!dict.ContainsKey(allow.Substring(0, 2)))
                {
                    dict[allow.Substring(0, 2)]= new List<string>();
                }
                dict[allow.Substring(0, 2)].Add( allow.Substring(2, 1));
            }
            return helper(bottom, dict);
        }


        private bool helper(String bottom,  Dictionary<string, List<String>> map)
        {
            if (bottom.Length == 1) return true;
            for (int i = 0; i < bottom.Length - 1; i++)
            {
                if (!map.ContainsKey(bottom.Substring(i,  2))) return false;
            }
            List<String> ls = new List<string>();
            getList(bottom, 0, new StringBuilder(), ls, map);
            foreach (String s in ls)
            {
                if (helper(s, map)) return true;
            }
            return false;
        }

        private void getList(String bottom, int idx, StringBuilder sb, List<String> ls, Dictionary<string, List<String>> map)
        {
            if (idx == bottom.Length - 1)
            {
                ls.Add(sb.ToString());
                return;
            }
            foreach (String s in map[bottom.Substring(idx,  2)])
            {
                sb.Append(s);
                getList(bottom, idx + 1, sb, ls, map);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
