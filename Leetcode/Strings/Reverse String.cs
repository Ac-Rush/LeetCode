using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_String
    {

        public string ReverseString(string s)
        {
            char[] word = s.ToCharArray();
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char temp = word[i];
                word[i] = word[j];
                word[j] = temp;
                i++;
                j--;
            }
            return new String(word);
        }
        public string ReverseString2(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
