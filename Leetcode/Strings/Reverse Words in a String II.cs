using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_Words_in_a_String_II
    {
        public void ReverseWords(char[] str)
        {
            int start = 0, end = str.Length - 1;
            //Reverse the entire string.
            Reverse(str, start, end);

            start = 0;
            for (int i = 0; i < str.Length; i++) //Now just catch every word and reverse it
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    if (i == str.Length - 1)
                        end = i;
                    else end = i - 1;
                    //Now reverse the individual word
                    Reverse(str, start, end);
                    start = i + 1;
                }
            }
        }

        private void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                char t = str[start];
                str[start++] = str[end];
                str[end--] = t;
            }
        }
    }
}
