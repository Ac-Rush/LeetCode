using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Add_Bold_Tag_in_String
    {
        class interval
        {
            public int start;
            public int end;
            public interval(int s, int e)
            {
                this.start = s; this.end = e;
            }
        }

        public string AddBoldTag(string s, string[] words)
        {
            var list = new List<interval>();
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                foreach (string w in words)
                {
                    if (s.Substring(i).StartsWith(w))
                    {
                        var str = new interval(i, i + w.Length - 1);
                        // add
                        if (list.Count > 0 && i <= list[list.Count - 1].end + 1)
                        {
                            list[list.Count - 1].end = Math.Max(list[list.Count - 1].end, str.end);
                            continue;
                        }
                        list.Add(str);
                    }
                }
            }

            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {

                if (j < list.Count && i == list[j].start) sb.Append("<b>");
                sb.Append(s[i]);
                if (j < list.Count && i == list[j].end) { sb.Append("</b>"); j++; }
            }

            return sb.ToString();
        }
    }
}
