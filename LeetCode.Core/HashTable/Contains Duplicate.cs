using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Contains_Duplicate
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (var n in nums)
            {
                if (set.Contains(n)) return true;
                set.Add(n);
            }
            return false;
        }
    }
}
