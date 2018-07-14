using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    /// <summary>
    /// good 一次过
    /// </summary>
    public class Logger
    {

        private Dictionary<string, int> dict;
        /** Initialize your data structure here. */
        public Logger()
        {
            dict = new Dictionary<string, int>();
        }

        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
            If this method returns false, the message will not be printed.
            The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!dict.ContainsKey(message))
            {
                dict[message] = timestamp;
                return true;
            }
            var second = dict[message];
            if (timestamp - second >= 10)
            {
                dict[message] = timestamp;
                return true;
            }
            return false;
        }
    }
}
