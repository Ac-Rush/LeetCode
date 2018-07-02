using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Longest_Common_Prefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string comPrefix = string.Empty;
            if (!strs.Any()) return comPrefix;
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                        return comPrefix;
                }
                comPrefix = comPrefix + strs[0][i];
            }
            return comPrefix;
        }
    }
}
