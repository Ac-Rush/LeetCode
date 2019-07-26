using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
    class Generalized_Abbreviation
    {
        /*
         * 
         * 
        
            The idea is: for every character, we can keep it or abbreviate it. 
            To keep it, we add it to the current solution and carry on backtracking. To abbreviate it, we omit it in the current solution, but increment the count, which indicates how many characters have we abbreviated. When we reach the end or need to put a character in the current solution, and count is bigger than zero, we add the number into the solution.
    */
        public IList<string> GenerateAbbreviations(string word)
        {
            List<String> ret = new List<String>();
            backtrack(ret, word, 0, "", 0);

            return ret;
        }
        private void backtrack(List<String> ret, String word, int pos, String cur, int count)
        {
            if (pos == word.Length)  //如果 pos 到达了 结尾 那么 加入结果
            {
                if (count > 0) cur += count; //还要特殊处理下 结尾的 count
                ret.Add(cur);
            }
            else
            {
                backtrack(ret, word, pos + 1, cur, count + 1);  //处理这个字符
                backtrack(ret, word, pos + 1, cur + (count > 0 ? count.ToString() : "") + word[pos], 0); //不处理这个字符
            }
        }
    }
}
