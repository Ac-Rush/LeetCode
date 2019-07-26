using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Subdomain_Visit_Count
    {
        /// <summary>
        /// my solution 一次过
        /// </summary>
        /// <param name="cpdomains"></param>
        /// <returns></returns>
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            var dict = new Dictionary<string, int>();
            foreach (var s in cpdomains)
            {
                var segments = s.Split(' ');
                int count = int.Parse(segments[0]);
                var domain = segments[1];
                do
                {
                    if (!dict.ContainsKey(domain))
                    {
                        dict[domain] = 0;
                    }
                    dict[domain] += count;
                    var nextStart = domain.IndexOf('.');
                    if (nextStart > 0)
                    {
                        domain = domain.Substring(nextStart + 1);
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            var result = new List<string>();
            foreach (var item in dict)
            {
                result.Add($"{item.Value} {item.Key}");
            }
            return result;
        }
    }
}
