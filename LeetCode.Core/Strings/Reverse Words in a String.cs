using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Reverse_Words_in_a_String
    {
        public string ReverseWords(string s)
        {
            var sb = new StringBuilder();
            string[] wordArr = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = wordArr.Length - 1; i >= 0; i--)
            {
                var word = wordArr[i].Trim();
                sb.Append(word);
                if (i != 0)
                    sb.Append(" ");
            }
            return sb.ToString();
        }
        public string ReverseWords2(string s)
        {
            return string.Join(" ", s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse());
        }

    }

    class Reverse_Words_in_a_String_2
    {
        public string ReverseWords(string s)
        {
            var array = s.ToCharArray();
            int i = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (s[j] == ' ')
                {
                    reverse(array, i, j - 1);
                    i = j + 1;
                }
            }

            reverse(array, i, array.Length - 1);

            reverse(array, 0, array.Length - 1);
            return new string(array);
        }
        public void reverse(char[] s, int i, int j)
        {
            while (i < j)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }

    }
}
