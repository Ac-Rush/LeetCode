﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Core.Sort
{
    class Sort_an_Array
    {
        public int[] SortArray(int[] nums)
        {
            return nums.OrderBy(i=>i).ToArray();
        }
    }
}
