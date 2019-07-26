using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Bit
{
    class Binary_Watch
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            List<string> llist = new List<string>();
            int[] liaMin = new int[60];

            for (int i = 1; i < 60; ++i)
            {
                liaMin[i] = liaMin[i & i - 1] + 1;
            }

            for (int i = 0; i < 12; ++i)
            {
                if (num >= liaMin[i])
                {
                    for (int j = 0; j < 60; ++j)
                    {
                        if (liaMin[j] == num - liaMin[i])
                            llist.Add(i.ToString() + ":" + (j < 10 ? "0" : "") + j.ToString());
                    }
                }
            }
            return llist;
        }
    }
}
