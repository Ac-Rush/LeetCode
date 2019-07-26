using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BFS
{
    class Open_the_Lock
    {
        public int OpenLock(string[] deadends, string target)
        {
            var step = 0;
            var set = new HashSet<string>(deadends);
            var queue = new Queue<string>();
            var visit = new HashSet<string>();
            var root = "0000";
            queue.Enqueue(root);
            visit.Add(root);
            while (queue.Count > 0)
            {
                var count = queue.Count;
                while (count-- > 0)
                {
                    var s = queue.Dequeue();
                    if (set.Contains(s))
                    {
                        continue;
                    }

                    if (s.Equals(target)) return step;
                    for (int i = 0; i < 4; i++)
                    {
                        char c = s[i];
                        String s1 = s.Substring(0, i) + (c == '9' ? 0 : c - '0' + 1) + s.Substring(i + 1);
                        String s2 = s.Substring(0, i) + (c == '0' ? 9 : c - '0' - 1) + s.Substring(i + 1);
                        if (!visit.Contains(s1) && !set.Contains(s1))
                        {
                            queue.Enqueue(s1);
                            visit.Add(s1);
                        }
                        if (!visit.Contains(s2) && !set.Contains(s2))
                        {
                            queue.Enqueue(s2);
                            visit.Add(s2);
                        }
                    }
                }
                step++;
            }
            return -1;
        }
    }
}
