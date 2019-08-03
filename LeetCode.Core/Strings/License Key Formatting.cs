using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class License_Key_Formatting
    {
        public String LicenseKeyFormatting(String s, int k)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
                if (s[i] != '-')
                    sb.Append(sb.Length % (k + 1) == k ? "-" : "").Append(s[i]);
            return new string(sb.ToString().Reverse().ToArray()).ToUpper();
        }
    }

    


}
