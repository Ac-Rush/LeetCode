using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Longest_Uncommon_Subsequence_II
    {
        public int FindLUSlength(string[] strs)
        {
            var subseqFreq = new Dictionary<string ,int >();
            foreach (var s in strs)
            {
                foreach (String subSeq in getSubseqs(s))
                {
                    if (!subseqFreq.ContainsKey(subSeq))
                    {
                        subseqFreq[subSeq] = 0;
                    }
                    subseqFreq[subSeq]++;
                }
                
                    
            }
                
            int longest = -1;
            foreach (var key in subseqFreq.Keys)
                if (subseqFreq[key] == 1) longest = Math.Max(longest, key.Length);
            return longest;
        }

        /// <summary>
        ///  sub set 问题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static HashSet<String> getSubseqs(String s)
        {
            var res = new HashSet<String>();
            if (s.Length == 0)
            {
                res.Add("");
                return res;
            }
            var subRes = getSubseqs(s.Substring(1));
            foreach (var str in subRes)
            {
                res.Add(str);
            }
            foreach (String seq in subRes) res.Add(s[0] + seq);
            return res;
        }
    }
}
