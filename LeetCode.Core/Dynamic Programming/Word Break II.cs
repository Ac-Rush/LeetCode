using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// 我的解法， 超时了
    /// </summary>
    class Word_Break_II
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var ans = new List<List<string>>();
             word_Break(s, new HashSet<string>(wordDict), 0, ans, new List<string>());
            return ans.Select(list => String.Join(" ", list)).ToList();
        }

        public void word_Break(String s, HashSet<string> wordDict, int start, List<List<string>> ans, List<string> curt)
        {
            if (start == s.Length)
            {
                ans.Add(new List<string>(curt));
                return ;
            }
            for (int end = start + 1; end <= s.Length; end++)
            {
                var sub = s.Substring(start, end - start);
                if (wordDict.Contains(sub))
                {
                    curt.Add(sub);
                    word_Break(s, wordDict, end, ans, curt);
                    curt.RemoveAt(curt.Count - 1);
                }
            }
        }
    }

    class Word_Break_II_memo
    {
        Dictionary<int, List<string>> map = new Dictionary<int, List<string>> ();
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
           return  word_Break(s, new HashSet<string>(wordDict), 0);
        }

        public List<String> word_Break(String s, HashSet<String> wordDict, int start)
        {
            if (map.ContainsKey(start))
            {
                return map[start];
            }
            List<String> res = new  List<string> ();
            if (start == s.Length)
            {
                res.Add("");  //这里要注意，一个初始值，要不不好处理
            }
            for (int end = start + 1; end <= s.Length; end++) //这里也要注意 ， end的取值 是 《=length ，如果需要用 s.SubString
            {
                var sub = s.Substring(start, end - start);
                if (wordDict.Contains(sub))
                {
                    List<String> list = word_Break(s, wordDict, end);
                    foreach (String l in list)
                    {
                        res.Add(sub + (l.Equals("") ? "" : " ") + l);
                    }
                }
            }
            /* 或者如下写也对
       for (int end = start; end < s.Length; end++)
            {
                var sub = s.Substring(start, end - start + 1);
                if (wordDict.Contains(sub))
                {
                    List<String> list = word_Break(s, wordDict, end + 1);
                    foreach (String l in list)
                    {
                        res.Add(sub + (l.Equals("") ? "" : " ") + l);
                    }
                }
            } 
             

    */
            map[start] = res;
            return res;
        }
    }
}
