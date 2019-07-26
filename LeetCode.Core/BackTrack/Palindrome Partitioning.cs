using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
    class Palindrome_Partitioning
    {
        List<IList<string>> resultLst ;
        List<string> currLst;
        public IList<IList<string>> Partition(string s)
        {
            resultLst = new List<IList<string>>();
            currLst = new List<string>();
            backTrack(s, 0);
            return resultLst;
        }
        //back tracking DFS
        private void backTrack(string s, int l)
        {
            if (currLst.Count > 0 //the initial str could be palindrome
                && l >= s.Length)
            {
                resultLst.Add(new List<string>(currLst));
            }
            for (int i = l; i < s.Length; i++)
            {
                if (isPalindrome(s, l, i))
                {
                    /*if (l == i)
                        currLst.Add(Char.ToString(s[i]));
                    else*/
                        currLst.Add(s.Substring(l, i + 1 -l));
                    backTrack(s, i + 1);
                    currLst.RemoveAt(currLst.Count -1);
                }
            }
        }
        private bool isPalindrome(string str, int l, int r)
        {
          //  if (l == r) return true;
            while (l < r)
            {
                if (str[l++] != str[r--]) return false;
                //l++; r--;
            }
            return true;
        }
    }
}
