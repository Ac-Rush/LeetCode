using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Unique_Email_Addresses
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> result = new HashSet<string>();

            foreach (string email in emails)
            {
                string[] em = email.Split('@');
                String[] firstPart = em[0].Split('+');
                int indexPoint = firstPart[0].IndexOf(".", StringComparison.Ordinal);
                String addPart = firstPart[0];
                if (indexPoint > -1)
                {
                    String[] secondPart = firstPart[0].Split('.');
                    addPart = secondPart[0] + secondPart[1];
                }

                result.Add(addPart[0] + "@" + em[1]);
            }

            return result.Count;
        }
    }
}
