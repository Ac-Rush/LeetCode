using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Design
{
    class ZigzagIterator
    {
        Queue<int> rs;
        public ZigzagIterator(IList<int> v1, IList<int> v2)
        {
            rs = new Queue<int>();
            int cnt1 = v1.Count;
            int cnt2 = v2.Count;
            int cnt = cnt1 > cnt2 ? cnt1 : cnt2;
            for (int i = 0; i < cnt; i++)
            {
                if (i < cnt1)
                    rs.Enqueue(v1[i]);
                if (i < cnt2)
                    rs.Enqueue(v2[i]);
            }
        }

        public bool HasNext()
        {
            return rs.Count == 0 ? false : true;
        }

        public int Next()
        {
            return rs.Dequeue();
        }
    }
}
