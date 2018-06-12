using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    public class Valid_Number
    {
        /*
         * 
         * If we see [0-9] we reset the number flags.
We can only see . if we didn't see e or ..
We can only see e if we didn't see e but we did see a number. We reset numberAfterE flag.
We can only see + and - in the beginning and after an e
any other character break the validation.
         * 
         * 
         */
        public static bool IsNumber(string s)
        {
            s = s.Trim();

            var pointSeen = false;
            var eSeen = false;
            var numberSeen = false;
            var numberAfterE = true;
            for (int i = 0; i < s.Length; i++)
            {
                if ('0' <= s[i] && s[i] <= '9')
                {
                    numberSeen = true;
                    numberAfterE = true;
                }
                else if (s[i] == '.')
                {
                    if (eSeen || pointSeen)
                    {
                        return false;
                    }
                    pointSeen = true;
                }
                else if (s[i] == 'e')
                {
                    if (eSeen || !numberSeen)
                    {
                        return false;
                    }
                    numberAfterE = false;
                    eSeen = true;
                }
                else if (s[i] == '-' || s[i] == '+')
                {
                    if (i != 0 && s[i - 1] != 'e')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return numberSeen && numberAfterE;

        }

       
    }
}
