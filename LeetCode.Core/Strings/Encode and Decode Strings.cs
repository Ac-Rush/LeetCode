using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    public class Codec
    {

        // Encodes a list of strings to a single string.

       //自己编码   {长度}/{content}
        public string encode(IList<string> strs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in strs)
            {
                sb.Append(s.Length).Append('/').Append(s);
            }
            return sb.ToString();
        }

        // Decodes a single string to a list of strings.
        public IList<string> decode(string s)
        {
            List<String> ret = new List<String>();
            int i = 0;
            while (i < s.Length)
            {
                int slash = s.IndexOf('/', i);
                int size = int.Parse(s.Substring(i, slash - i ));
                ret.Add(s.Substring(slash + 1,  size ));
                i = slash + size + 1;
            }
            return ret;
        }
    }
}
