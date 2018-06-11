using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Keyboard_Row
    {
        public string[] FindWords(string[] words)
        {
            string[] strs = { "QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM" };
            var map = new Dictionary<char,int>();
            for (int i = 0; i < strs.Length; i++)
            {
                foreach (char c in strs[i])
                {
                    map[c] = i;//put <char, rowIndex> pair into the map
                }
            }
            List<string> res = new List<string>();
            foreach (string w in words)
            {
                if (w.Equals("")) continue;
                int index = map[w.ToUpper()[0]];
                foreach (char c in w.ToUpper())
                {
                    if (map[c] != index)
                    {
                        index = -1; //don't need a boolean flag. 
                        break;
                    }
                }
                if (index != -1) res.Add(w);//if index != -1, this is a valid string
            }
            return res.ToArray();
        }
    }
}
