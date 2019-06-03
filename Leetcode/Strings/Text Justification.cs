using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Text_Justification
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> lines = new List<string>();

            int index = 0;
            while (index < words.Length)
            {
                int count = words[index].Length;
                int last = index + 1;
                while (last < words.Length)
                {
                    if (words[last].Length + count + 1 > maxWidth) break;
                    count += words[last].Length + 1;
                    last++;
                }

                StringBuilder builder = new StringBuilder();
                int diff = last - index - 1;
                // if last line or number of words in the line is 1, left-justified
                if (last == words.Length || diff == 0)
                {
                    for (int i = index; i < last; i++)
                    {
                        builder.Append(words[i] + " ");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    for (int i = builder.Length; i < maxWidth; i++)
                    {
                        builder.Append(" ");
                    }
                }
                else
                {
                    // middle justified
                    int spaces = (maxWidth - count) / diff;
                    int r = (maxWidth - count) % diff;
                    for (int i = index; i < last; i++)
                    {
                        builder.Append(words[i]);
                        if (i < last - 1)
                        {
                            for (int j = 0; j <= (spaces + ((i - index) < r ? 1 : 0)); j++)
                            {
                                builder.Append(" ");
                            }
                        }
                    }
                }
                lines.Add(builder.ToString());
                index = last;
            }


            return lines;
        }
    }
}
