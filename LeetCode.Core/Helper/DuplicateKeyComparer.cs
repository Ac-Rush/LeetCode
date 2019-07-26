﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Helper
{
    public class DuplicateKeyComparer<TKey>
        :
            IComparer<TKey> where TKey : IComparable
    {


        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1; // Handle equality as beeing greater
            else
                return result;
        }
    }
}
