﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Isomorphic_Strings
    {
        /// <summary>
        /// 太厉害了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            var m1 = new int[256]; var m2 = new int[256];
            int n = s.Length;
            for (int i = 0; i < n; ++i)
            {
                if (m1[s[i]] != m2[t[i]]) return false;  //如果 这个字符的上次出现的位置不一样， 那么返回 false
                m1[s[i]] = i + 1;  //更新这个字符最后出现的位置  
                m2[t[i]] = i + 1;
            }
            return true;
        }
    }
}
