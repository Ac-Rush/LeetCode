using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    class Masking_Personal_Information
    {
        public string MaskPII(string S)
        {
            int atIndex = S.IndexOf('@');
            if (atIndex >= 0)
            { // email
                return (S.Substring(0, 1) + "*****" + S.Substring(atIndex - 1)).ToLower();
            }
            else
            { // phone
                String digits = Regex.Replace(S,"\\D+", "");
                String local = "***-***-" + digits.Substring(digits.Length - 4);
                if (digits.Length == 10) return local;
                String ans = "+";
                for (int i = 0; i < digits.Length - 10; ++i)
                    ans += "*";
                return ans + "-" + local;
            }
        }
    }
}
